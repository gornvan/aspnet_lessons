using lesson6.Business.Contract.Interfaces;

namespace lesson6.Business.Services
{
    public class ActionService : IActionService
    {
        // public for demonstration
        public readonly IRequestAccontingService _requestAccontingService;

        public static int serviceCounter = 0;
        public int thisInstanceNumber;

        public ActionService(IRequestAccontingService requestAccontingService) {
            thisInstanceNumber = serviceCounter++;
            _requestAccontingService = requestAccontingService;
        }
    }
}
