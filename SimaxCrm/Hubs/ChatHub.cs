using Microsoft.AspNetCore.SignalR;
using Newtonsoft.Json;
using System;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;

namespace SimaxCrm.Hubs
{
    public class ChatHub : Hub
    {
        private readonly static ConnectionMapping<string> _connections =
            new ConnectionMapping<string>();

        public override Task OnConnectedAsync()
        {
            var objUser = getUserDTOFromClaim();

            _connections.Add(JsonConvert.SerializeObject(objUser), Context.ConnectionId);

            Clients.All.SendAsync("OnAllUsers", _connections.GetAllConnections());

            return base.OnConnectedAsync();
        }

        public override Task OnDisconnectedAsync(Exception exception)
        {
            var objUser = getUserDTOFromClaim();

            _connections.Remove(JsonConvert.SerializeObject(objUser), Context.ConnectionId);

            Clients.All.SendAsync("OnAllUsers", _connections.GetAllConnections());

            return base.OnDisconnectedAsync(exception);
        }
       


        [HubMethodName("SendMessageToUser")]
        public Task SendMessage(string user, string message)
        {
            return Clients.All.SendAsync("OnReceiveMessage", user, message);
        }

        [HubMethodName("AllUsers")]
        public Task AllUsers()
        {
            return Clients.All.SendAsync("OnAllUsers", _connections.GetAllConnections());
        }

        [HubMethodName("CallInvite")]
        public Task CallInvite(string toConnectionId, string id, bool isVideo)
        {
            var objUser = getUserDTOFromClaim();
            var data = _connections.GetAllConnections().FirstOrDefault(m => m.Key == JsonConvert.SerializeObject(objUser));
            foreach (var conId in toConnectionId.Split(','))
            {
                Clients.Client(conId).SendAsync("OnCallInvite", data, id, isVideo);
            }
            return Task.CompletedTask;
        }

        [HubMethodName("CallReject")]
        public Task CallReject(string toConnectionId)
        {
            var objUser = getUserDTOFromClaim();
            var data = _connections.GetAllConnections().FirstOrDefault(m => m.Key == JsonConvert.SerializeObject(objUser));
            foreach (var conId in toConnectionId.Split(','))
            {
                Clients.Client(conId).SendAsync("OnCallReject", data);
            }
            return Task.CompletedTask;
        }

        [HubMethodName("CallAccepted")]
        public Task CallAccepted(string toConnectionId, string callId)
        {
            var objUser = getUserDTOFromClaim();
            var data = _connections.GetAllConnections().FirstOrDefault(m => m.Key == JsonConvert.SerializeObject(objUser));
            foreach (var conId in toConnectionId.Split(','))
            {
                Clients.Client(conId).SendAsync("OnCallAccepted", data, callId);
            }
            return Task.CompletedTask;
        }

        public SignalRUserDTO getUserDTOFromClaim()
        {
            var objId = Context.User.Claims.Where(c => c.Type == ClaimTypes.NameIdentifier).FirstOrDefault().Value;
            var objName = Context.User.Identity.Name;
            return new SignalRUserDTO
            {
                Name = objName,
                Id = Guid.Parse(objId)
            };
        }
    }

    public class SignalRUserDTO
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
    }

}
