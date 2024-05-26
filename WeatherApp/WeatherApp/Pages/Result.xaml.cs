using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace WeatherApp.Pages
{
	[XamlCompilation(XamlCompilationOptions.Compile)]
	public partial class Result : ContentPage
	{
		DateTime AlarmDateTime { get; set; }

		public Result (DateTime alarmDateTime)
		{
			InitializeComponent ();
            AlarmDateTime = alarmDateTime;
			ShowTime();
        }

		private void ShowTime()
		{
			var label = (Label)stackLayout.Children.First().FindByName("targetTime");
            // Задаем текст элемента
			label.Text = AlarmDateTime.Day.ToString() + "." + AlarmDateTime.Month.ToString() + "." + AlarmDateTime.Year.ToString() + 
				" в " + AlarmDateTime.Hour.ToString() + ":" + AlarmDateTime.Minute.ToString();
        }

        private async void back_Clicked(object sender, EventArgs e)
        {
            await Navigation.PushAsync(new MainPage());
        }
    }
}