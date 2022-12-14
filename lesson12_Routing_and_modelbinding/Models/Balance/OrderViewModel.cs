using lesson12_routing.Models._ModelBinders;
using Microsoft.AspNetCore.Mvc;

namespace lesson12_routing.Models.Balance
{
    public class OrderViewModel
    {
        public string? Good { get; set; }

        public int? Amount { get; set; }

        public string? Address { get; set; }

        public string? Text { get; set; }


        [ModelBinder(typeof(CustomModelBinder))]
        public string? Base64EncodedText { get; set; }
    }
}
