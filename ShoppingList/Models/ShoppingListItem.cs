using SQLite;

namespace ShoppingList
{
    public class ShoppingListItem
    {
        [PrimaryKey, AutoIncrement]
        public int ID { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public bool Aquired { get; set; }
    }
}

