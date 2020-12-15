using MetaWeather.Common;
using MetaWeather.Windows.UI.Common;
using MetaWeatherApi.Common;
using MetaWeatherApi.Common.Images;
using MetaWeatherApi.Common.Models;
using MetaWeatherApi.Endpoints;
using MetaWeatherApi.Models;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Text;
using System.Windows;

namespace MetaWeather.Windows.UI
{
    public class WeatherForecastViewModel : BindableBase, IWeatherForecastViewModel, IViewModelBase
    {
        private IApiClient ApiClient { get; set; }

        private string _searchLocation;
        public string SearchLocation
        {
            get => _searchLocation;
            set
            {
                SetProperty(ref _searchLocation, value);
                SearchCommand.OnExecuteChanged();
            }
        }

        private ObservableCollection<Location> _locations;
        public ObservableCollection<Location> Locations
        {
            get
            {
                if (_locations == null)
                {
                    _locations = new ObservableCollection<Location>();
                }
                return _locations;
            }
            set
            {
                SetProperty(ref _locations, value);
            }
        }

        private Location _selectedLocation;
        public Location SelectedLocation
        {
            get => _selectedLocation;
            set
            {
                SetProperty(ref _selectedLocation, value);
            }
        }

        private LocationForecast _locationForecast;
        public LocationForecast LocationForecast
        {
            get => _locationForecast;
            set => SetProperty(ref _locationForecast, value);
        }

        public DelegateCommand SearchCommand { get; set; }
        public DelegateCommand LocationSelectedCommand { get; set; }

        public WeatherForecastViewModel(IApiClient apiClient)
        {
            this.ApiClient = apiClient;

            this.SearchCommand = new DelegateCommand(OnSearchLocation, CanSearchLocation);
            this.LocationSelectedCommand = new DelegateCommand(OnLocationSelected, CanGetLocationForecast);
        }

        public void DisplayError(string message)
        {
            MessageBox.Show(
                messageBoxText: message,
                caption: "Error",
                button: MessageBoxButton.OK,
                icon: MessageBoxImage.Error
                );
        }

        public void DisplayError(Exception ex)
        {
            MessageBox.Show(
                messageBoxText: ex.Message,
                caption: "Error",
                button: MessageBoxButton.OK,
                icon: MessageBoxImage.Error
                );
        }

        private async void OnSearchLocation()
        {
            try
            {
                var url = $"{LocationSearchEndpoint.Endpoint}?query={this.SearchLocation}";
                var locations = await this.ApiClient.GetAsync<List<Location>>(url);
                this.Locations = new ObservableCollection<Location>(locations);
            }
            catch (System.Exception ex)
            {
                this.DisplayError(ex);
            }
        }

        private bool CanSearchLocation()
        {
            return !String.IsNullOrWhiteSpace(this.SearchLocation);
        }

        private async void OnLocationSelected()
        {
            try
            {
                var url = $"{LocationEndpoint.Endpoint}{this.SelectedLocation.WhereOnEarthID}";
                var forecast = await this.ApiClient.GetAsync<LocationForecast>(url);
                this.LocationForecast = forecast;
            }
            catch (System.Exception ex)
            {
                this.DisplayError(ex);
            }
        }

        private bool CanGetLocationForecast()
        {
            return this.SelectedLocation != null;
        }
    }
}
