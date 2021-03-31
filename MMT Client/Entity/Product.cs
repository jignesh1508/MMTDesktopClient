namespace MMT_Client.Entity
{
    public class Product
    {
        public int SKU { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public decimal Price { get; set; }

        public Category Category { get; set; }
    }
}
