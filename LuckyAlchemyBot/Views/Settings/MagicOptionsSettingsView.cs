using LuckyAlchemyBot.Client.ReferenceObjects;
using RSBot.Core.Event;
using RSBot.Core.Objects;
using RSBot.Core.Objects.Item;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;

namespace LuckyAlchemyBot.Views.Settings
{
    public partial class MagicOptionsSettingsView : UserControl
    {
        private class MagicStoneListViewItemTag
        {
            public InventoryItem Item { get; set; }
            public MagicOption MagicOption { get; set; }

            public MagicOptionInfo MagicOptionInfo { get; set; }
        }

        #region Members

        private bool _reloadConfig;

        #endregion Members

        #region Constructor

        /// <summary>
        /// Subscribes several events
        /// </summary>
        public MagicOptionsSettingsView()
        {
            InitializeComponent();

            EventManager.SubscribeEvent("OnEnterGame", SubscribeMainFormEvents);
        }

        #endregion Constructor

        #region Events
        /// <summary>
        /// Subscribes to the ItemChanged event
        /// </summary>
        private void SubscribeMainFormEvents()
        {
            if (Globals.View != null)
                Globals.View.ItemChanged += View_ItemChanged;
        }

        /// <summary>
        /// Will be triggered when the selected item changed
        /// </summary>
        /// <param name="item"></param>
        private void View_ItemChanged(InventoryItem item)
        {
            PopulateListView();
        }

        /// <summary>
        /// Will be triggered when a list view item was selected
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void lvMagicOptions_ItemChecked(object sender, ItemCheckedEventArgs e)
        {
            ReloadConfig();
        }

        #endregion Events

        #region Methods

        public void PopulateListView()
        {
            if (Globals.View.SelectedItem == null) return;

            lvMagicOptions.BeginUpdate();
            lvMagicOptions.Items.Clear();
            _reloadConfig = false;

            var selectedItem = Globals.View.SelectedItem;
            var assignments = Globals.ReferenceManager.GetAssignments(selectedItem.Record.TypeID3, selectedItem.Record.TypeID4);
            foreach (var assignment in assignments)
            {
                if (assignment == null) continue;
                var matchingItem = Helper.AlchemyItemHelper.GetStoneByGroup(selectedItem, assignment.Group);

                //if (matchingItem == null) continue;

                MagicOptionInfo current = null;
                MagicOption currentRecord = null;
                foreach (var magicOption in selectedItem.MagicOptions)
                {
                    var record = Globals.ReferenceManager.GetMagicOption(magicOption.Id);
                    if (record.Group == assignment.Group)
                    {
                        currentRecord = record;
                        current = magicOption;

                        break;
                    }
                }

                var hasMax = currentRecord != null ? currentRecord.GetMaxValue() == current.Value : false;

                if (hasMax || matchingItem == null)
                    continue;

                var item = new ListViewItem(assignment.GetGroupTranslation());

                if (current == null)
                    item.SubItems.Add("0");
                else
                    item.SubItems.Add(current.Value.ToString());

                item.Tag = new MagicStoneListViewItemTag { Item = matchingItem, MagicOption = currentRecord, MagicOptionInfo = current };
                item.SubItems.Add(Globals.ReferenceManager.GetMagicOption(assignment.Group, (byte)selectedItem.Record.Degree)?.GetMaxValue().ToString());
                item.SubItems.Add($"{matchingItem?.Amount}");

                if (!hasMax && matchingItem != null && Globals.Botbase.MagicOptionsConfig != null && Globals.Botbase.MagicOptionsConfig.MagicStones.Keys.Contains(matchingItem))
                    item.Checked = true;
                else
                    item.Checked = false;

                if (!hasMax && matchingItem != null)
                    item.Font = new Font(Font, FontStyle.Bold);

                lvMagicOptions.Items.Add(item);
            }

            lvMagicOptions.EndUpdate();

            _reloadConfig = true;

            ReloadConfig();
        }

        private void ReloadConfig()
        {
            if (!_reloadConfig) return;

            Globals.Botbase.MagicOptionsConfig = new Bot.MagicOptionsConfig
            {
                Item = Globals.View.SelectedItem,
                MagicStones = new System.Collections.Generic.Dictionary<InventoryItem, MagicOption>()
            };

            foreach (ListViewItem item in lvMagicOptions.CheckedItems)
            {
                var invItem = (MagicStoneListViewItemTag)item.Tag;

                if (invItem != null)
                    Globals.Botbase.MagicOptionsConfig.MagicStones.Add(invItem.Item, invItem.MagicOption);
            }
        }

        #endregion Methods
    }
}