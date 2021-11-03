using TutorialsXamarin.Common.Models;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace TutorialsXamarin.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class DataBindingPage : ContentPage
    {
        public DataBindingPage()
        {
            InitializeComponent();

            //Make DataBinding With Code ----------------------------

            //Source Binding
            Pie applePie = new Pie()
            {
                Id = 200,
                Name = "Apple Pie",
                Price = 50,
                Description = "Perfect Pie"
            };

            //Define Binding
            Binding descriptionbinding = new Binding
            {
                Source = applePie,          //Source Data Object
                Path = "Description",       //Source Property
                Mode = BindingMode.Default  //Binding Mode
            };
            

            //Target Binding
            TxtDescription.SetBinding(Entry.TextProperty, descriptionbinding);


            //For Binding Used By XAML
            StackFormData.BindingContext = applePie;
        }
    }
}