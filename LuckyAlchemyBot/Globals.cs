using LuckyAlchemyBot.Client;
using RSBot.Core.Objects;
using System.Collections.Generic;

namespace LuckyAlchemyBot
{
    internal class Globals
    {
        #region Properties

        /// <summary>
        /// Gets or sets the view
        /// </summary>
        /// <value>
        /// The view.
        /// </value>
        public static Views.Main View { get; set; }

        /// <summary>
        /// Gets or sets the reference manager
        /// </summary>
        public static ReferenceManager ReferenceManager { get; set; }

        /// <summary>
        /// Gets or sets the bot base
        /// </summary>
        public static Bot.Botbase Botbase { get; set; }

        /// <summary>
        /// Gets or sets the current alchemy items (like the items in the "window")
        /// </summary>
        public static Dictionary<byte, InventoryItem> AlchemyItems { get; set; }

        #endregion Properties
    }
}