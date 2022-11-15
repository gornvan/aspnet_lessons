namespace decorator_bonus
{
    public class LoggerFileOutputDecorator : Logger
    {
        private const string logFileName = "log.txt";

        public override void Log(string message)
        {
            File.AppendAllText(logFileName, message);
            base.Log(message);
        }
    }
}
