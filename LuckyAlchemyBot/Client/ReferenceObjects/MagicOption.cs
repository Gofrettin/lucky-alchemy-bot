using RSBot.Core;
using RSBot.Core.Client;
using System;
using System.Collections.Generic;

namespace LuckyAlchemyBot.Client.ReferenceObjects
{
    public class MagicOption
    {
        #region Constants

        public const string MaterialLuck = "MATTR_LUCK";
        public const string MaterialStr = "MATTR_STR";
        public const string MaterialInt = "MATTR_INT";
        public const string MaterialSteady = "MATTR_SOLID";
        public const string MaterialHP = "MATTR_HP";
        public const string MaterialMP = "MATTR_MP";
        public const string MaterialAstral = "MATTR_ASTRAL";
        public const string MaterialImmortal = "MATTR_ATHANASIA";
        public const string MaterialDurability = "MATTR_DUR";
        public const string MaterialBlockRate = "MATTR_BLOCKRATE";
        public const string MaterialCritical = "MATTR_CRITICAL";
        public const string MaterialParryRate = "MATTR_ER"; //evasion rate
        public const string MaterialAttackRate = "MATTR_HR"; //hit rate
        public const string MaterialResistStun = "MATTR_RESIST_STUN";
        public const string MaterialResistZombie = "MATTR_RESIST_ZOMBIE";
        public const string MaterialResistPoison = "MATTR_RESIST_POISON";
        public const string MaterialResistBurn = "MATTR_RESIST_BURN";
        public const string MaterialResistElectroShock = "MATTR_RESIST_ESHOCK";
        public const string MaterialResistFrostbite = "MATTR_RESIST_FROSTBYTE";
        public const string MaterialResistDisease = "MATTR_RESIST_DISEASE";
        public const string MaterialResistSleep = "MATTR_RESIST_SLEEP";
        public const string MaterialResistFear = "MATTR_RESIST_FEAR";
        public const string MaterialResistCombustion = "MATTR_RESIST_CSMP";

        #endregion Constants

        #region Fields

        public string Group;
        public uint Id;
        public bool Active;
        public string AvailabilityGroup1;
        public string AvailabilityGroup2;
        public string AvailabilityGroup3;
        public string AvailabilityGroup4;

        public List<ushort> AvailableValues;

        public byte Level;

        #endregion Properties

        #region Methods

        /// <summary>
        /// Parses the line of the MagicOption reference
        /// </summary>
        /// <param name="parser">The parser</param>
        public MagicOption(ReferenceParser parser)
        {
            if (parser == null) return;

            AvailableValues = new List<ushort>(8);
            parser.TryParseBool(0, out Active);
            parser.TryParseUInt(1, out Id);
            parser.TryParseString(2, out Group);
            parser.TryParseByte(4, out Level);

            //param1 = name of the attribute
            /*
            *
            * 		var x = 1635018849;
		            var buffer = BitConverter.GetBytes(x);
		            var name = System.Text.Encoding.ASCII.GetString(buffer.Reverse().ToArray());
			        Console.WriteLine(name); //atha

             */

            for (var i = 8; i < 11; i++)
            {
                parser.TryParseUInt(i, out var paramVal);
                var param = GetAvailableValues(paramVal);

                AvailableValues.Add(param.Item1);
                AvailableValues.Add(param.Item2);
            }

            parser.TryParseString(28, out AvailabilityGroup1);
            parser.TryParseString(30, out AvailabilityGroup2);
            parser.TryParseString(32, out AvailabilityGroup3);
            parser.TryParseString(34, out AvailabilityGroup4);
        }

        /// <summary>
        /// Returns the maximum possible value for this magic attribute
        /// </summary>
        /// <returns>The maximum value</returns>
        public ushort GetMaxValue()
        {
            if (AvailableValues == null) return 0;

            ushort highest = 0;

            foreach (var value in AvailableValues)
            {
                if (value > highest)
                    highest = value;
            }

            return highest;
        }

        /// <summary>
        /// Returns all available values this magic attribute can possibly have
        /// </summary>
        /// <param name="value"></param>
        /// <returns>The from and to value</returns>
        private Tuple<ushort, ushort> GetAvailableValues(uint value)
        {
            var toValue = (ushort)(value >> 16);
            var fromValue = (ushort)(value & 0xffff);

            return new Tuple<ushort, ushort>(fromValue, toValue);
        }

