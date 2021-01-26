using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using Ecommerce.DbContexts;
using Ecommerce.Entities;
using Ecommerce.ModelDTO;

namespace Ecommerce.OrdersManager
{
    public static class OrderManager
    {
        
        //public delegate void Sender(Orders order); // Declaration of delegate
        //public event Sender send = null; // obj creationg of delegate
        //public readonly List<Orders> orderlist; 
        //public OrderManager(List<Orders> _orders)
        //{
        //    orderlist = _orders;
        //}

        
    //public static void UpdateOrderStatus()
    //    {
            
    //        foreach (var order in orderlist)
    //        {
    //            Thread.Sleep(5000);
    //            if (order.Status == "Ordered")
    //                order.Status = "Processing";
    //            else if (order.Status == "Processing")
    //                order.Status = "Shipped";
    //            else if (order.Status == "Shipped")
    //                order.Status = "Delivered"; 
    //            send(order);
    //        }
    //    }

        public static List<Orders> GetOrdersToInsert(List<CreateOrderDTO> insertOrders)
        {
            List<Orders> OrdersList = new List<Orders>();
            foreach (var EachOrder in insertOrders)
            {
                OrdersList.Add(SingleOrder(EachOrder));                 
            }
            return OrdersList;
        }

        public static Orders SingleOrder(CreateOrderDTO EachOrder)
        {
            Random Value = new Random();
            var tax = decimal.Round((EachOrder.Quantity * 20.0000m) * 6 / 100, 2);
            var shipcharges = decimal.Round(((EachOrder.Quantity * 20.0000m) * 7 / 100), 2);
            var subtotal = decimal.Round(EachOrder.Quantity * (EachOrder.costPerItem + .0000m), 2);
            var total = decimal.Round((subtotal + tax + shipcharges), 2);
            
            return new Orders
            {
                Name = EachOrder.Name,
                Status = "Ordered",
                CustomerId = Value.Next(),
                Quantity = EachOrder.Quantity,
                Subtotal = subtotal,
                Tax = tax,
                ShippingCharges = shipcharges,
                Total = total,
                CreatedDate = DateTimeOffset.Now,
                ModifiedDate = DateTimeOffset.Now,
                Payment = GetPaymentlist(EachOrder.Payment),
                Shipping = ShipDetails(EachOrder.Shipping)
            };
        }

        public static Helpers.Common.Result ReturnModelMessage(CreateOrderDTO insertOrder)
        {
            var result = new Helpers.Common.Result();
            
            if (insertOrder.Name == "string".ToLower())
            {
                result.ModelMessageList.Add(o => o.Name, " Please Enter the Name", false);
                return result;
            }
            if (insertOrder.costPerItem == 0)
            {
                result.ModelMessageList.Add(o => o.Payment, " Please Enter the CostPer item, Even though it takes $20/Quantity", false);
                return result;
            }
            else if (insertOrder.Quantity == 0)
            {
                result.ModelMessageList.Add(o => o.Quantity, "Please Enter the Quantity", false);
                return result;
            }            
            else if (insertOrder.Shipping.ShippingType == "string".ToLower())
            {
                result.ModelMessageList.Add(o => o.Shipping, " Please enter ShippingType", false);
                return result;
            }            
            else
            {
                result.ModelMessageList.Add(o => o.Name, " Fields validation are done", true);
                return result;
            }
        }

        public static List<ShippingDetails> ShipDetails(CreateShippingDetailDTO shippingDTO)
        {
            List<ShippingDetails> Shippings = new List<ShippingDetails>();
            Shippings.Add(new ShippingDetails
            {
                ShippingType = shippingDTO.ShippingType,
                ShippingAdd1 = shippingDTO.ShippingAdd1,
                ShippingAdd2 = shippingDTO.ShippingAdd2,
                City = shippingDTO.City,
                State = shippingDTO.State,
                Zip = shippingDTO.Zip,
            });
            return Shippings;
        }

        

        public static List<Payments> GetPaymentlist(ICollection<CreatePaymentDTO> EachOrderPayments)
        {
            List<Payments> Newpayments = new List<Payments>();
            foreach (var payment in EachOrderPayments )
            {
                Newpayments.Add(new Payments
                {
                    paymentmethod = payment.paymentmethod,
                    PaymentConfirmation = "Success",
                    BillingAdd1 = payment.BillingAdd1,
                    BillingAdd2 = payment.BillingAdd2,
                    City = payment.City,
                    State = payment.State,
                    Zip = payment.Zip,
                    Paymentdate = DateTimeOffset.Now.ToString()
                });                
            };
            return Newpayments;
        }
    }

    

       

    
}
