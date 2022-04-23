using LuckyAlchemyBot.Bot;

using LuckyAlchemyBot.Properties;
using LuckyAlchemyBot.Views;
using RSBot.Core;
using RSBot.Core.Plugins;
using System;
using System.Drawing;
using System.Windows.Forms;
using LuckyAlchemyBot.Subscriber;

namespace LuckyAlchemyBot
{
    public class LuckyAlchemyBot : IBotbase
    {
        #region Properties

        public static string Name => "LuckyAlchemyBot";

        public static bool IsActive => Kernel.Bot != null && Kernel.Bot.Running && Kernel.Bot.Botbase.Info.Name == Name;

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
            AlchemyEventsSubscriber.Subscribe();
            Globals.Botbase = new Botbase();

            Log.AppendFormat(LogLevel.Notify, $"[LuckyAlchemyBot] Initialized botbase");
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