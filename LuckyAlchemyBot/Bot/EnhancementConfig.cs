using RSBot.Core.Objects;

namespace LuckyAlchemyBot.Bot
{
    internal class EnhancementConfig
    {
        public byte MaxOptLevel { get; set; }
        public InventoryItem Item { get; set; }
    
        public bool StopIfLuckyPowderEmpty { get; set; }

        public bool UseImmortalStones { get; set; }

        public bool UseAstralStones { get; set; }

        public bool UseSteadyStones { get; set; }

        public bool UseLuckyStones { get; set; }

        public InventoryItem Elixir { get; set; }
    }
}
