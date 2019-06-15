namespace Check1.Domain
{
    using Check1.Domain.Enums;

    public class Item
    {
        public int Id { get; set; }

        public string Name { get; set; }

        public ItemSize Size { get; set; }

        public ItemColor Color { get; set; }

        public ItemType Type { get; set; }
    }
}