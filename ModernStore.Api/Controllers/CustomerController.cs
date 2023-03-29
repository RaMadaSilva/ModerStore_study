﻿using Microsoft.AspNetCore.Mvc;
using ModernStore.Domain.Command;
using ModernStore.Domain.CommandHendler;
using ModernStore.Domain.Repository;
using ModernStore.Shared.UniteOfWork;

namespace ModernStore.Api.Controllers
{
    [ApiController]
    [Route("v1")]
    public class CustomerController : ControllerBase
    {
        private readonly IUniteOfWork _uniteOfWork;
        private readonly ICustomerRepository _repository;
        private readonly CustomerCommandHandler _handler;

        public CustomerController(IUniteOfWork uniteOfWork, 
            ICustomerRepository repository, 
            CustomerCommandHandler handler)
        {
            _uniteOfWork = uniteOfWork;
            _repository = repository;
            _handler = handler;
        }

        [HttpPost]
        [Route("customer")]
        public ActionResult PostCustomer([FromBody] RegisterCustomerCommand command) 
        {
            var result = _handler.Handler(command);

            if (_handler.IsValid)
            {
                _uniteOfWork.Commit();
                return Ok(result);
            }
            else
            {
                return BadRequest(_handler.Notifications); 
            }
        }
        [HttpGet]
        [Route("customerByUserName/{userName?}")]
        public ActionResult GetCustomerByUserName([FromRoute] string userName)
        {
            return  Ok(_repository.Get(userName)); 
        }

        [HttpGet]
        [Route("customer/{id:}")]
        public ActionResult GetCustomerById([FromRoute] Guid id)
        {
            return Ok(_repository.Get(id));
        }

        [HttpPut]
        [Route("customer")]
        public ActionResult UpdateCustomer([FromBody] UpdateCustomerCommand command)
        {
            var result = _handler.Handler(command);
            _uniteOfWork.Commit(); 

            return Ok(result);

        }

    }
}
