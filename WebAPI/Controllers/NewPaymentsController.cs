using Business.Abstract;
using Entities.Concrete;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class NewPaymentsController : ControllerBase
    {
        INewPaymentService _newPaymentService;
        public NewPaymentsController(INewPaymentService newPaymentService)
        {
            _newPaymentService = newPaymentService;
        }


        [HttpPost("add")]
        public IActionResult Add(NewPayment newPayment)
        {
            var result = _newPaymentService.Add(newPayment);

            if (result.Success)
            {
                return Ok(result);
            }
            else
            {
                return BadRequest(result.Message);
            }
        }
    }
}
