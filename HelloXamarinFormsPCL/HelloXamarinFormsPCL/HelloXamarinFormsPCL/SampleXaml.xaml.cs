using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;

namespace HelloXamarinFormsPCL
{
    public partial class SampleXaml : ContentPage
    {
        public SampleXaml()
        {
            InitializeComponent();
            BindingContext = new SampleContext
            {
                EntryText = "Sample Entry",
                LabelText = "Sample Label"
            };
        }

        public void Button_Clicked(object sender, EventArgs e)
        {
            var button = (Button)sender;
            button.Text = "Ouch";
        }
    }
}
