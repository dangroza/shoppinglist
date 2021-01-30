using SQLite;

namespace ShoppingList
{
    public class ShoppingListCategory
    {
        [PrimaryKey, AutoIncrement]
        public int ID { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
    }
}
