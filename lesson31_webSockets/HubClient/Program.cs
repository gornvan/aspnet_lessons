namespace HubClient
{
    internal class Program
    {
        static async Task Main(string[] args)
        {
            await using (var client = new NotificationConsumer())
            {
                await client.StartConnectionAsync();

                client.SubscribeToNewMessage((notification) =>
                {
                    Console.WriteLine($@"Got a new notification: {notification.Text}");
                });

                await client.SendNotificationAsync("MESSAGE FROM CONSOLE CLIENT");


                Console.WriteLine("Success Sending.");

                Console.ReadLine();
            }
        }
    }
}