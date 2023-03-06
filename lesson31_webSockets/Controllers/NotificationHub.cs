using HubContracts;
using HubContracts.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.SignalR;

namespace lesson31_webSockets.Controllers
{
    public class NotificationHub : Hub
    {
        private readonly ILogger<HomeController> _logger;
        public NotificationHub(ILogger<HomeController> logger)
        {
            _logger = logger;
        }

        public Task NotifyAll(Notification notification)
        {
            
            return Clients.All.SendAsync(nameof(HubEvent.NewNotification), notification);
        }

    }
}
