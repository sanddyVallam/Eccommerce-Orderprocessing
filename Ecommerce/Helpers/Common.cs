using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;
using Ecommerce.ModelDTO;

namespace Ecommerce.Helpers
{
    public class Common
    {
        public class ModelMessage
        {
            public string PropertyName { get; set; }                                 
            public bool IsSuccess { get; set; }
        }

        public class Result : Result<OrdersDTO>
        {
            public OrdersDTO OrderDTO { get; set; }
            public Result()
            {
                this.OrderDTO = new OrdersDTO();
            }
        }

        public class Result<T>
        {
            public ModelMessageList<T> ModelMessageList { get; set; }


            public Result()
            {
                this.ModelMessageList = new ModelMessageList<T>();
            }
        }

        public class ModelMessageList<T> : List<ModelMessage>
        {
            public void Add(Expression<Func<T, object>> property, string PropertyName, bool IsSuccess)
            {
                this.Add(new ModelMessage()
                {
                    PropertyName = PropertyName,
                    IsSuccess = IsSuccess,

                });
            }

            

            
        }
    }
}
