namespace SalesApp.ViewModels
{
    using System.Collections.Generic;
    using System.Collections.ObjectModel;
    using Xamarin.Forms;
    using SalesApp.Common.Models;
    using SalesApp.Services;

    public class ProductsViewModel : BaseViewModel
    {
        private readonly ApiServices _apiService;//consume el apiService
        private ObservableCollection<Product> _products;//implementa para q refresque imediatamente
        public ObservableCollection<Product> Products
        {
            get { return this._products; }
            set { this.SetValue(ref this._products, value); }
        }

        public ProductsViewModel()
        {
            this._apiService = new ApiServices();
            this.LoadProducts();
        }

        private async void LoadProducts()
        {
            var url = "https://salesapiservices.azurewebsites.net";
            //var url = "http://localhost:54579";
            var response = await this._apiService.GetList<Product>(url, "/api", "/products");

            if (!response.IsSuccess)
            {
                await Application.Current.MainPage.DisplayAlert("Error", response.Message,"Aceptar");
                return;
            }

            var list = (List<Product>)response.Result;
            this.Products = new ObservableCollection<Product>(list);
        }
    }
}
