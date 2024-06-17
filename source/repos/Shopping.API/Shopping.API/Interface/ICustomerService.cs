using Shopping.API.Models;
using System.Linq;

namespace Shopping.API.Interface
{
    public interface ICustomerService
    {
        IQueryable<Question> GetFilteredProducts(string fiqlQuery);
    }
}
