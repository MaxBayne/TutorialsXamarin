using System;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using TutorialsXamarin.Business.Interfaces;
using TutorialsXamarin.Business.Models;

namespace TutorialsXamarin.WebAPi.Controllers.v1
{
    [Route("api/v1/[controller]")]
    [ApiController]
    public class CustomersController : ControllerBase
    {
        private readonly ICustomerManager _customerManager;

        public CustomersController(ICustomerManager customerManager)
        {
            _customerManager = customerManager;
        }

        #region Retrieve

        [HttpGet]
        [Route("")]
        public async Task<IActionResult> GetCustomersList()
        {
            try
            {
                var customers = await _customerManager.GetCustomersToListAsync();

                return Ok(customers);
            }
            catch (Exception e)
            {
                return BadRequest(e);
            }
        }

        [HttpGet]
        [Route("collection")]
        public async Task<IActionResult> GetCustomersCollection()
        {
            try
            {
                var customers = await _customerManager.GetCustomersAsync();

                return Ok(customers);
            }
            catch (Exception e)
            {
                return BadRequest(e);
            }
        }

        [HttpGet("{id:int}")]
        public async Task<IActionResult> GetCustomerById(int id)
        {
            try
            {
                var customer = await _customerManager.GetCustomerByIdAsync(id);

                if (customer != null)
                {
                    return Ok(customer);
                }

                return NoContent();
            }
            catch (Exception e)
            {
                return BadRequest(e);
            }

        }

        [HttpGet("{code:Guid}")]
        public async Task<IActionResult> GetCustomerByCode(Guid code)
        {
            try
            {
                var customer = await _customerManager.GetCustomerByCodeAsync(code);

                if (customer != null)
                {
                    return Ok(customer);
                }

                return NoContent();
            }
            catch (Exception e)
            {
                return BadRequest(e);
            }

        }

        #endregion

        #region Insert

        [HttpPost]
        public async Task<IActionResult> AddCustomer([FromBody]Customer newCustomer)
        {
            try
            {
                //Validate Model

                if (newCustomer == null)
                    return BadRequest();

                if (string.IsNullOrEmpty(newCustomer.FirstName))
                {
                    ModelState.AddModelError("FirstName","FirstName is Required");
                }

                if(!ModelState.IsValid)
                    return BadRequest(ModelState);

                var customer = await _customerManager.AddCustomer(newCustomer);

                return Created("customer", customer);
            }
            catch (Exception e)
            {
                return BadRequest(e);
            }
        }

        #endregion

        #region Update

        [HttpPut]
        public async Task<IActionResult> UpdateCustomer([FromBody] Customer updateCustomer)
        {
            try
            {
                //Validate Model

                if (updateCustomer == null)
                    return BadRequest();

                if (string.IsNullOrEmpty(updateCustomer.Code.ToString()))
                {
                    ModelState.AddModelError("Code", "Code Required For Update");
                }

                if (string.IsNullOrEmpty(updateCustomer.FirstName))
                {
                    ModelState.AddModelError("FirstName", "FirstName is Required");
                }


                if (!ModelState.IsValid)
                    return BadRequest(ModelState);

                var customer = await _customerManager.UpdateCustomer(updateCustomer);

                if (customer == null)
                    return NotFound();

                return NoContent();
            }
            catch (Exception e)
            {
                return BadRequest(e);
            }
        }

        #endregion

        #region Delete

        [HttpDelete("{id:int}")]
        public async Task<IActionResult> DeleteCustomer(int id)
        {
            try
            {
                //Validate Model

                if (id <= 0)
                {
                    ModelState.AddModelError("Id", "Id Required For Delete");
                }

                if (!ModelState.IsValid)
                    return BadRequest(ModelState);

                var customer = await _customerManager.DeleteCustomer(id);

                if (!customer)
                    return NotFound();

                return NoContent();
            }
            catch (Exception e)
            {
                return BadRequest(e);
            }
        }

        [HttpDelete("{code:Guid}")]
        public async Task<IActionResult> DeleteCustomer(Guid code)
        {
            try
            {
                //Validate Model

                if (code==Guid.Empty)
                {
                    ModelState.AddModelError("Code", "Code Required For Delete");
                }

                if (!ModelState.IsValid)
                    return BadRequest(ModelState);

                var customer = await _customerManager.DeleteCustomer(code);

                if (!customer)
                    return NotFound();

                return NoContent();
            }
            catch (Exception e)
            {
                return BadRequest(e);
            }
        }

        #endregion

    }
}
