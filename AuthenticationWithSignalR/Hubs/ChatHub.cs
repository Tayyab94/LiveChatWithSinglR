using Microsoft.AspNet.SignalR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Web;

namespace AuthenticationWithSignalR.Hubs
{
    public class ChatHub:Hub
    {
        public void JoinRoom(string room)
        {
            Groups.Add(Context.ConnectionId, room);
        }


        //For the private messages to the user  we will somple create the userGroup with his name
        //for this purpose we will working on onConnected Methos
        public override Task OnConnected()
        {
            string userName = Context.User.Identity.Name;
            if (!string.IsNullOrEmpty(userName))
            {
                //we have just create the User group with his or her name for the individual messageing

                Groups.Add(Context.ConnectionId, "users/" + userName); 
            }
            return base.OnConnected();
        }

        //For Individual Message

        public void SendPrivateMessage(string toUsername, string message)
        {
            string fromUser = Context.User.Identity.Name;

            Clients.Group("users/" + toUsername).onNewPrivateMessage(fromUser, message);
        }

        public void NewMessage(string UserName, string Message)
        {
            Clients.Others.sentMessage(UserName, Message, DateTime.Now);
        }

        public void SendMessageToFun(string message, int x, int y)
        {
            Clients.All.receiveNewMessage(message, x, y);
        }

        public void sendMessageToGroup(string room, string message, int x, int y)
        {

            string userName = Context.User.Identity.Name;
            Clients.Group(room).receiveNewGroupMessage(userName,message, x, y);
        }
    }
}