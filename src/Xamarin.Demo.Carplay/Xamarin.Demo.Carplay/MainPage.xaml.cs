using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MediaManager;
using Xamarin.Forms;

namespace Xamarin.Demo.Carplay
{
    // Learn more about making custom code visible in the Xamarin.Forms previewer
    // by visiting https://aka.ms/xamarinforms-previewer
    [DesignTimeVisible(false)]
    public partial class MainPage : ContentPage
    {
        public MainPage()
        {
            InitializeComponent();
        }

        protected override async void OnAppearing()
        {
            base.OnAppearing();

            await PlayPauseAsync();
        }

        async void Button_Clicked(System.Object sender, System.EventArgs e)
        {
            await PlayPauseAsync();
        }

        private async Task PlayPauseAsync()
        {
            if (CrossMediaManager.Current.IsPlaying())
            {
                ButtonPlayPause.Text = "Play";
                await CrossMediaManager.Current.Pause();
            }
            else
            {
                ButtonPlayPause.Text = "Pause";
                string url = @"http://www.rockantenne.de/webradio/channels/heavy-metal.aac.pls";
                await CrossMediaManager.Current.Play(url);

            }
        }
    }
}
