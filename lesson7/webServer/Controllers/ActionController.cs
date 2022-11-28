using lesson6.Business.Contract.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace lesson6.Controllers
{
    [Route("[controller]")]
    public class ActionController : ControllerBase
    {
        private readonly IForeverService _foreverService;
        private readonly ITireService _oneShotService;
        private readonly ICarService _actionService;

        public ActionController(
            IForeverService foreverService,
            ICarService actionService,
            ITireService oneShotService
            )
        {
            _foreverService = foreverService;
            _oneShotService = oneShotService;
            _actionService = actionService;
        }


        [HttpGet]
        public ActionResult Index()
        {
            return Content("hello");
        }
    }
}
