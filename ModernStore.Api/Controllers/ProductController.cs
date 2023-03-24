using Microsoft.AspNetCore.Mvc;
using ModernStore.Domain.Command;
using ModernStore.Domain.Repository;
using ModernStore.Infra.Context;
using ModernStore.Shared.Command;

namespace ModernStore.Api.Controllers
{
    [ApiController]
    [Route("v1")]
    public class ProductController : ControllerBase
    {
        private readonly IproductRepository _repository; 
        public ProductController(IproductRepository repository)
        {
            _repository = repository;
        }

        //[HttpPost]
        //[Route("product")]
        //public IActionResult Post([FromBody]RegisterProductCommand comand)
        //{
        //    _repository.Save(comand); 
        //}

        [HttpGet]
        [Route("product")]
        public IActionResult Get()
        {
            return Ok(_repository.GetProducts());
        }
    }
}
