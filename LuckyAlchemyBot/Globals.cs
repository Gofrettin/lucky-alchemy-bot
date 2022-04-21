using LuckyAlchemyBot.Client;

namespace LuckyAlchemyBot
{
    internal class Globals
    {
        /// <summary>
        /// Gets or sets the view.
        /// </summary>
        /// <value>
        /// The view.
        /// </value>
        public static Views.Main View { get; set; }

        public static ReferenceManager ReferenceManager { get; set; }

        public static Bot.Botbase Botbase { get; set; }
    }
}