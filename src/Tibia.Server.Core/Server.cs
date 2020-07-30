using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Net;
using System.Net.Sockets;
using Tibia.Server.Core.Properties;
using Tibia.Server.Core.Scripting;
using Tibia.Server.Core.Util;

namespace Tibia.Server.Core
{
    public class Server
    {
        static void Main(string[] args)
        {
            new Server().Run();
        }

        Game _game;

        readonly TcpListener _clientLoginListener = new TcpListener(IPAddress.Any, 7171);
        readonly TcpListener _clientGameListener = new TcpListener(IPAddress.Any, 7172);

        readonly List<Connection> _connections = new List<Connection>();

        static int _startTimeInMillis = 0;
        static int _startTextLength = 0;

        void Run()
        {
            _game = new Game();

            try
            {
                LogStart("Initializing database");
                Database.Initialize(Settings.Default.DatabaseFile);
                LogDone();

                LogStart("Loading items");
                ItemInfo.LoadItemsOtb(Settings.Default.ItemsOtbFile);
                ItemInfo.LoadItemsXml(Settings.Default.ItemsXmlFile);
                LogDone();

                LogStart("Loading map");
                _game.Map.Load();
                LogDone();

                LogStart("Loading scripts");
                string errors = ScriptManager.LoadAllScripts(_game);
                LogDone();

                if (errors.Length > 0)
                {
                    Log("There were errors when compiling scripts:\n\n" + errors);
                }

                LogStart("Listening for clients");
                _clientLoginListener.Start();
                _clientLoginListener.BeginAcceptSocket(LoginListenerCallback, _clientLoginListener);
                _clientGameListener.Start();
                _clientGameListener.BeginAcceptSocket(GameListenerCallback, _clientGameListener);
                LogDone();
            }
            catch (Exception e)
            {
                LogError(e.ToString());
                if (Debugger.IsAttached)
                {
                    throw;
                }
            }

            while (true)
            {
                bool exit = false;
                string line = Console.ReadLine();
                switch (line.ToLower())
                {
                    case "exit":
                        exit = true;
                        break;
                    case "reloadscripts":
                        ScriptManager.ReloadAllScripts(_game);
                        break;
                }
                if (exit) break;
            }
            _connections.ForEach(c => c.Close());
            _clientGameListener.Stop();
            _clientLoginListener.Stop();
        }

        public static void LogStart(string text)
        {
            string s = String.Format("{0}: {1}...", DateTime.Now, text);
            Console.Write(s);
            _startTextLength = s.Length;
            _startTimeInMillis = System.Environment.TickCount;
        }

        public static void LogDone()
        {
            int elapsed = System.Environment.TickCount - _startTimeInMillis;
            string done = "Done";
            string doneTime = "";

            if (elapsed < 1000)
            {
                doneTime = $"({elapsed} ms)";
            }
            else
            {
                doneTime = $"({elapsed / 1000.0:0.00} s)";
            }

            Console.Write(".".Repeat(Console.WindowWidth - _startTextLength - done.Length - 12));
            Console.ForegroundColor = ConsoleColor.Green;
            Console.Write(done);
            Console.ResetColor();
            Console.Write(" ".Repeat(11 - doneTime.Length));
            Console.Write(doneTime);
            Console.WriteLine();
        }

        public static void LogError(string errorText)
        {
            string error = "Error";
            Console.Write(".".Repeat(Console.WindowWidth - _startTextLength - error.Length - 12));
            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine(error);
            Console.ResetColor();
            Console.WriteLine(errorText);
        }

        public static void Log(string text, params object[] args)
        {
            Console.WriteLine("{0}: {1}", DateTime.Now, String.Format(text, args));
        }

        private void LoginListenerCallback(IAsyncResult ar)
        {
            Connection connection = new Connection(_game);
            connection.LoginListenerCallback(ar);
            _connections.Add(connection);

            _clientLoginListener.BeginAcceptSocket(new AsyncCallback(LoginListenerCallback), _clientLoginListener);
            Log("New client connected to login server.");
        }

        private void GameListenerCallback(IAsyncResult ar)
        {
            Connection connection = new Connection(_game);
            connection.GameListenerCallback(ar);
            _connections.Add(connection);

            _clientGameListener.BeginAcceptSocket(new AsyncCallback(GameListenerCallback), _clientGameListener);
            Log("New client connected to game server.");
        }
    }
}
