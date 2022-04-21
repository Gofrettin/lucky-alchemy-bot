using LuckyAlchemyBot.Client.ReferenceObjects;
using System;
using System.Collections.Generic;
using System.Linq;

namespace LuckyAlchemyBot.Client
{
    internal class ReferenceManager
    {
        public List<MagicOption> MagicOptions { get; set; }

        public void Load()
        {
            try
            {
                if (!RSBot.Core.Game.MediaPk2.FileExists("magicoption.txt"))
                {
                    RSBot.Core.Log.Error("[LuckyAlchemyBot] Could not load magic options from magicoptions.txt (file not found)");

                    return;
                }

                MagicOptions = new List<MagicOption>();

                var file = RSBot.Core.Game.MediaPk2.GetFile("magicoption.txt");

                foreach (var line in file.ReadAllText().Split('\n'))
                    MagicOptions.Add(MagicOption.Parse(line.Split('\t')));

                RSBot.Core.Log.Debug($"[LuckyAlchemyBot] Found {MagicOptions.Count} magic options.");
            } catch(Exception ex) {

                RSBot.Core.Log.Error($"[LuckyAlchemyBot] Failed to load magicoption.txt: {ex.Message}");
            }

        }

        public MagicOption GetMagicOption(uint id)
        {
            return MagicOptions?.FirstOrDefault(m => m.Id == id);
        }
    }
}