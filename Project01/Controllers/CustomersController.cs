using MediatR;
using Microsoft.AspNetCore.Mvc;
using Store.Application.DTOs.Customer;
using Store.Application.Features.Customers.Commands;
using Store.Application.Features.Customers.Queries;

namespace Store.API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class CustomersController : ControllerBase
     {
        private readonly IMediator _mediator;
        public CustomersController(IMediator mediator)
        {
            _mediator = mediator;
        }
        [HttpGet]
        public async Task<IActionResult> GetAll(CancellationToken ct)
        {
            var result = await _mediator.Send(new GetAllCustomersQuery());
            return Ok(result);
        }
        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(int id)
        {
            var customer = await _mediator.Send(new GetCustomerByIdQuery(id));
            if (customer == null)
                return NotFound();
            return Ok(customer);
        }
        [HttpPost]
        public async Task<IActionResult> Create(CreateCustomerDto dto)
        {
            var result = await _mediator.Send(new CreateCustomerCommand(dto));
            return CreatedAtAction(nameof(GetById), new { id = result.Id }, result);
        }
        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            var result = await _mediator.Send(new DeleteCustomerCommand(id));
            if (!result)
                return NotFound();
            return NoContent();
        }
    }
}
