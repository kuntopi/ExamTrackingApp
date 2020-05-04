using ExamTrackingApp.Models;
using Microsoft.AspNetCore.SignalR;
using System;
using System.Threading.Tasks;

namespace UniversityApp.Hubs
{
    public class ChatHub : Hub
    {
        public async Task SendMessage(IspitSignalR isp)
        {

            await Clients.All.SendAsync("ReceiveMessage", isp);
        }
    }
}