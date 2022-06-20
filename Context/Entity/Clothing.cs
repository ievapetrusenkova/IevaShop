namespace IevaShop.Context.Entity
{
    public class Clothing
    {
        public int Id { get; set; }

        public string Name { get; set; }

        public string Description { get; set; }

        public int Price { get; set; }
        public Category Category { get; set; }

    }
}
