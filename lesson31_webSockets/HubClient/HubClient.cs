using HubContracts;
using HubContracts.Constants;
using HubContracts.Models;
using Microsoft.AspNetCore.SignalR.Client;

namespace HubClient
{
    public sealed class NotificationConsumer : IAsyncDisposable
    {
        private readonly string HostDomainAndPort = "localhost:7090";

        private HubConnection? _hubConnection;

        public NotificationConsumer()
        {
            _hubConnection = new HubConnectionBuilder()
                .WithUrl(new Uri($"wss://{HostDomainAndPort}/notification"))
                .WithAutomaticReconnect()
                .Build();
        }

        public Task StartConnectionAsync() {
            if (_hubConnection == null)
                throw new NullReferenceException("Connection already down");
            return _hubConnection.StartAsync();
        }

        public Task SendNotificationAsync(string text)
        {
            if (_hubConnection == null)
                throw new NullReferenceException("Connection already down");
            return _hubConnection.InvokeAsync(
                nameof(Procedure.NotifyAll), new Notification(text, DateTime.UtcNow));
        }

        public void SubscribeToNewMessage(Action<Notification> handler)
        {
            if (_hubConnection == null)
                throw new NullReferenceException("Connection already down");
            _hubConnection.On(nameof(HubEvent.NewNotification), handler);
        }
        public void UnsubscribeFromNewMessage()
        {
            if (_hubConnection == null)
                throw new NullReferenceException("Connection already down");
            _hubConnection.Remove(nameof(HubEvent.NewNotification));
        }

        public async ValueTask DisposeAsync()
        {
            if (_hubConnection is not null)
            {
                await _hubConnection.DisposeAsync();
                _hubConnection = null;
            }
        }
    }
}
