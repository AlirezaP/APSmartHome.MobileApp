using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

using APSmartHome.Models;
using APSmartHome.Views;
using APSmartHome.ViewModels;

namespace APSmartHome.Views
{
    // Learn more about making custom code visible in the Xamarin.Forms previewer
    // by visiting https://aka.ms/xamarinforms-previewer
    [DesignTimeVisible(false)]
    public partial class ItemsPage : ContentPage
    {
        ItemsViewModel viewModel;
        MainPage RootPage { get => Application.Current.MainPage as MainPage; }

        public ItemsPage()
        {
            InitializeComponent();

            BindingContext = viewModel = new ItemsViewModel();
        }

        async void OnItemSelected(object sender, EventArgs args)
        {
            var layout = (BindableObject)sender;
            var item = (Item)layout.BindingContext;
           // await RootPage.NavigateFromMenu((int)item.IdPage);
            await Navigation.PushAsync(new Home.ParkingPage());
        }

        async void AddItem_Clicked(object sender, EventArgs e)
        {
            await Navigation.PushModalAsync(new NavigationPage(new NewItemPage()));
        }

        protected override void OnAppearing()
        {
            base.OnAppearing();

            if (viewModel.Items.Count == 0)
                viewModel.IsBusy = true;

        }

        private async void ImageButton_Clicked(object sender, EventArgs e)
        {
            await RootPage.NavigateFromMenu((int)MenuItemType.Parking);
        }
    }
}