        /// <summary>
        /// Returns the translation of the group
        /// </summary>
        /// <returns></returns>
        public string GetGroupTranslation()
        {
            var translationGroup = Group.Replace("MATTR", "PARAM");

            switch (translationGroup)
            {
                case "PARAM_RESIST_FROSTBITE":
                    translationGroup = "PARAM_COLD_RESIST";
                    break;

                case "PARAM_RESIST_ZOMBIE":
                    translationGroup = "PARAM_ZOMBI_RESIST";
                    break;

                case "PARAM_RESIST_BURN":
                    translationGroup = "PARAM_BURN_RESIST";
                    break;

                case "PARAM_RESIST_ESHOCK":
                    translationGroup = "PARAM_ESHOCK_RESIST";
                    break;

                case "PARAM_RESIST_POISON":
                    translationGroup = "PARAM_POISON_RESIST";
                    break;

                case "PARAM_EVADE_BLOCK":
                    translationGroup = "PARAM_IGNORE_BLOCKING";
                    break;
            }
            return Game.ReferenceManager.GetTranslation(translationGroup);
        }

        /// <summary>
        /// Returns the translation used when the fusion succeeded
        /// </summary>
        /// <param name="value">The value used in the formatted string</param>
        /// <returns>The translated string</returns>
        public string GetFusingTranslation(uint value)
        {
            //TODO: Use and extend GetGroupTranslation instead of hard coding this
            switch (Group)
            {
                case "MATTR_INT":
                case "MATTR_AVATAR_INT":
                case "MATTR_INT_AVATAR":
                    return $"Int {value} Increase";

                case "MATTR_STR":
                case "MATTR_STR_AVATAR":
                case "MATTR_AVATAR_STR":
                    return $"Str {value} Increase";

                case "MATTR_DUR":
                case "MATTR_AVATAR_DRUA":
                    return $"Durability {value}% Increase";

                case "MATTR_EVADE_BLOCK":
                    return $"Blocking rate {value}";

                case "MATTR_AVATAR_DARA":
                    return $"Damage Absorption {value}% Increase";

                case "MATTR_AVATAR_ER":
                case "MATTR_ER":
                    return $"Parry rate {value}% Increase";

                case "MATTR_HR":
                case "MATTR_AVATAR_HR":
                    return $"Attack rate {value}% Increase";

                case "MATTR_RESIST_FROSTBITE":
                    return $"Freezing,FrostbiteHour {value}% Reduce";

                case "MATTR_RESIST_ESHOCK":
                    return $"Electrict shockHour {value}% Reduce";

                case "MATTR_RESIST_BURN":
                    return $"BurnHour {value}% Reduce";

                case "MATTR_RESIST_POISON":
                    return $"PoisoningHour {value}% Reduce";

                case "MATTR_LUCK":
                    return $"Lucky({value}Time/times)";

                case "MATTR_SOLID":
                    return $"Steady({value}Time/times)"; ;
                case "MATTR_ASTRAL":
                    return $"Astral({value}Time/times)";

                case "MATTR_ATHANASIA":
                    return $"Immortal({value}Time/times)";

                case "MATTR_AVATAR_MDIA":
                case "MATTR_AVATAR_MDIA_2":
                case "MATTR_AVATAR_MDIA_3":
                case "MATTR_AVATAR_MDIA_4":
                    return $"Ignore Monster Defense {value}% Probability";

                case "MATTR_HP":
                case "MATTR_AVATAR_HP":
                    return $"HP {value} Increase";

                case "MATTR_MP":
                case "MATTR_AVATAR_MP":
                    return $"MP {value} Increase";

                case "MATTR_CRITICAL":
                    return $"Critical {value}";

                case "MATTR_NOT_REPARABLE":
                    return "Not repairable";

                case "MATTR_REGENHPMP":
                    return $"HP recovery/MP recovery {value}% Increase";

                case "MATTR_RESIST_ZOMBIE":
                    return $"ZombieHour {value}% Reduce";

                case "MATTR_RESIST_CSMP":
                    return $"CombustionProbability {value}% Reduce";

                case "MATTR_RESIST_SLEEP":
                    return $"SleepProbability {value}% Reduce";

                case "MATTR_RESIST_STUN":
                    return $"StunProbability {value}% Reduce";

                case "MATTR_RESIST_FEAR":
                    return $"FearProbability {value}% Reduce";

                case "MATTR_RESIST_DISEASE":
                    return $"DiseaseProbability {value}% Reduce";

                case "MATTR_DEC_MAXDUR":
                    return $"Maximum durability {value}% Reduce";
            }
            return Group;
        }

        #endregion Methods
    }
}