using lesson6.Business.Contract.Interfaces;

namespace lesson6.Business.Services
{
    public class ForeverService : IForeverService
    {
        public static int serviceCounter = 0;
        public int ThisInstanceNumber;

        public ForeverService()
        {
            ThisInstanceNumber = serviceCounter++;
        }

        public void DoEverything()
        {
            
        }
    }
}
