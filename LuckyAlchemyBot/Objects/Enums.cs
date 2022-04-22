namespace LuckyAlchemyBot.Objects
{
    public class Enums
    {
        public enum AlchemyAction : byte
        {
            Cancel = 1,
            Fuse = 2,
            SocketCreate = 3, //for Socket
            SocketRemove = 4, //for Socket
        }

        public enum AlchemyType : byte
        {
            Disjoin = 1,
            Manufacture = 2,
            Elixir = 3,
            MagicStone = 4,
            AttributeStone = 5,
            //6?
            //7?
            AdvancedElixirOrSocketCreate = 8,
            SocketInsert = 9,
            SocketRemove = 10, //different alchemyAction
        }

    }
}