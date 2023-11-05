using System.Windows.Input;

namespace MahUIApp
{
    public partial class MainPage : ContentPage
    {
        int count = 0;

        public MainPage()
        {
            InitializeComponent();

            ICommand buttonCommand = new Command(() =>
            {
                // Handle the command execution (e.g., navigate to another page)
                DisplayAlert("Button Clicked", "The button was clicked!", "OK");
            });

            tButton.Command = buttonCommand;
            tButton2.Command = buttonCommand;
        }
    }
}