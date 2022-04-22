using LuckyAlchemyBot.Bot;
using LuckyAlchemyBot.Client;
using LuckyAlchemyBot.Network.Handler;
using LuckyAlchemyBot.Properties;
using LuckyAlchemyBot.Subscriber;
using LuckyAlchemyBot.Views;
using RSBot.Core;
using RSBot.Core.Event;
using RSBot.Core.Network;
using RSBot.Core.Plugins;
using System;
using System.Drawing;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace LuckyAlchemyBot
{
    public class LuckyAlchemyBot : IBotbase
    {
        #region Properties

        public static Version Version => new Version("0.1.0");

        public BotbaseInfo Info => new BotbaseInfo()
        {
            Name = "LuckyAlchemyBot",
            DisplayName = "Lucky Alchemy Bot",
            TabText = "Alchemy",
            Image = Resources.ResourceManager.GetObject("plugin-icon") as Image
        };

        #endregion Properties

        #region Methods

        public Control GetView()
        {
            return Globals.View ?? (Globals.View = new Main());
        }

        public void Initialize()
        {
            PacketManager.RegisterHandler(new ElixirAckResponseHandler());
            PacketManager.RegisterHandler(new StoneAckResponseHandler());
            PacketManager.RegisterHandler(new ElixirRequestHandler());
            PacketManager.RegisterHandler(new StoneRequestHandler());
            PacketManager.RegisterHandler(new MaterialRequestHandler());
            PacketManager.RegisterHandler(new SocketRequestHandler());

            AlchemySubscriber.SubscribeEvents();

            Globals.Botbase = new Botbase();
            EventManager.SubscribeEvent("OnLoadGameData", OnLoadGameData);

            Log.AppendFormat(LogLevel.Notify, $"[LuckyAlchemyBot] Initialized botbase");
        }

        public void OnLoadGameData()
        {
            Log.AppendFormat(LogLevel.Debug, "[LuckAlchemyBot] Loading magic options...");

            Globals.ReferenceManager = new ReferenceManager();
            Task.Run(() => Globals.ReferenceManager.Load());
        }

        public void Start()
        {
            if (Globals.Botbase != null)
                Globals.Botbase.Start();

            Log.AppendFormat(LogLevel.Debug, $"[LuckyAlchemyBot] Starting automated alchemy...");
        }

        public void Stop()
        {
            if (Globals.Botbase != null)
                Globals.Botbase.Stop();

            Log.AppendFormat(LogLevel.Debug, $"[LuckyAlchemyBot] Stopped automated alchemy");
        }

        public void Tick()
        {
            if (Globals.Botbase != null)
                Globals.Botbase.Tick();
        }

        public void Translate()
        {
            LanguageManager.Translate(GetView(), Kernel.Language);
        }

        #endregion Methods
    }
}