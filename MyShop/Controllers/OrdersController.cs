using Entity;
using Microsoft.AspNetCore.Mvc;
using service;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace MyShop.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class OrdersController : ControllerBase
    {
        IOrderService OrderService;
        public OrdersController(IOrderService orderService)
        {
            OrderService = orderService;
        }

        // GET api/<CategoriesController>/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Order>> Get(int id)
        {
            Order foundOrder = await OrderService.GetOrderById(id);
            if (foundOrder == null)
                return NoContent();
            else

                return Ok(foundOrder);

        }

        // POST api/<CategoriesController>
        [HttpPost]
        public async Task<ActionResult> Post([FromBody] Order order)
        {
            Order newOrder = await OrderService.AddOrder(order);
            if (newOrder != null)
                return Ok(newOrder);
            else
                return Unauthorized();

        }




    }
}
