using ODataService.Models;
using System.Web.Http.OData;

namespace webapi_OData.Controllers
{
    public class odataController : ODataController
    {
        private List<Product> products = new List<Product>()
        {
            new Product()
            {
                Id = 1,
                Name = "Bread",
            }
        };

        public List<Product> Get()
        {
            return products;
        }
    }
}
