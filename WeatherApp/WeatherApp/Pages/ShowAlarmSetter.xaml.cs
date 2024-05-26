using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.PlatformConfiguration.iOSSpecific;
using Xamarin.Forms.Xaml;

namespace WeatherApp.Pages
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class ShowAlarmSetter : ContentPage
    {
        public ShowAlarmSetter()
        {
            InitializeComponent();
            VisualContent();
        }

        private void VisualContent()
            {
            var slider = (Xamarin.Forms.Slider)Content.FindByName("slider");
            var sliderText = (Label)Content.FindByName("sliderText");

            slider.ValueChanged += (sender, e) => AlarmValueChangedHandler(sender, e, sliderText);
        }

        private void AlarmValueChangedHandler(object sender, ValueChangedEventArgs e, Label sliderText)
        {
            sliderText.Text = e.NewValue.ToString();
        }

        private async void saveButton_Clicked(object sender, EventArgs e)
        {
            DateTime dateTime = DateTime.Now;
            TimeSpan timeSpan;

            var datePicker = (Xamarin.Forms.DatePicker)Content.FindByName("datePicker");
            var timePicker = (Xamarin.Forms.TimePicker)Content.FindByName("timePicker");
           
            if (datePicker != null && timePicker != null)
            {
                dateTime = datePicker.Date;
                timeSpan = timePicker.Time;
                dateTime = dateTime.AddHours(timeSpan.Hours).AddMinutes(timeSpan.Minutes);

                await Navigation.PushAsync(new Result(dateTime));
            }
            else
            {
               await DisplayAlert("Ошибка", "Не найден виджет даты или времени", "Ok");
            }                       
        }
    }
}