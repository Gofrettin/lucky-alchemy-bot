using LuckyAlchemyBot;
using RSBot.Core;
using RSBot.Core.Event;
using RSBot.Core.Objects;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;

namespace LuckAlchemyBot.Views.Settings
{
    public partial class EnhanceSettingsView : UserControl
    {
        internal class ElixirComboboxItem
        {
            public InventoryItem Item { get; set; }

            public ElixirComboboxItem(InventoryItem item)
            {
                Item = item;
            }

            public override string ToString()
            {
                return $"{Item.Amount}x {Item.Record.GetRealName()}";
            }
        }

        private InventoryItem _selectedItem;

        #region Constructor

        public EnhanceSettingsView()
        {
            InitializeComponent();

            EventManager.SubscribeEvent("OnEnterGame", SubscribeMainFormEvents);
        }

        #endregion Constructor

        private void SubscribeMainFormEvents()
        {
            if (Globals.View != null)
                Globals.View.ItemChanged += View_ItemChanged;
        }

        #region Methods

        private void PopulateView()
        {
            if (Globals.View == null || Globals.View.SelectedItem == null)
            {
                Enabled = false;

                return;
            }

            lblCurrentOptLevel.Text = _selectedItem == null ? "+0" : $"+{Game.Player.Inventory.GetItemAt(_selectedItem.Slot)?.OptLevel}";
            if (_selectedItem != null && _selectedItem.Slot == Globals.View.SelectedItem.Slot)
                return;

            var selectedItem = Globals.View.SelectedItem;

            _selectedItem = selectedItem;
            if (selectedItem.OptLevel > 4)
                numMaxEnhancement.Value = selectedItem.OptLevel + 1;
            else
                numMaxEnhancement.Value = 5;

            var type = LuckyAlchemyBot.Helper.AlchemyItemHelper.ElixirType.Unspecified;

            var accessorryTypeId3 = new byte[] { 5, 12 };
            var armorTypeId3 = new byte[] { 1, 2, 3, 9, 10, 11 };

            if (selectedItem.Record.TypeID3 == 4 && selectedItem.Record.TypeID2 == 1)
                type = LuckyAlchemyBot.Helper.AlchemyItemHelper.ElixirType.Shield;

            if (selectedItem.Record.TypeID3 == 6 && selectedItem.Record.TypeID2 == 1)
                type = LuckyAlchemyBot.Helper.AlchemyItemHelper.ElixirType.Weapon;

            if (accessorryTypeId3.Contains(selectedItem.Record.TypeID3) && selectedItem.Record.TypeID2 == 1)
                type = LuckyAlchemyBot.Helper.AlchemyItemHelper.ElixirType.Accessory;

            if (armorTypeId3.Contains(selectedItem.Record.TypeID3) && selectedItem.Record.TypeID2 == 1)
                type = LuckyAlchemyBot.Helper.AlchemyItemHelper.ElixirType.Protector;

            List<InventoryItem> matchingElixirs = LuckyAlchemyBot.Helper.AlchemyItemHelper.GetElixirItems(type);

            comboElixir.Items.Clear();

            foreach (var item in matchingElixirs)
                comboElixir.Items.Add(new ElixirComboboxItem(item));

            if (comboElixir.Items.Count > 0)
                comboElixir.SelectedIndex = 0;

            var luckyPowders = LuckyAlchemyBot.Helper.AlchemyItemHelper.GetLuckyPowder(selectedItem);
            lblLuckyPowderCount.Text = luckyPowders == null ? "x0" : $"x{luckyPowders.Amount}";

            var luckyStones = LuckyAlchemyBot.Helper.AlchemyItemHelper.GetLuckyStone(selectedItem);
            checkUseLuckyStones.Enabled = luckyStones != null && luckyStones.Amount > 0;
            lblLuckyCount.Text = luckyStones == null ? "x0" : $"x{luckyStones.Amount}";

            var astralStones = LuckyAlchemyBot.Helper.AlchemyItemHelper.GetAstralStone(selectedItem);
            checkUseAstralStones.Enabled = astralStones != null && astralStones.Amount > 0;
            lblAstralCount.Text = astralStones == null ? "x0" : $"x{astralStones.Amount}";

            var immortalStones = LuckyAlchemyBot.Helper.AlchemyItemHelper.GetImmortalStone(selectedItem);
            checkUseImmortalStones.Enabled = immortalStones != null && immortalStones.Amount > 0;
            lblImmortalCount.Text = immortalStones == null ? "x0" : $"x{immortalStones.Amount}";

            var steadyStones = LuckyAlchemyBot.Helper.AlchemyItemHelper.GetSteadyStone(selectedItem);
            checkUseSteadyStones.Enabled = steadyStones != null && steadyStones.Amount > 0;
            lblSteadyStonesCount.Text = steadyStones == null ? "x0" : $"x{steadyStones.Amount}";

            Enabled = true;
        }

        #endregion Methods

        #region Events

        private void linkRefreshItemList_Click(object sender, System.EventArgs e)
        {
            PopulateView();
        }

        private void View_ItemChanged(InventoryItem item)
        {
            PopulateView();
        }

        #endregion Events

        private void config_CheckedChange(object sender, System.EventArgs e)
        {
            if (Globals.Botbase == null)
                return;

            Globals.Botbase.EnhancementConfig = new LuckyAlchemyBot.Bot.EnhancementConfig
            {
                Item = Globals.View.SelectedItem,
                UseAstralStones = checkUseAstralStones.Checked,
                UseLuckyStones = checkUseLuckyStones.Checked,
                UseImmortalStones = checkUseImmortalStones.Checked,
                UseSteadyStones = checkUseSteadyStones.Checked,
                Elixir = (comboElixir.SelectedItem as ElixirComboboxItem)?.Item,
                MaxOptLevel = (byte)numMaxEnhancement.Value,
                StopIfLuckyPowderEmpty = checkStopLuckyPowder.Checked
            };
        }
    }
}