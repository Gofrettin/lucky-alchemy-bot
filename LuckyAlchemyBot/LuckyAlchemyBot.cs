using LuckyAlchemyBot.Properties;
using LuckyAlchemyBot.Views;
using RSBot.Core;
using RSBot.Core.Event;
using RSBot.Core.Network;
using RSBot.Core.Plugins;
using System.Drawing;
using System.Threading.Tasks;

namespace LuckyAlchemyBot
{
    public class LuckyAlchemyBot : IBotbase
    {
        public static System.Version Version => new System.Version("0.1.0");

        public BotbaseInfo Info => new BotbaseInfo()
        {
            Name = "LuckyAlchemyBot",
            DisplayName = "Lucky Alchemy Bot",
            TabText = "Alchemy",
            Image = Resources.ResourceManager.GetObject("plugin-icon") as Image
        };

        public System.Windows.Forms.Control GetView()
        {
            return Globals.View ?? (Globals.View = new Main());
        }

        public void Initialize()
        {
            PacketManager.RegisterHandler(new Network.Handler.ElixirAckResponseHandler());
            PacketManager.RegisterHandler(new Network.Handler.StoneAckResponseHandler());
            Subscriber.AlchemySubscriber.SubscribeEvents();

            Globals.Botbase = new Bot.Botbase();
            EventManager.SubscribeEvent("OnLoadGameData", OnLoadGameData);

            Log.AppendFormat(LogLevel.Notify, $"[LuckyAlchemyBot] Initialized botbase");
        }

        public void OnLoadGameData()
        {
            Log.AppendFormat(LogLevel.Debug, "[LuckAlchemyBot] Loading magic options...");

            Globals.ReferenceManager = new Client.ReferenceManager();
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
    }
}