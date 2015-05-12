using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;

namespace XamlKeypad
{
    public partial class XamlKeypadPage : ContentPage
    {
        public XamlKeypadPage()
        {
            InitializeComponent();

            // New code for loading previous keypad text.
            App app = Application.Current as App;
            displayLabel.Text = app.DisplayLabelText;
            backspaceButton.IsEnabled = displayLabel.Text != null &&
            displayLabel.Text.Length > 0;
        }

        private void OnDigitButtonClicked(object sender, EventArgs e)
        {
            Button button = (Button)sender;
            displayLabel.Text += (string)button.StyleId;
            backspaceButton.IsEnabled = true;

            // Save keypad text.
            App app = Application.Current as App;
            app.DisplayLabelText = displayLabel.Text;
        }

        private void OnBackspaceButtonClicked(object sender, EventArgs e)
        {
            string text = displayLabel.Text;
            displayLabel.Text = text.Substring(0, text.Length - 1);
            backspaceButton.IsEnabled = displayLabel.Text.Length > 0;

            // Save keypad text.
            App app = Application.Current as App;
            app.DisplayLabelText = displayLabel.Text;
        }
    }

}
