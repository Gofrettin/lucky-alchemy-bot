using RSBot.Core.Client;
using System.Collections.Generic;

namespace LuckyAlchemyBot.Client.ReferenceObjects
{
    internal class MagicOptionAssignment
    {
        #region Fields

        public byte Race;
        public byte TypeId3;
        public byte TypeId4;
        public List<string> AvailableMagicOptions;

        #endregion Fields

        #region Constructor
        /// <summary>
        /// Parses one line of the magic option assignment reference
        /// </summary>
        /// <param name="parser">The parser</param>
        public MagicOptionAssignment(ReferenceParser parser)
        {
            if (parser == null) return;

            parser.TryParseByte(1, out Race);
            parser.TryParseByte(2, out TypeId3);
            parser.TryParseByte(3, out TypeId4);

            AvailableMagicOptions = new List<string>(80);
            for (var i = 4; i < parser.GetColumnCount(); i++)
            {
                if (parser.TryParseString(i, out var option))
                    AvailableMagicOptions.Add(option);
            }

            AvailableMagicOptions.RemoveAll(m => string.IsNullOrEmpty(m) || m == "xxx");
        }

        #endregion Constructor
    }
}