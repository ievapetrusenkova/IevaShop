namespace IevaShop.Context.Entity
{
    public class Category
    {
        public int Id { get; set; }

        public string Name { get; set; }

        public List<Clothing> AllClothings { get; set; }

    }
}
