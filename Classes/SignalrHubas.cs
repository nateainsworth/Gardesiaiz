using Microsoft.AspNetCore.SignalR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Gardesiai.Classes
{
    public class SignalrHubas : Hub
    {
        public async Task SendMessage(string user, string message)
        {
            await Clients.All.SendAsync("ReceiveMessage", user, message);
        }

        public void loginUser(String Ref, String password)
        {
            if (DbFunctions.compareRecord("Members", "MemberRef", Ref))
            {
                DbFunctions.sendQuery("INSERT INTO Members (MemberName) VALUES ('chnaged')");
            }
            else
            {
                DbFunctions.sendQuery("INSERT INTO Members (MemberName) VALUES ('nope')");
            }
        }
    }
}
