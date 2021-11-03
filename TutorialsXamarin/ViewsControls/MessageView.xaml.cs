using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace TutorialsXamarin.ViewsControls
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class MessageView : ContentView
    {
        
        public string Message { get; set; }

        public MessageView()
        {
            InitializeComponent();
        }
    }
}