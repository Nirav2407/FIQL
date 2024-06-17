using Shopping.API.Helper;
using System.Collections.Generic;
using System.Linq;
using System;
using Shopping.API.Models;
using Microsoft.EntityFrameworkCore;
using Shopping.API.Interface;
using System.Linq.Expressions;
using static Microsoft.EntityFrameworkCore.DbLoggerCategory;

namespace Shopping.API.Service
{
    public class CustomerService : ICustomerService
    {
        private readonly CoreDbContext _context;
        private readonly Dictionary<string, string> _propertyMappings;

        public CustomerService(CoreDbContext context)
        {
            _context = context;

            // Define your mappings here
            _propertyMappings = new Dictionary<string, string>
            {
                { "QuestionId", "QuestionId" },
                { "QuestionText", "QuestionText" },
                { "QuestionTypeName", "QuestionType.QuestionTypeName" },
                { "QuestionTypeCode", "QuestionType.QuestionTypeCode" },
              
            };
        }

        public IQueryable<Question> GetFilteredProducts(string fiqlQuery)
        {

            fiqlQuery = "QuestionId=in=(1,3,5),QuestionTypeCode==STB;QuestionTypeCode==DDL";
            //fiqlQuery = "QuestionTypeCode==DDL";
            var expression = CustomFiqlParser.Parse<Question>(fiqlQuery, _propertyMappings);
            
            return _context.Question
                .Include(p => p.QuestionType)
                .Where(expression);

           
        }
       
    }
}
