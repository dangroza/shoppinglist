using SQLite;

namespace ShoppingList
{
    public class ShoppingListProduct
    {
        [PrimaryKey, AutoIncrement]
        public int ID { get; set; }
        public int CATEGORY_ID { get; set; }
        public string Name { get; set; }
        public string Type { get; set; }
        public double Price { get; set; }
        public string Description { get; set; }
    }
}

