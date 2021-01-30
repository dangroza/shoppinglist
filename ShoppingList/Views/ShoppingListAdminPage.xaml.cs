using System;
using Xamarin.Forms;

namespace ShoppingList
{
    public partial class ShoppingListAdminPage : ContentPage
    {
        public ShoppingListAdminPage()
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

        async void OnProductAdded(object sender, EventArgs e)
        {
            await Navigation.PushAsync(new ShoppingListProductPage
            {
                BindingContext = new ShoppingListProduct()
            });
        }

        async void OnProductSelected(object sender, SelectedItemChangedEventArgs e)
        {
            if (e.SelectedItem != null)
            {
                await Navigation.PushAsync(new ShoppingListProductPage
                {
                    BindingContext = e.SelectedItem as ShoppingListProduct
                });
            }
        }
    }
}
