using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace lesson13_Security.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CarsController : ControllerBase
    {
        private readonly TireServiceDBContext _dbContext;

        const string SearchForCarsQuery_Vuln = "select * from Cars where Cars.Make like '%{0}%'";
        const string SearchForCarsQuery = "select * from Cars where Cars.Make like '%'+ @MakeSearch +'%'";

        public CarsController(TireServiceDBContext dbContext) {
            _dbContext = dbContext;
        }
        

        [HttpGet]
        [Route("vulterable")]
        public ActionResult Get_Vulnerable(int? id = null, string? searchMake = null)
        {
            var query = string.Format(SearchForCarsQuery, searchMake); // VULNERABILITY

            query = $"select * from Cars where Cars.Make like '%{searchMake}%'";

            var request = _dbContext.Cars.FromSqlRaw(query);

            var results = request.ToList();

            return new JsonResult(results);
        }

        [HttpGet]
        public ActionResult Get(int? id = null, string? searchMake = null)
        {
            //using (var command = _dbContext.Database.GetDbConnection().CreateCommand())
            //{
            //    command.CommandText = SearchForCarsQuery;

            //    var searchMakeParam = command.CreateParameter();
            //    searchMakeParam.ParameterName = "MakeSearch";
            //    searchMakeParam.Value = searchMake;

            //    command.Connection.Open();

            //    using (var reader = command.ExecuteReader())
            //    {
            //        var val = reader.GetTextReader(0).ReadToEnd();
            //    }
            //}



            FormattableString query = $"select * from Cars where Cars.Make like '%' + {searchMake} + '%'";

            var dbsetBasedResult = _dbContext.Cars.FromSql(
                query
                )
                .ToList();


            return new JsonResult(dbsetBasedResult);
        }
    }
}
