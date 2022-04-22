using LuckyAlchemyBot.Client.ReferenceObjects;
using RSBot.Core;
using RSBot.Core.Client;
using System;
using System.Collections.Generic;
using System.Linq;
using static RSBot.Core.Log;

namespace LuckyAlchemyBot.Client
{
    internal class ReferenceManager
    {
        #region Constants

        public const string MagicOptionFileName = "magicoption.txt";
        public const string MagicOptionAssignFileName = "magicoptionassign.txt";

        #endregion Constants

        #region Properties

        /// <summary>
        /// Gets the list of magic options
        /// </summary>
        public List<MagicOption> MagicOptions { get; private set; }

        /// <summary>
        /// Gets the list of all magic option assignments
        /// </summary>
        public List<MagicOptionAssignment> MagicOptionAssignments { get; private set; }

        #endregion Properties

        #region Methods

        /// <summary>
        /// Loads the references
        /// </summary>
        public void Load()
        {
            try
            {
                if (!Game.MediaPk2.FileExists(MagicOptionFileName))
                {
                    Error($"[LuckyAlchemyBot] Could not load magic options from {MagicOptionFileName} (file not found)");

                    return;
                }

                if (!Game.MediaPk2.FileExists(MagicOptionAssignFileName))
                {
                    Error($"[LuckyAlchemyBot] Could not load magic option assignments from {MagicOptionAssignFileName} (file not found)");

                    return;
                }

                MagicOptions = new List<MagicOption>();
                MagicOptionAssignments = new List<MagicOptionAssignment>();

                var file = Game.MediaPk2.GetFile(MagicOptionFileName);

                foreach (var line in file.ReadAllText().Split('\n'))
                    MagicOptions.Add(new MagicOption(new ReferenceParser(line)));

                file = Game.MediaPk2.GetFile(MagicOptionAssignFileName);

                foreach (var line in file.ReadAllText().Split('\n'))
                    MagicOptionAssignments.Add(new MagicOptionAssignment(new ReferenceParser(line)));

                Debug($"[LuckyAlchemyBot] Found {MagicOptions.Count} magic options and {MagicOptionAssignments.Count} assignments");
            }
            catch (Exception ex)
            {
                Error($"[LuckyAlchemyBot] Failed to load magicoption.txt: {ex.Message}");
            }
        }

        /// <summary>
        /// Gets a magic option by its id
        /// </summary>
        /// <param name="id">The id of the magic option</param>
        /// <returns></returns>
        public MagicOption GetMagicOption(uint id)
        {
            return MagicOptions?.FirstOrDefault(m => m.Id == id);
        }

        /// <summary>
        /// Gets the first magic option of the specified group
        /// </summary>
        /// <param name="group">The group</param>
        /// <returns></returns>
        public MagicOption GetMagicOption(string group)
        {
            return MagicOptions?.FirstOrDefault(m => m.Group == group);
        }

        /// <summary>
        /// Gets a magic option by its group and degree
        /// </summary>
        /// <param name="group">The group</param>
        /// <param name="degree">The degree</param>
        /// <returns></returns>
        public MagicOption GetMagicOption(string group, byte degree)
        {
            return MagicOptions?.FirstOrDefault(m => m.Group == group && m.Level == degree);
        }

        /// <summary>
        /// Gets a list of magic options for the specified type ids
        /// </summary>
        /// <param name="typeId3">The TID3</param>
        /// <param name="typeId4">The TID4</param>
        /// <returns></returns>
        public List<MagicOption> GetAssignments(byte typeId3, byte typeId4)
        {
            return MagicOptionAssignments.FirstOrDefault(a => a.TypeId3 == typeId3 && a.TypeId4 == typeId4)?.AvailableMagicOptions.Select(GetMagicOption).ToList();
        }

        #endregion Methods
    }
}