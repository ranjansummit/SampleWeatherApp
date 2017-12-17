using System;
using Xamarin.Forms;

namespace WeatherForeCasting
{
    public partial class WeatherInfo : ContentPage
    {
        public WeatherInfo()
        {
            InitializeComponent();
            this.Title = "Ranjan's Weather App";
            getWeatherBtn.Clicked += GetWeatherBtn_Clicked;

            //Set the default binding to a default object for now
            this.BindingContext = new Weather();
        }

        private async void GetWeatherBtn_Clicked(object sender, EventArgs e)
        {
            if (!String.IsNullOrEmpty(zipCodeEntry.Text))
            {
                Weather weather = await DataRetrieve.GetWeather(zipCodeEntry.Text);
                if (weather != null)
                {
                    this.BindingContext = weather;
                    getWeatherBtn.Text = "Search Again";
                }
            }
        }
    }
}