using MediatR;
using Microsoft.AspNetCore.Mvc;
using Store.Application.DTOs.Order;
using Store.Application.Features.Orders.Commands;
using Store.Application.Features.Orders.Queries;

namespace Store.API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class OrdersController : ControllerBase
    {
        private readonly IMediator _mediator;
        public OrdersController(IMediator mediator)
        {
            _mediator = mediator;
        }
        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var result = await _mediator.Send(new GetAllOrdersQuery());
            return Ok(result);
        }
        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(int id)
        {
            var result = await _mediator.Send(new GetOrderByIdQuery(id));
            if (result == null)
                return NotFound();
            return NoContent();
        }
        [HttpPost]
        public async Task<IActionResult> Create([FromBody] CreateOrderDto dto)
        {
            try
            {
                var result = await _mediator.Send(new CreateOrderCommand(dto));
                return CreatedAtAction(nameof(GetById), new { id = result.Id }, result);
            }
            catch (Exception ex)
            {
                return BadRequest(new { message = ex.Message });
            }
        }
        [HttpPut("{id}/status")]
        public async Task<IActionResult> Update(int id , [FromQuery]string status)
        {
            var result = await _mediator.Send(new UpdateOrderStatusCommand(id, status));
            if (!result)
                return NotFound();
            return NoContent();
        }
        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            var result = await _mediator.Send(new DeleteOrderCommand(id));
            if (!result)
                return NotFound();
            return NoContent();
        }
    }
}
