using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Microsoft.AspNet.SignalR;
using System.Collections.Concurrent;
using Models;
using MazeLib;
using Newtonsoft.Json.Linq;

namespace Controllers
{
    public class MultiHub : Hub
    {
        private static ConcurrentDictionary<string, string> connectUsers = new ConcurrentDictionary<string, string>();
        private static MazeModel model = new MazeModel();
        private static Dictionary<string, ICommand> commands;
        public MultiHub()
        {
            try
            {
                model.AddHub(this);
                commands = new Dictionary<string, ICommand>();
                commands.Add("start", new StartCommand(model));
                commands.Add("list", new ListCommand(model));
                commands.Add("join", new JoinCommand(model));
                commands.Add("play", new PlayCommand(model));
                commands.Add("close", new CloseCommand(model));
            }
            catch { }

        }
        public void connect(string username)
        {
            connectUsers[username] = Context.ConnectionId;
        }
        public void sendMessageToClient(string username, string msg)
        {
            string userId = connectUsers[username];
            if (userId == null)
                return;

            Clients.Client(userId).gotMessage(msg);
        }
        public void sendMazeToClient(string username, Maze msg)
        {
            string userId = connectUsers[username];
            if (userId == null)
                return;
            JObject ans = JObject.Parse(msg.ToJSON());
            Clients.Client(userId).gotMazeMessage(ans);
        }
        public void getMessageFromClient(string username, string commandLine)
        {
            string[] arr = commandLine.Split(' ');
            string commandKey = arr[0];
            if (!commands.ContainsKey(commandKey))
            {
                sendMessageToClient(username, "error");
            }
            string[] args = arr.Skip(1).ToArray();
            ICommand command = commands[commandKey];
            string ans = command.Execute(args, username);
            sendMessageToClient(username, ans);
        }
    }
}