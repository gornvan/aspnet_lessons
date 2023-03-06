using HubContracts.Models;

namespace HubContracts.Constants
{
    public enum Procedure
    {
        NotifyAll,
    }

    public static class ProceduresContract
    {
        public static Dictionary<Procedure, Type> ProcedureToArgumentModel = new Dictionary<Procedure, Type>(
        new KeyValuePair<Procedure, Type>[] {

            new KeyValuePair<Procedure, Type>(Procedure.NotifyAll, typeof(Notification))

        });
    }
}
