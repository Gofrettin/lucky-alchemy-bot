using RSBot.Core;
using RSBot.Core.Event;
using RSBot.Core.Objects;
using System;

namespace LuckyAlchemyBot.Bot
{
    internal class MagicOptionGranter
    {
        #region Constructor

        public MagicOptionGranter()
        {
            SubscribeEvents();
        }

        #endregion Constructor

        #region Methods

        private void SubscribeEvents()
        {
            EventManager.SubscribeEvent("OnStoneAlchemyDestroyed", new Action<byte>(OnAlchemyDestroyed));
            EventManager.SubscribeEvent("OnStoneAlchemySuccess", new Action<InventoryItem>(OnAlchemySuccess));
            EventManager.SubscribeEvent("OnStoneAlchemyFailed", new Action<InventoryItem>(OnAlchemyFailed));
        }

        private static void OnAlchemySuccess(InventoryItem newItem)
        {
            if (newItem.MagicOptions.Count == 0) return;

            var magicOption = newItem.MagicOptions[newItem.MagicOptions.Count - 1];

            if (magicOption == null) return;

            var record = Globals.ReferenceManager.GetMagicOption(magicOption.Id);

            //UIIT_MSG_ALCHEMY_CHANGE_CATTR
            var message = Game.ReferenceManager.GetTranslation("UIIT_MSG_ALCHEMY_CHANGE_CATTR").FormatJoymaxTranslation(newItem.Record.GetRealName(), record.Group, magicOption.Value);
            Globals.View.AddLog(newItem.Record.GetRealName(), true, message);
        }

        private static void OnAlchemyDestroyed(byte slot)
        {
        }

        private static void OnAlchemyFailed(InventoryItem newItem)
        {
        }

        #endregion Methods
    }
}