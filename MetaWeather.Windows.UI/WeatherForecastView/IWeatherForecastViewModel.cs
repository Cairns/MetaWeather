using MetaWeather.Common;
using MetaWeatherApi.Common.Models;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Text;

namespace MetaWeather.Windows.UI
{
    public interface IWeatherForecastViewModel
    {
        string SearchLocation { get; set; }
        ObservableCollection<Location> Locations { get; set; }
        Location SelectedLocation { get; set; }
        LocationForecast LocationForecast { get; set; }

        DelegateCommand SearchCommand { get; set; }
        DelegateCommand LocationSelectedCommand { get; set; }
    }
}
