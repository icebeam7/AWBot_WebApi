using System.Linq;
using Microsoft.AspNetCore.Mvc;
using AWBot_WebApi.Models;
using AWBot_WebApi.Context;

namespace AWBot_WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CustomersController : Controller
    {
        private readonly AdventureWorksLTContext _context;

        public CustomersController(AdventureWorksLTContext context)
        {
            _context = context;
        }

        // GET: api/Customers/email
        [HttpGet("{email}")]
        public ActionResult<CustomerShort> GetCustomer(string email)
        {
            var customer = _context.Customer.FirstOrDefault(x => x.EmailAddress == email);

            if (customer != null)
            {
                return new CustomerShort()
                {
                    EmailAddress = customer.EmailAddress,
                    CompanyName = customer.CompanyName,
                    CustomerName = $"{customer.Title} {customer.FirstName} {customer.LastName} {customer.Suffix}"
                };
            }

            return default(CustomerShort);
        }
    }
}
