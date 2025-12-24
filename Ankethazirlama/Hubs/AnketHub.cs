using Microsoft.AspNetCore.SignalR;

namespace Ankethazirlama.Hubs
{
    public class AnketHub : Hub
    {
        public async Task SendSurveyUpdate(string message)
        {
            await Clients.All.SendAsync("ReceiveSurveyUpdate", message);
        }
    }
}
