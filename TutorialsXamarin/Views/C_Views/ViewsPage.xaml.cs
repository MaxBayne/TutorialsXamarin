using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace TutorialsXamarin.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class ViewsPage : ContentPage
    {
        public ViewsPage()
        {
            InitializeComponent();

            //Load Image From Internet inside ImageView
            img_uri.Source = new UriImageSource()
            {
                Uri = new Uri("https://cdn.pixabay.com/photo/2015/04/19/08/32/marguerite-729510_960_720.jpg"),
                CachingEnabled = true, //Cache image in memory after load first time and each time we call it we will load it from cache
                CacheValidity = TimeSpan.FromHours(2)
            };


            img_Resource.Source = ImageSource.FromResource("TutorialsXamarin.Images.flowers.jpg");
            
        }

        private async void btn_DisplayAlert_Clicked(object sender, EventArgs e)
        {
            await DisplayAlert("Title", "All Configuration Saved", "Ok");
        }

        private async void btn_DisplayAlertAsConfirm_Clicked(object sender, EventArgs e)
        {
            var result = await DisplayAlert("Title", "Are you Sure Remove this Record ?", "Ok","Cancel",FlowDirection.LeftToRight);

            if (result)
                await DisplayAlert("Message","You Click Ok","ok");
            else
                await DisplayAlert("Message", "You Click Cancel", "ok");
        }

        private  async void btn_DisplayActionSheet_Clicked(object sender, EventArgs e)
        {
            var result = await DisplayActionSheet("ActionSheet", "cancel", "ok", "C#", "VB", "Java", "Kotlen","Parel","C","C++","Assemply");

            await DisplayAlert("", result, "ok");
        }

        
        private async void btn_DisplayPrompt_Clicked(object sender, EventArgs e)
        {
            var result = await DisplayPromptAsync("Prompt", "Input Your Name", "ok", "cancel", "Name Here", 10, Keyboard.Plain,"");
        }

        private async void btn_ListView_Clicked(object sender, EventArgs e)
        {
            await Navigation.PushAsync(new ListViewPage());
        }

        private async void btn_ListViewCourses_Clicked(object sender, EventArgs e)
        {
            await Navigation.PushAsync(new ListViewCoursesPage());
        }

        private async void btn_CollectionView_Clicked(object sender, EventArgs e)
        {
            await Navigation.PushAsync(new CollectionViewPage());
        }

        private async void BtnTableView_OnClicked(object sender, EventArgs e)
        {
            await Navigation.PushAsync(new TableViewPage());
        }
    }
}