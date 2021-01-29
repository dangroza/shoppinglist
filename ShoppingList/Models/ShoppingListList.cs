using SQLite;

namespace ShoppingList
{
    public class ShoppingListList
    {
        [PrimaryKey, AutoIncrement]
        public int ID { get; set; }
        public string Name { get; set; }
        public string Notes { get; set; }
        public bool Completed { get; set; }
    }
}

