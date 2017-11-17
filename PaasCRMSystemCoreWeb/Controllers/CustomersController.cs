using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using PaasCRMSystemCoreWeb.DAL;

namespace PaasCRMSystemCoreWeb.Controllers
{
    [Produces("application/json")]
    [Route("api/Customers")]
    public class CustomersController : Controller
    {
        private const string INVALID_CONTEXT = "Invalid Customers Context Specified!";
        private const int MIN_SEARCH_LENGTH = 3;
        private const string BUSINESS_VALIDATION_FAILED = "Business Validation Failed!";

        private static string[] BAD_KEYWORDS = new string[] { "bad", "worse", "not good" };

        private CustomersContext customersContext = default(CustomersContext);
        public CustomersController(CustomersContext customersContext)
        {
            this.customersContext = customersContext;

            if (this.customersContext == default(CustomersContext))
                throw new ArgumentException(INVALID_CONTEXT);
        }

        [HttpGet("search/{customerName}")]
        public IActionResult GetCustomers(string customerName)
        {
            var validation = !string.IsNullOrEmpty(customerName) &&
                customerName.Length >= MIN_SEARCH_LENGTH &&
                !BAD_KEYWORDS.Contains(customerName);

            if (!validation)
                return BadRequest(BUSINESS_VALIDATION_FAILED);

            var filteredCustomers = this.customersContext.Customers.Where(
                customer => customer.CustomerName.Contains(customerName)).ToList();

            return Ok(filteredCustomers);
        }

        [HttpGet("detail/{customerId}")]
        public IActionResult GetCustomerDetail(int customerId)
        {
            var validation = customerId != default(int);

            if (!validation)
                return BadRequest(BUSINESS_VALIDATION_FAILED);

            var filteredCustomer = this.customersContext.Customers.Where(
                customer => customer.CustomerId.Equals(customerId)).FirstOrDefault();

            return Ok(filteredCustomer);
        }
    }
}