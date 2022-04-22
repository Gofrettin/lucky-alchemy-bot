using LuckyAlchemyBot.Client.ReferenceObjects;
using RSBot.Core.Objects;
using System.Collections.Generic;

namespace LuckyAlchemyBot.Bot
{
    internal class MagicOptionsConfig
    {
        #region Properties

        /// <summary>
        /// Gets or sets the selected item
        /// </summary>
        public InventoryItem Item { get; set; }

        /// <summary>
        /// Gets or sets a dictionary of inventory items and the referenced magic option
        /// </summary>
        public Dictionary<InventoryItem, MagicOption> MagicStones { get; set; }

        #endregion Properties
    }
}