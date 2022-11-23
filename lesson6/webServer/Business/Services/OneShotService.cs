using lesson6.Business.Contract.Interfaces;

namespace lesson6.Business.Services
{
    public class OneShotService : IOneShotService
    {
        // public for demonstration
        public readonly IRequestAccontingService _requestAccontingService;
        // public for demonstration
        public readonly IActionService _actionService;

        public static int serviceCounter = 0;
        public int ThisInstanceNumber;

        public OneShotService(IRequestAccontingService requestAccontingService, IActionService actionService)
        {
            ThisInstanceNumber = serviceCounter++;
            _requestAccontingService = requestAccontingService;
            _actionService = actionService;
        }
    }
}
