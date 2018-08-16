using SalesApp.Common.Models;
using SalesApp.Services;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using Xamarin.Forms;

namespace SalesApp.ViewModels
{
    public class ProductsViewModel:BaseViewModel
    {
        private ApiServices apiService;//consume el apiService
        private ObservableCollection<Product> _products;//implementa para q refresque imediatamente
        public ObservableCollection<Product> Products
        {
            get { return this._products; }
            set { this.SetValue(ref this._products, value); }
        }

        public ProductsViewModel()
        {
            this.apiService = new ApiServices();
            this.LoadProducts();
        }

        private async void LoadProducts()
        {
            var url = "https://salesapiservices.azurewebsites.net";
            //var url = "http://localhost:54579";
            var response = await this.apiService.GetList<Product>(url, "/api", "/products");

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
