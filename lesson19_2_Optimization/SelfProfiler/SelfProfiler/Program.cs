using NBomber.Contracts;
using NBomber.CSharp;
using System.Collections.Specialized;
using System.Diagnostics;
using System.Web;
using static System.Net.WebRequestMethods;

namespace SelfProfiler
{
    internal class Program
    {
        //var addr = "?q=science&btnI=Szczęśliwy traf&hl=pl&source=hp&ei=liPIY-rwNKqurgSzq6boDw&iflsig=AK50M_UAAAAAY8gxpqii_u1C72abA-LIoAjG1kqQk5hF";
        static void Main(string[] args)
        {
            var fulladdr = "https://www.google.com/search?q=science&btnI=Szczęśliwy traf&hl=pl&source=hp&ei=liPIY-rwNKqurgSzq6boDw&iflsig=AK50M_UAAAAAY8gxpqii_u1C72abA-LIoAjG1kqQk5hF";

            var googleSearchHttpClientFactory = ClientFactory.Create(
                name: "http_factory",
                clientCount: 1,
                initClient: (number, context) =>
                {
                    var client = new HttpClient();
                    client.BaseAddress = new Uri("https://www.google.com/search");
                    return Task.FromResult(client);
                }
            );

            var feelLuckyStep = Step.Create(
                "feelLuckyStep",
                clientFactory: googleSearchHttpClientFactory,
                async (context) =>
                {
                    var uriBuilder = new UriBuilder(context.Client.BaseAddress);
                    uriBuilder.Query = "q=science&btnI=Szczęśliwy traf&hl=pl&source=hp&ei=liPIY-rwNKqurgSzq6boDw&iflsig=AK50M_UAAAAAY8gxpqii_u1C72abA-LIoAjG1kqQk5hF";
                    var reqUri = uriBuilder.ToString();

                    var response = await context.Client.GetAsync(reqUri);

                    var bodyStream = await response.Content.ReadAsStringAsync();

                    if (response.StatusCode == System.Net.HttpStatusCode.Redirect)
                    {
                        return Response.Ok();
                    }
                    return Response.Fail();
                }
            );


            var scenario = ScenarioBuilder.CreateScenario("Feel Lucky Google", feelLuckyStep);

            var stats =
                NBomberRunner
                .RegisterScenarios(scenario)
                .Run();


            Console.WriteLine();
        }
    }
}

/*
 * 
 * 
new NameValueCollection()
{
    { "q", "science" },
    { "btnI", "Szczęśliwy traf"},
    { "hl", "pl" },

};
*/