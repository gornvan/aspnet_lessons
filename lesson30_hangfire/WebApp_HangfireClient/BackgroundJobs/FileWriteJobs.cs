namespace lesson30_hangfire.BackgroundJobs
{
    public static class FileWriteJobs
    {
        public static async Task WriteHello()
        {
            var msg = "Hello";
            using (var writer = File.CreateText("./file.txt"))
            {
                await writer.WriteAsync(msg);
            }
        }
    }
}
