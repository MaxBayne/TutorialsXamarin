using System;
using System.Collections.ObjectModel;
using TutorialsXamarin.Business.Models;
using TutorialsXamarin.ViewModels;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace TutorialsXamarin.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class BindingToObservableCollectionPage : ContentPage
    {
        private readonly PieListViewModel _viewModel;

        public BindingToObservableCollectionPage()
        {
            InitializeComponent();

            _viewModel = new PieListViewModel();
            _viewModel.Pies = new ObservableCollection<Pie>
            {
                new Pie{ Id=100,Name="Pie1",Description="Pie1 Description",Photo="Chrome.png" ,Price=15},
                new Pie{ Id=200,Name="Pie2",Description="Pie2 Description",Photo="iTunes.png",Price=5},
                new Pie{ Id=300,Name="Pie3",Description="Pie3 Description",Photo="Twitter.png",Price=25}
            };

            this.BindingContext = _viewModel;
            lsvPies.ItemsSource = _viewModel.Pies;
        }

        private void btnAddPie_Clicked(object sender, EventArgs e)
        {
            _viewModel.Pies.Add(new Pie { Id=400,Name="Test Pie",Description="Test Desc",Price=11 });
        }

        private void btnSelectPie_Clicked(object sender, EventArgs e)
        {
            var index = new Random().Next(0, _viewModel.Pies.Count);
            _viewModel.SelectedItem = _viewModel.Pies[index];
        }
    }
}