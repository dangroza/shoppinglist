using Xamarin.Forms;
using Xamarin.Forms.Xaml;

[assembly: XamlCompilation(XamlCompilationOptions.Compile)]
namespace ShoppingList
{
    public partial class App : Application
    {
        static ShoppingListItemDatabase database;

        public App()
        {
            InitializeComponent();

            var nav = new NavigationPage(new ShoppingListListPage());
            nav.BarBackgroundColor = (Color)App.Current.Resources["blue"];
            nav.BarTextColor = Color.White;

            MainPage = nav;
        }

        public static ShoppingListItemDatabase Database
        {
            get
            {
                if (database == null)
                {
                    database = new ShoppingListItemDatabase();
                }
                return database;
            }
        }

        protected override void OnStart()
        {

        }

        protected override void OnSleep()
        {

        }

        protected override void OnResume()
        {

        }
    }
}

