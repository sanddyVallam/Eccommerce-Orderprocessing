using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Ecommerce.Entities;
using Ecommerce.ModelDTO;

namespace Ecommerce.Services
{
    public interface IorderRepository
    {
        public IEnumerable<OrdersDTO> GetOrders();
        public Helpers.Common.Result GetOrder(int Id);
        public Helpers.Common.Result CreateOrder(CreateOrderDTO insertOrder);
        public void UpdateOrder();        
        public Helpers.Common.Result DeleteOrder(int Id);                
        public bool Save();
        public Helpers.Common.Result CreateBulkOrder(List<CreateOrderDTO> insertOrders);
        public Helpers.Common.Result UpdateBulkOrders(List<CompositeObject> OrderIds);

    }
}
