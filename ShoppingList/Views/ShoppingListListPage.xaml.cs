using System;
using Xamarin.Forms;

namespace ShoppingList
{
    public partial class ShoppingListListPage : ContentPage
    {
        public ShoppingListListPage()
        {
            InitializeComponent();
        }

        protected override async void OnAppearing()
        {
            base.OnAppearing();

            listView.ItemsSource = await App.Database.GetItemsAsync();
        }

        async void OnItemAdded(object sender, EventArgs e)
        {
            await Navigation.PushAsync(new ShoppingListItemPage
            {
                BindingContext = new ShoppingListItem()
            });
        }

        async void OnListItemSelected(object sender, SelectedItemChangedEventArgs e)
        {
            if (e.SelectedItem != null)
            {
                await Navigation.PushAsync(new ShoppingListItemPage
                {
                    BindingContext = e.SelectedItem as ShoppingListItem
                });
            }
        }
    }
}
