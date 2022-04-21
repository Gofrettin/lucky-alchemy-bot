
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

        #endregion

        #region Properties
        public string Group { get; set; }
        
        public uint Id { get; set; }

        public byte Active { get; set; }
        #endregion

        #region Methods

        public static MagicOption Parse(string[] data)
        {
            return new MagicOption()
            {
                Active = byte.Parse(data[0]),
                Id = uint.Parse(data[1]),
                Group = data[2]
            };

        }

        public string GetTranslation(uint value)
        {
            switch (Group)
            {
                case "MATTR_INT":
                case "MATTR_AVATAR_INT":
                case "MATTR_INT_AVATAR":
                    return string.Format("Int {0} Increase", value);
                case "MATTR_STR":
                case "MATTR_STR_AVATAR":
                case "MATTR_AVATAR_STR":
                    return string.Format("Str {0} Increase", value);
                case "MATTR_DUR":
                case "MATTR_AVATAR_DRUA":
                    return string.Format("Durability {0}% Increase", value);
                case "MATTR_EVADE_BLOCK":
                    return string.Format("Blocking rate {0}", value);      
                case "MATTR_AVATAR_DARA":
                    return string.Format("Damage Absorption {0}% Increase", value);
                case "MATTR_AVATAR_ER":
                case "MATTR_ER":
                    return string.Format("Parry rate {0}% Increase", value);
                case "MATTR_HR":
                case "MATTR_AVATAR_HR":
                    return string.Format("Attack rate {0}% Increase", value);
                case "MATTR_RESIST_FROSTBITE":
                    return string.Format("Freezing,FrostbiteHour {0}% Reduce", value);
                case "MATTR_RESIST_ESHOCK":
                    return string.Format("Electrict shockHour {0}% Reduce", value);
                case "MATTR_RESIST_BURN":
                    return string.Format("BurnHour {0}% Reduce", value);
                case "MATTR_RESIST_POISON":
                    return string.Format("PoisoningHour {0}% Reduce", value);     
                case "MATTR_LUCK":
                    return string.Format("Lucky({0}Time/times)", value);
                case "MATTR_SOLID":
                    return string.Format("Steady({0}Time/times)", value);;
                case "MATTR_ASTRAL":
                    return string.Format("Astral({0}Time/times)", value);
                case "MATTR_ATHANASIA":
                    return string.Format("Immportal({0}Time/times)", value);
                case "MATTR_AVATAR_MDIA":
                case "MATTR_AVATAR_MDIA_2":
                case "MATTR_AVATAR_MDIA_3":
                case "MATTR_AVATAR_MDIA_4":
                    return string.Format("Ignore Monster Defense {0}% Probability", value);
                case "MATTR_HP":
                case "MATTR_AVATAR_HP":
                    return string.Format("HP {0} Increase", value);
                case "MATTR_MP":
                case "MATTR_AVATAR_MP":
                    return string.Format("MP {0} Increase", value);
                case "MATTR_CRITICAL":
                    return string.Format("Critical {0}", value);
                case "MATTR_NOT_REPARABLE":
                    return string.Format("Not repairable", value);
                case "MATTR_REGENHPMP":
                    return string.Format("HP recovery/MP recovery {0}% Increase", value);
                case "MATTR_RESIST_ZOMBIE":
                    return string.Format("ZombieHour {0}% Reduce", value);
                case "MATTR_RESIST_CSMP":
                    return string.Format("CombustionProbability {0}% Reduce", value);
                case "MATTR_RESIST_SLEEP":
                    return string.Format("SleepProbability {0}% Reduce", value);
                case "MATTR_RESIST_STUN":
                    return string.Format("StunProbability {0}% Reduce", value);
                case "MATTR_RESIST_FEAR":
                    return string.Format("FearProbability {0}% Reduce", value);
                case "MATTR_RESIST_DISEASE":
                    return string.Format("DiseaseProbability {0}% Reduce", value);
                case "MATTR_DEC_MAXDUR":
                    return string.Format("Maximum durability {0}% Reduce", value);

            }
            return Group;
        }
        #endregion
    }
}
