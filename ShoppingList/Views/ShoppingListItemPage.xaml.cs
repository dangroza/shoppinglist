using System;
using Xamarin.Forms;

namespace ShoppingList
{
    public partial class ShoppingListItemPage : ContentPage
    {
        public ShoppingListItemPage()
        {
            InitializeComponent();
        }

        async void OnSaveClicked(object sender, EventArgs e)
        {
            var todoItem = (ShoppingListItem)BindingContext;
            await App.Database.SaveItemAsync(todoItem);
            await Navigation.PopAsync();
        }

        async void OnDeleteClicked(object sender, EventArgs e)
        {
            var todoItem = (ShoppingListItem)BindingContext;
            await App.Database.DeleteItemAsync(todoItem);
            await Navigation.PopAsync();
        }

        async void OnCancelClicked(object sender, EventArgs e)
        {
            await Navigation.PopAsync();
        }
    }
}
