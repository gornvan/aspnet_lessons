using lesson12_routing.Models.Balance;
using Microsoft.AspNetCore.Mvc.ModelBinding;
using Microsoft.AspNetCore.WebUtilities;
using System.Buffers.Text;
using System.Reflection;
using System.Text;

namespace lesson12_routing.Models._ModelBinders
{
    // encode Text property and set Base64EncodedText
    public class CustomModelBinder : IModelBinder
    {
        public async Task BindModelAsync(ModelBindingContext bindingContext)
        {
            var textvalue = bindingContext.ValueProvider.GetValue("Text").ToString();

            var base64Text = Convert.ToBase64String((new UTF8Encoding()).GetBytes(textvalue));

            bindingContext.ModelState.SetModelValue("Base64EncodedText", (object)base64Text, textvalue);

            bindingContext.Result = ModelBindingResult.Success(base64Text);

            /*
             * 
             todo: figure out how to fetch the whole body:


            var httpReq = bindingContext.ActionContext.HttpContext.Request;
            var bodyStream = httpReq.Body;
            httpReq.EnableBuffering();
            bodyStream.Position = 0;

            var reader = new StreamReader(bodyStream);

            var data = await reader.ReadToEndAsync();

            var modelName = bindingContext.ModelName;

            var valueProviderResult = bindingContext.ValueProvider.GetValue(modelName);

            bindingContext.ModelState.SetModelValue(modelName, valueProviderResult);
            */

        }
    }
}
