using Microsoft.AspNetCore.Mvc;
using Shopping.API.Interface;
using Shopping.API.Service;
using System.Linq;

namespace Shopping.API.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class QuestionController : Controller
    {
        
        private readonly ICustomerService _productService;

        public QuestionController(ICustomerService productService)
        {
            _productService = productService;
        }

        [HttpGet]
        public IActionResult Get([FromQuery] string query)
        {            
            
            
            var products = _productService.GetFilteredProducts(query).ToList();
            return Ok(products);
        }
    }
}