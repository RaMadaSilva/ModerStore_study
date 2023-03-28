using Microsoft.AspNetCore.Mvc;
using ModernStore.Domain.Command;
using ModernStore.Domain.CommandHendler;
using ModernStore.Domain.Repository;
using ModernStore.Shared.UniteOfWork;

namespace ModernStore.Api.Controllers
{
    [ApiController]
    [Route("v1")]
    public class ProductController : ControllerBase
    {
        private readonly IproductRepository _repository; 
        private readonly IUniteOfWork _uniteOfWork;
        private readonly ProductCommandHendler _hendler; 
        public ProductController(IproductRepository repository, 
            IUniteOfWork uniteOfWork, 
            ProductCommandHendler hendler)
        {
            _uniteOfWork = uniteOfWork;
            _hendler = hendler;
            _repository = repository;
        }

        [HttpPost]
        [Route("product")]
        public IActionResult Post([FromBody] RegisterProductCommand comand)
        {
           var result = _hendler.Handler(comand);
            if (_hendler.IsValid)
            {
                _uniteOfWork.Commit();
                return Ok(result);
            }
            else
            {
                return BadRequest(_hendler.Notifications); 
            }
        }

        [HttpGet]
        [Route("product")]
        public IActionResult Get()
        {
            return Ok(_repository.GetProducts());
        }
    }
}
