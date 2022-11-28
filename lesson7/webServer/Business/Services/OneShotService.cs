using lesson6.Business.Contract.Interfaces;

namespace lesson6.Business.Services
{
    public class OneShotService : ITireService
    {
        // public for demonstration
        public readonly IRequestAccontingService _requestAccontingService;
        // public for demonstration
        public readonly ICarService _actionService;

        public static int serviceCounter = 0;
        public int ThisInstanceNumber;

        public OneShotService(IRequestAccontingService requestAccontingService, ICarService actionService)
        {
            ThisInstanceNumber = serviceCounter++;
            _requestAccontingService = requestAccontingService;
            _actionService = actionService;
        }
    }
}
