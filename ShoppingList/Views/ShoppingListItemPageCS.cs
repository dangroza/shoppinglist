using Xamarin.Forms;

namespace ShoppingList
{
    public class ShoppingListItemPageCS : ContentPage
    {
        public ShoppingListItemPageCS()
        {
            Title = "ShoppingList Item";

            var nameEntry = new Entry();
            nameEntry.SetBinding(Entry.TextProperty, "Name");

            var descriptionEntry = new Entry();
            descriptionEntry.SetBinding(Entry.TextProperty, "Description");

            var aquiredSwitch = new Switch();
            aquiredSwitch.SetBinding(Switch.IsToggledProperty, "Aquired");

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
                var productItem = (ShoppingListItem)BindingContext;
                await App.Database.DeleteItemAsync(productItem);
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
                    new Label { Text = "Achizitionat" },
                    aquiredSwitch,
                    saveButton,
                    deleteButton,
                    cancelButton
                }
            };
        }
    }
}
