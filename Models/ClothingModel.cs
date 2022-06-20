namespace IevaShop.Models
{
    public class ClothingModel
    {
        public int Id { get; set; }

        public string Name { get; set; }

        public string Description { get; set; }

        public int Price { get; set; }
        public CategoryModel Category { get; set; }

    }
}
