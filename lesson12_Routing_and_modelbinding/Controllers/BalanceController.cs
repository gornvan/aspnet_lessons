using lesson12_routing.Models.Balance;
using Microsoft.AspNetCore.Mvc;

namespace lesson12_routing.Controllers
{
    public class BalanceController : Controller
    {
        static int balance = 5000;

        static List<OrderViewModel> orders = new List<OrderViewModel>();

        public IActionResult PlaceOrderView()
        {
            return View();
        }

        [ValidateAntiForgeryToken]
        public IActionResult PlaceOrderSubmit(OrderViewModel order)
        {
            orders.Add(order);
            return Redirect("/");
        }
    }
}
