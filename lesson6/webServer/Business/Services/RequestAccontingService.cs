using lesson6.Business.Contract.Interfaces;

namespace lesson6.Business.Services
{
    public class RequestAccontingService : IRequestAccontingService
    {
        public static int serviceCounter = 0;
        public int ThisInstanceNumber;

        public RequestAccontingService()
        {
            ThisInstanceNumber = serviceCounter++;
        }
    }
}
