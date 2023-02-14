using AspNet_MediatR_Demo.Domain.Command;
using AspNet_MediatR_Demo.Domain.Entity;
using AspNet_MediatR_Demo.Domain.Queries;
using AspNet_MediatR_Demo.Repository;
using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace AspNet_MediatR_Demo.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProdutosController : ControllerBase
    {
        private readonly IMediator _mediator;

        public ProdutosController(IMediator mediator, IRepository<Produto> repository)
        {
            _mediator = mediator;
        }


        [HttpGet]
        public async Task<IActionResult> Get([FromQuery] ProdutoGetAllQuery query) =>
            Ok(await _mediator.Send(query));
        
        [HttpGet("{id}")]
        public async Task<IActionResult> Get(int id) =>
            Ok(await _mediator.Send(new ProdutoGetByIdQuery(id)));

        [HttpPost]
        public async Task<IActionResult> Post(ProdutoCreateCommand command)
        {
            var response = await _mediator.Send(command);
            return Ok(response);
        }
        [HttpPut]
        public async Task<IActionResult> Put(ProdutoUpdateCommand command)
        {
            var response = await _mediator.Send(command);
            return Ok(response);
        }
        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            var obj = new ProdutoDeleteCommand { Id = id };
            var result = await _mediator.Send(obj);
            return Ok(result);
        }
    }
}
