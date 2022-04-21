using RSBot.Core;

namespace LuckyAlchemyBot.Bot
{
    internal class Botbase
    {
        public Engine Engine { get; set; }

        public EnhancementConfig EnhancementConfig { get; set; }

        public Enhancer Enhancer { get;  private set; }

        public MagicOptionGranter MagicOptionGranter { get; set; }

        public Botbase()
        {
            Enhancer = new Enhancer();
            MagicOptionGranter = new MagicOptionGranter();
        }

        public void Start()
        {
            if (Engine == Engine.Enhancement)
            { 
                if (EnhancementConfig == null)
                {
                    Log.Warn("[LuckyAlchemyBot] Configuration issue detected!");

                    Kernel.Bot.Stop();

                    return;
                }

                Enhancer.Start();
            }

            if (Engine == Engine.Magic)
            {

            }
        }

        public void Stop()
        {
            if (Engine == Engine.Enhancement && Enhancer != null)
                Enhancer.Stop();

        }

        public void Tick()
        {
            switch (Engine)

            {
                case Engine.Enhancement:
                    if (EnhancementConfig == null || Enhancer == null)
                    {
                        Log.Warn("[LuckyAlchemyBot] Configuration issue detected!");

                        Kernel.Bot.Stop();
                    }

                    Enhancer.Run(EnhancementConfig);

                    break;
            }
        }
    }

    internal enum Engine
    {
        Enhancement,
        Magic,
        Attribute
    }
}