using IO.Swagger.Api;


namespace CustomSwagenTest
{
    internal class Program
    {
        static void Main(string[] args)
        {
            var instance = new WeatherForecastApi("https://localhost:7030/");

            var response = instance.GetWeatherForecast();

        }
    }
}