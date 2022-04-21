using RSBot.Core;
using RSBot.Core.Event;
using RSBot.Core.Objects;
using System;
using System.Windows.Forms;

namespace LuckyAlchemyBot.Views
{
    public partial class Main : UserControl
    {
        public delegate void SelectedItemChanged(InventoryItem item);

        public event SelectedItemChanged ItemChanged;

        internal class InventoryItemComboboxItem
        {
            public InventoryItem InventoryItem { get; set; }

            public InventoryItemComboboxItem(InventoryItem inventoryItem)
            {
                InventoryItem = inventoryItem;
            }

            public override string ToString() => $"[{InventoryItem.Slot}] {InventoryItem.Record.GetRealName()} (+{InventoryItem.OptLevel})";
 
        }

        public InventoryItem SelectedItem { get; set; }

        public Main()
        {
            InitializeComponent();

            lblCopyright.Text = $"LuckyAlchemyBot v{LuckyAlchemyBot.Version} © 2022 wimbeam";

            EventManager.SubscribeEvent("OnLoadCharacter", ReloadItemList);
            EventManager.SubscribeEvent("OnElixirAlchemy", ReloadItemList);
            EventManager.SubscribeEvent("OnStoneAlchemy", ReloadItemList);
        }

        #region Methods

        private void ReloadItemList()
        {
            comboItem.Items.Clear();

            var items = Game.Player.Inventory.GetItems(new TypeIdFilter() { TypeID1 = 3, TypeID2 = 1, CompareByTypeID2 = true });

            items.ForEach((item) =>
            {
                var newComboItem = new InventoryItemComboboxItem(item);

                if (item.Slot > 12)
                    comboItem.Items.Add(newComboItem);

                if (SelectedItem != null && item.Slot == SelectedItem.Slot)
                    comboItem.SelectedItem = newComboItem;
            });
        }

        #endregion Methods

        #region Events

        private void linkRefreshItemList_Click(object sender, EventArgs e)
        {
            ReloadItemList();
        }

        private void comboItem_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (comboItem.SelectedIndex < 0) return;

            var selectedItem = (InventoryItemComboboxItem)comboItem.Items[comboItem.SelectedIndex];

            SelectedItem = selectedItem.InventoryItem;
            listMagicOptions.Items.Clear();

            if (SelectedItem.MagicOptions != null)
                foreach (var magicOption in SelectedItem.MagicOptions)
                {
                    var option = Globals.ReferenceManager.GetMagicOption(magicOption.Id);
                    listMagicOptions.Items.Add(option.GetTranslation(magicOption.Value));
                }

            lblDegree.Text = SelectedItem.Record.Degree.ToString();
            lblEnhancement.Text = $"+{SelectedItem.OptLevel}";
            ItemChanged?.Invoke(SelectedItem);
        }

        private void radioEngine_CheckedChanged(object sender, EventArgs e)
        {
            if (radioEnhance.Checked)
                ReloadEngine(Bot.Engine.Enhancement);

            if (radioAttribute.Checked)
                ReloadEngine(Bot.Engine.Attribute);

            if (radioMagicOptions.Checked)
                ReloadEngine(Bot.Engine.Magic);
        }

        private void ReloadEngine(Bot.Engine engine)
        {
            if (Globals.Botbase != null)
                Globals.Botbase.Engine = engine;

            if (engine == Bot.Engine.Enhancement)
            {
                enhanceSettingsView.Show();
            }
        }

        public void AddLog(string itemName, bool success, string message)
        {
            var item = new ListViewItem(itemName);

            item.SubItems.Add(success ? "Success" : "Fail");
            item.SubItems.Add(message);

            lvLog.Items.Add(item);
            //Scroll to bottom of the list
            lvLog.Items[lvLog.Items.Count - 1].EnsureVisible();
        }

        #endregion Events
    }
}