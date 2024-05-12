using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace WeatherApp.Pages
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class ShowWeather : ContentPage
    {
        public ShowWeather()
        {
            InitializeComponent();            
            ShowContent(); 
        }

        private void ShowContent()
        { 
            var grid = (Grid)ContentGrid;
            grid.Children.Clear();
            
            var insideThermalSensor = new StackLayout { BackgroundColor = Color.FromRgb(255, 201, 00), VerticalOptions = LayoutOptions.Fill, HorizontalOptions = LayoutOptions.Fill };
            insideThermalSensor.Children.Add(new Label { Text = "Inside", FontSize = Device.GetNamedSize(NamedSize.Title, typeof(Label) ), HorizontalOptions = LayoutOptions.Center, VerticalOptions = LayoutOptions.EndAndExpand });
            insideThermalSensor.Children.Add(new Label { Text = "+26 °C", FontSize = Device.GetNamedSize(NamedSize.Header, typeof(Label)), HorizontalOptions = LayoutOptions.Center, VerticalOptions = LayoutOptions.CenterAndExpand });
            grid.Children.Add(insideThermalSensor, 0, 0);

            var outsideThermalSensor = new StackLayout { BackgroundColor = Color.FromRgb(92, 205, 201), VerticalOptions = LayoutOptions.Fill, HorizontalOptions = LayoutOptions.Fill };
            outsideThermalSensor.Children.Add(new Label { Text = "Outside", FontSize = Device.GetNamedSize(NamedSize.Title, typeof(Label)), HorizontalOptions = LayoutOptions.Center, VerticalOptions = LayoutOptions.EndAndExpand });
            outsideThermalSensor.Children.Add(new Label { Text = "-15 °C", FontSize = Device.GetNamedSize(NamedSize.Header, typeof(Label)), HorizontalOptions = LayoutOptions.Center, VerticalOptions = LayoutOptions.CenterAndExpand });
            grid.Children.Add(outsideThermalSensor, 0, 1);

            var pressureSensor = new StackLayout { BackgroundColor = Color.FromRgb(00, 101, 97) };
            pressureSensor.Children.Add(new Label { Text = "Pressure", FontSize = Device.GetNamedSize(NamedSize.Title, typeof(Label)), HorizontalOptions = LayoutOptions.Center, VerticalOptions = LayoutOptions.EndAndExpand });
            pressureSensor.Children.Add(new Label { Text = "760 mm", FontSize = Device.GetNamedSize(NamedSize.Header, typeof(Label)), HorizontalOptions = LayoutOptions.Center, VerticalOptions = LayoutOptions.CenterAndExpand });
            grid.Children.Add(pressureSensor, 0, 2);
        }
    }
}