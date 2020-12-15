using System;
using System.Collections.Generic;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using Microsoft.Xaml.Behaviors;

namespace MetaWeather.Windows.UI
{
    /// <summary>
    /// Interaction logic for WeatherForecastView.xaml
    /// </summary>
    public partial class WeatherForecastView : UserControl
    {
        public WeatherForecastView()
        {
            InitializeComponent();
        }

        public WeatherForecastView(IWeatherForecastViewModel viewModel)
        {
            InitializeComponent();

            base.DataContext = viewModel;
        }
    }
}
