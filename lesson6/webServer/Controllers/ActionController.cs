using lesson6.Business.Contract.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace lesson6.Controllers
{
    [Route("[controller]")]
    public class ActionController : ControllerBase
    {
        private readonly IForeverService _foreverService;
        private readonly IOneShotService _oneShotService;
        private readonly IActionService _actionService;

        public ActionController(
            IForeverService foreverService,
            IActionService actionService,
            IOneShotService oneShotService
            )
        {
            _foreverService = foreverService;
            _oneShotService = oneShotService;
            _actionService = actionService;
        }

        
        public ActionResult Index()
        {
            return Content("hello");
        }
    }
}
