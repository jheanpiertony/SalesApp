namespace SalesApp.ViewModels
{
    using System.Collections.Generic;
    using System.Collections.ObjectModel;
    using Xamarin.Forms;
    using SalesApp.Common.Models;
    using SalesApp.Services;
    using System.Windows.Input;
    using GalaSoft.MvvmLight.Command;

    public class ProductsViewModel : BaseViewModel
    {
        #region Campos
        private readonly ApiServices _apiService;//consume el apiService encangardo de las comunicaciones
        private ObservableCollection<Product> _products;//implementa para q refresque inmediatamente
        private bool _isRefreshing;

        #endregion

        public ICommand RefreshCommand
        {
            get
            {
                return new RelayCommand(LoadProducts);
            }
        }

        public bool IsRefreshing
        {
            get { return this._isRefreshing; }
            set { this.SetValue(ref this._isRefreshing, value); }
        }
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
            this.IsRefreshing = true;
            var connection = await this._apiService.CheckConnection();

            if (!connection.IsSuccess)
            {
                this.IsRefreshing = false;
                await Application.Current.MainPage.DisplayAlert("Error", connection.Message, "Accept");
                return;
            }

            var url = Application.Current.Resources["UrlAPI"].ToString();
            var response = await this._apiService.GetList<Product>(url, "/api", "/products");

            if (!response.IsSuccess)
            {
                this.IsRefreshing = false;
                await Application.Current.MainPage.DisplayAlert("Error", response.Message,"Accept");
                return;
            }

            var list = (List<Product>)response.Result;
            this.Products = new ObservableCollection<Product>(list);
            this.IsRefreshing = false;
        }
    }
}
