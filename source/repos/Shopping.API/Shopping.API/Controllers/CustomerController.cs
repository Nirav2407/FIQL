using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Linq;
using System;
using Shopping.API.Models;
using RSql4Net.Models.Queries;
using RSql4Net.Models;
using RSql4Net.Controllers;
using RSql4Net.Models.Paging;

namespace Shopping.API.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class CustomerController : Controller
    {
        private readonly CoreDbContext _database;
        
        public CustomerController(CoreDbContext context)
        {
            _database = context;
        }
        
        public IActionResult Index()
        {
            return View();
        }

 
        //[HttpGet]
        //public IActionResult Get([FromQuery] IRSqlQuery<Customer> query,
        //  [FromQuery] IRSqlPageable<Customer> pageable)
        //{
        //    var page = _database.Customer
        //        .AsQueryable()
        //        .Page(pageable, query);

        //    return this.Page(page);
           
        //}

        [HttpGet]
        public IActionResult Get([FromQuery] IRSqlQuery<QuestionResponseDto> query,
          [FromQuery] IRSqlPageable<QuestionResponseDto> pageable)
        {
            var page = (from a in _database.Question join c in _database.QuestionType on a.QuestionTypeId equals c.QuestionTypeId
                        select new QuestionResponseDto { QuestionId = a.QuestionId, 
                             QuestionText = a.QuestionText,
                             QuestionTypeName = c.QuestionTypeName,
                             QuestionTypeCode = c.QuestionTypeCode })
                .AsQueryable()
                .Page(pageable, query);

            return this.Page(page);

        }

    }
}
