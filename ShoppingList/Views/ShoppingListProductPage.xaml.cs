using System;
using Xamarin.Forms;

namespace ShoppingList
{
    public partial class ShoppingListProductPage : ContentPage
    {
        public ShoppingListProductPage()
        {
            InitializeComponent();
        }

        async void OnSaveClicked(object sender, EventArgs e)
        {
            var product = (ShoppingListProduct)BindingContext;
            await App.Database.SaveProductAsync(product);
            await Navigation.PopAsync();
        }

        async void OnDeleteClicked(object sender, EventArgs e)
        {
            var product = (ShoppingListProduct)BindingContext;
            await App.Database.DeleteProductAsync(product);
            await Navigation.PopAsync();
        }

        async void OnCancelClicked(object sender, EventArgs e)
        {
            await Navigation.PopAsync();
        }
    }
}
