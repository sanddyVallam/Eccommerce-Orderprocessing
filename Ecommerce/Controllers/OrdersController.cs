using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Ecommerce.ModelDTO;
using Ecommerce.Services;
using Microsoft.AspNetCore.Mvc;


namespace Ecommerce.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class OrdersController : ControllerBase
    {
        private readonly IorderRepository _IorderRepository;

        public OrdersController(IorderRepository _Repo)
        {
            _IorderRepository = _Repo;//?? throw new ArgumentNullException(nameof(_Repo));
        }

        [HttpGet]
        public IActionResult Getorders()
        {
            var getorders = _IorderRepository.GetOrders();            
            return new JsonResult(getorders);

        }

        [HttpGet("{OrderId}")]
        public IActionResult Getorders(int OrderId)
        {
            var Result = _IorderRepository.GetOrder(OrderId);
            return new JsonResult(Result);

        }

        [HttpPost("CreateOrder")]
        public IActionResult CreateOrder([FromBody] CreateOrderDTO ordercreate)
        {
            var Result = _IorderRepository.CreateOrder(ordercreate);            
                return new JsonResult(Result.ModelMessageList.FirstOrDefault());
            
        }

        [HttpDelete("CancelOrder/{OrderId}")]
        public IActionResult CancelOrder(int OrderId)
        {
            var Result = _IorderRepository.DeleteOrder(OrderId);
            return new JsonResult(Result.ModelMessageList.FirstOrDefault());
        }

        [HttpPost("CreateBulkOrders")]
        public IActionResult CreateBulkOrders([FromBody] List<CreateOrderDTO> CreateOrders)
        {
            var Result = _IorderRepository.CreateBulkOrder(CreateOrders);
            return new JsonResult(Result.ModelMessageList.FirstOrDefault());

        }

        [HttpPut("UpdateBulkOrders")]
        public IActionResult UpdateBulkOrders( [FromBody] List<CompositeObject> OrderIds)
        {
           
            var Result = _IorderRepository.UpdateBulkOrders(OrderIds);
            return new JsonResult(Result.ModelMessageList.FirstOrDefault());

        }

        
    }
}
