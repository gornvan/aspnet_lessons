// See https://aka.ms/new-console-template for more information

using GreeterGrpcService;
using Grpc.Net.Client;

using var channel = GrpcChannel.ForAddress("https://localhost:7098");
var client = new Greeter.GreeterClient(channel);
var reply = await client.SayHelloAsync(
                  new HelloRequest { Name = "GreeterClient" });


Console.WriteLine("Greeting: " + reply.Message);
Console.WriteLine("Press any key to exit...");
Console.ReadKey(); ;


