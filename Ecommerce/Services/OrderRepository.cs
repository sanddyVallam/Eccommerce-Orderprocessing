using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Ecommerce.DbContexts;
using Ecommerce.Entities;
using AutoMapper;
using Ecommerce.ModelDTO;
using System.Threading;
using Ecommerce.OrdersManager;
using Microsoft.EntityFrameworkCore;
using Ecommerce.Helpers;
using EFCore.BulkExtensions;
using Microsoft.Extensions.Logging;

namespace Ecommerce.Services
{
    public class OrderRepository : IorderRepository
    {
        private readonly OrdersContext _OrdersContext;
        private readonly IMapper _mapper;
        private readonly ILogger<OrderRepository> _Logger;

        IDictionary<int, string> Status = new Dictionary<int, string>
        {
            { 1, "Ordered"},
            { 2, "Processing"},
            { 3, "Shipped"},
            { 4, "Delivered"}

        };

        public OrderRepository(OrdersContext context, IMapper _map, ILogger<OrderRepository> logger)
        {
            _OrdersContext = context ?? throw new ArgumentException(nameof(context));
            _mapper = _map;
            _Logger = logger;
        }

        public Helpers.Common.Result CreateOrder(CreateOrderDTO insertOrder)
        {
            var result = new Helpers.Common.Result();
            
            var sumpayment = insertOrder.Payment.Sum(s => s.Paymentamount);

            result = OrderManager.ReturnModelMessage(insertOrder);
            if (result.ModelMessageList.Any(s => s.IsSuccess))
                result = new Helpers.Common.Result();
            else
                return result;

            var NewOrder = OrderManager.SingleOrder(insertOrder);
            if (sumpayment == 0 || sumpayment != NewOrder.Total)
            {
                result.ModelMessageList.Add(o => o.Name, " The Price for Each Order is $20/Quantity, Tax = 0.6%, Shipping Charges = 0.7% the total should be: " + NewOrder.Total + ".", false);
                return result;
            }           

            _OrdersContext.Orders.Add(NewOrder);

            if (Save())
            {
                result.ModelMessageList.Add(o => o.Name, "Order Inserted Successfully", true);
                return result;
            }
            else
            {
                result.ModelMessageList.Add(o => o.Name, "Order Not Inserted", false);
                return result;
            }

        }

        public Helpers.Common.Result GetOrder(int Id)
        {
            var result = new Helpers.Common.Result();
            var order = _OrdersContext.Orders.Where(s => s.Id == Id)
                        .Include(Payment => Payment.Payment)
                        .Include(Ship => Ship.Shipping)
                        .FirstOrDefault();
            if (order == null)
            {
                _Logger.LogWarning($"No Record found with that ID {Id}");
                result.ModelMessageList.Add(o => o.Name, "No Record found with that ID", false);
                return result;
            }
            else
            {
                var Maporder = _mapper.Map<OrdersDTO>(order);
                result.OrderDTO = Maporder;
                return result;
            }


        }

        public IEnumerable<OrdersDTO> GetOrders()
        {

            var orderslist = _OrdersContext.Orders
                .Include(order => order.Payment)
                .Include(order => order.Shipping)
                    .OrderBy(s => s.Id).ToList();

            var Maporderslit = _mapper.Map<IEnumerable<OrdersDTO>>(orderslist);
            return Maporderslit.ToList();
        }



        public bool Save()
        {
            return (_OrdersContext.SaveChanges() >= 0);

        }

        public void UpdateOrder()
        {
            var orderslst = _OrdersContext.Orders.OrderBy(s => s.Id).ToList();
            var Maporder = _mapper.Map<IEnumerable<OrdersDTO>>(orderslst);
        }

        public Helpers.Common.Result DeleteOrder(int Id)
        {
            var result = new Helpers.Common.Result();
            var order = _OrdersContext.Orders.Where(s => s.Id == Id)
                        .Include(Payment => Payment.Payment)
                        .Include(Ship => Ship.Shipping)
                        .FirstOrDefault();
            if (order != null)
            {
                _OrdersContext.Orders.Remove(order);
                Save();
                result.ModelMessageList.Add(o => o.Name, "Record Deleted Successfully", true);
                return result;
            }
            else
            {
                _Logger.LogWarning($"No Record found with that ID {Id}");
                result.ModelMessageList.Add(o => o.Name, "No Record found with that ID", false);
                return result;
            }


        }

        public Helpers.Common.Result CreateBulkOrder(List<CreateOrderDTO> insertOrders)
        {
            var result = new Helpers.Common.Result();
            foreach (var order in insertOrders)
            {
                result = OrderManager.ReturnModelMessage(order);
                if (result.ModelMessageList.Any(s => s.IsSuccess))
                    result = new Helpers.Common.Result();
                else
                {

                    return result;
                }

            }
            var OrdersList = OrderManager.GetOrdersToInsert(insertOrders);

            var SumPayment = insertOrders.Sum(v => v.Payment.Sum(s => s.Paymentamount));   //.Payment.Sum(s => s.Paymentamount);
            var TotalordersActualPayment = OrdersList.Sum(v => v.Total);
            if (SumPayment == 0 || SumPayment != TotalordersActualPayment)
            {
                result.ModelMessageList.Add(o => o.Name, " The Price for Each Order is $20/Quantity, Tax = 0.6%, Shipping Charges = 0.7% the Sum of orders should be: " + TotalordersActualPayment + ".", false);
                return result;
            }

            _OrdersContext.Orders.AddRange(OrdersList);
            //_OrdersContext.BulkInsert(OrdersList);
            if (Save())
            {
                result.ModelMessageList.Add(o => o.Name, "Records Inserted Successfully", true);
                return result;
            }
            else
            {
                result.ModelMessageList.Add(o => o.Name, "Records Insertion failed", false);
                return result;
            }

        }        

        public Helpers.Common.Result UpdateBulkOrders(List<CompositeObject> OrderIds)
        {
            var result = new Helpers.Common.Result();            
            var Orders = _OrdersContext.Orders.Where(s => OrderIds.Select(v => v.ListOutToUpdateOrdersID).Contains(s.Id))
                        .Include(Payment => Payment.Payment)
                        .Include(Ship => Ship.Shipping)
                        .ToList();          
            if (Orders.Count() != OrderIds.Count())
            {
                result.ModelMessageList.Add(o => o.Name, "OrderIds are not found in DataBase", false);
                return result;
            }
            List<Orders> OrdersList = new List<Orders>();
            for (int i = 0; i < OrderIds.Count(); i++)
            {
                var Order = Orders.Where(s => s.Id == OrderIds[i].ListOutToUpdateOrdersID)
                        .FirstOrDefault();

                if (OrderIds[i].Status == "string".ToLower())
                {
                    result.ModelMessageList.Add(o => o.Name, " Please Enter the Status", false);
                    return result;
                }

                Order.Status = OrderIds[i].Status;                
                Order.ModifiedDate = DateTimeOffset.Now;                
                OrdersList.Add(Order);               
            }
            _OrdersContext.Orders.UpdateRange(OrdersList);
            if (Save())
            {
                result.ModelMessageList.Add(o => o.Name, "Orders status Updated to Delivered", true);
                return result;
            }
            else
            {
                result.ModelMessageList.Add(o => o.Name, "Orders Updated Successfully", false);
                return result;
            }



        }
    }
}
