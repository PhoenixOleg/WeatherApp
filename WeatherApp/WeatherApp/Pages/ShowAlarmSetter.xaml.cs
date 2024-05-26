using System;
using System.Collections.Generic;
using System.Globalization;
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
            datePicker.Date = DateTime.Now;
            timePicker.Time = DateTime.Now.TimeOfDay;

            datePicker.DateSelected += (sender, e) => DatePicker_DateSelected(sender, e);
            timePicker.PropertyChanged += (sender, e) => TimePicker_SetTime(sender, e);
        }

        private void DatePicker_DateSelected(object sender, DateChangedEventArgs e)
        {
            DateTimeValidator();
        }

        private void TimePicker_SetTime(object sender, System.ComponentModel.PropertyChangedEventArgs e)
        {
            DateTimeValidator();
        }

        private void DateTimeValidator()
        {           
            if (datePicker.Date < DateTime.Now.Date)
            {
                //Если дата меньше, то время уже не интерсует
                VisualStateManager.GoToState(datePicker, "Invalid");
                Save.IsEnabled = false;
            }
            else
            {
                VisualStateManager.GoToState(datePicker, "Valid");
                
                if (timePicker.Time < DateTime.Now.TimeOfDay)
                {
                    VisualStateManager.GoToState(timePicker, "Invalid");
                    Save.IsEnabled = false;
                }
                else
                {
                    VisualStateManager.GoToState(timePicker, "Valid");
                    Save.IsEnabled = true;
                }
            }
        }

        private void AlarmValueChangedHandler(object sender, ValueChangedEventArgs e, Label sliderText)
        {
            sliderText.Text = e.NewValue.ToString();
        }

        private void saveButton_Clicked(object sender, EventArgs e)
        {
            DateTime dateTime;
            TimeSpan timeSpan;

            dateTime = datePicker.Date;
            timeSpan = timePicker.Time;
            dateTime = dateTime.AddHours(timeSpan.Hours).AddMinutes(timeSpan.Minutes);

            datePicker.IsEnabled = false;
            timePicker.IsEnabled = false;

            result.Text = $"Будильник установлен на: {dateTime.ToString("dd.MM.yyyy HH:mm")}";
        }
    }
}