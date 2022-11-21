# IO.Swagger.Api.WeatherForecastApi

All URIs are relative to */*

Method | HTTP request | Description
------------- | ------------- | -------------
[**GetWeatherForecast**](WeatherForecastApi.md#getweatherforecast) | **GET** /WeatherForecast | 
[**WeatherForecastPost**](WeatherForecastApi.md#weatherforecastpost) | **POST** /WeatherForecast | 

<a name="getweatherforecast"></a>
# **GetWeatherForecast**
> List<WeatherForecast> GetWeatherForecast ()



### Example
```csharp
using System;
using System.Diagnostics;
using IO.Swagger.Api;
using IO.Swagger.Client;
using IO.Swagger.Model;

namespace Example
{
    public class GetWeatherForecastExample
    {
        public void main()
        {
            var apiInstance = new WeatherForecastApi();

            try
            {
                List&lt;WeatherForecast&gt; result = apiInstance.GetWeatherForecast();
                Debug.WriteLine(result);
            }
            catch (Exception e)
            {
                Debug.Print("Exception when calling WeatherForecastApi.GetWeatherForecast: " + e.Message );
            }
        }
    }
}
```

### Parameters
This endpoint does not need any parameter.

### Return type

[**List<WeatherForecast>**](WeatherForecast.md)

### Authorization

No authorization required

### HTTP request headers

 - **Content-Type**: Not defined
 - **Accept**: text/plain, application/json, text/json

[[Back to top]](#) [[Back to API list]](../README.md#documentation-for-api-endpoints) [[Back to Model list]](../README.md#documentation-for-models) [[Back to README]](../README.md)
<a name="weatherforecastpost"></a>
# **WeatherForecastPost**
> WeatherQueryModel WeatherForecastPost (WeatherQueryModel body = null)



### Example
```csharp
using System;
using System.Diagnostics;
using IO.Swagger.Api;
using IO.Swagger.Client;
using IO.Swagger.Model;

namespace Example
{
    public class WeatherForecastPostExample
    {
        public void main()
        {
            var apiInstance = new WeatherForecastApi();
            var body = new WeatherQueryModel(); // WeatherQueryModel |  (optional) 

            try
            {
                WeatherQueryModel result = apiInstance.WeatherForecastPost(body);
                Debug.WriteLine(result);
            }
            catch (Exception e)
            {
                Debug.Print("Exception when calling WeatherForecastApi.WeatherForecastPost: " + e.Message );
            }
        }
    }
}
```

### Parameters

Name | Type | Description  | Notes
------------- | ------------- | ------------- | -------------
 **body** | [**WeatherQueryModel**](WeatherQueryModel.md)|  | [optional] 

### Return type

[**WeatherQueryModel**](WeatherQueryModel.md)

### Authorization

No authorization required

### HTTP request headers

 - **Content-Type**: application/json, text/json, application/_*+json
 - **Accept**: text/plain, application/json, text/json

[[Back to top]](#) [[Back to API list]](../README.md#documentation-for-api-endpoints) [[Back to Model list]](../README.md#documentation-for-models) [[Back to README]](../README.md)
