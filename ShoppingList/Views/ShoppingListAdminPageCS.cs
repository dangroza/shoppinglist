using Xamarin.Forms;

namespace ShoppingList
{
    public class ShoppingListAdminPageCS : ContentPage
    {
        ListView productListView;
        public ShoppingListAdminPageCS()
        {
            Title = "ShoppingList: Admin";

            var nameEntry = new Entry();
            nameEntry.SetBinding(Entry.TextProperty, "Name");

            var descriptionEntry = new Entry();
            descriptionEntry.SetBinding(Entry.TextProperty, "Description");

            var priceEntry = new Entry();
            priceEntry.SetBinding(Entry.TextProperty, "Price");

            var saveButton = new Button { Text = "Salveaza" };
            saveButton.Clicked += async (sender, e) =>
            {
                var productItem = (ShoppingListItem)BindingContext;
                await App.Database.SaveItemAsync(productItem);
                await Navigation.PopAsync();
            };

            var deleteButton = new Button { Text = "Sterge" };
            deleteButton.Clicked += async (sender, e) =>
            {
                var productItem = (ShoppingListProduct)BindingContext;
                await App.Database.DeleteProductAsync(productItem);
                await Navigation.PopAsync();
            };

            var cancelButton = new Button { Text = "Anuleaza" };
            cancelButton.Clicked += async (sender, e) =>
            {
                await Navigation.PopAsync();
            };

            Content = new StackLayout
            {
                Margin = new Thickness(20),
                VerticalOptions = LayoutOptions.StartAndExpand,
                Children =
                {
                    new Label { Text = "Nume" },
                    nameEntry,
                    new Label { Text = "Descriere" },
                    descriptionEntry,
                    new Label { Text = "Pret" },
                    priceEntry,
                    saveButton,
                    deleteButton,
                    cancelButton
                }
            };
        }
    }
}
