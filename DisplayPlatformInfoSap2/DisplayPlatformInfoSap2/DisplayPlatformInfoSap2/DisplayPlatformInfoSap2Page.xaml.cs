using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;

namespace DisplayPlatformInfoSap2
{
	public partial class DisplayPlatformInfoSap2Page : ContentPage
	{
		public DisplayPlatformInfoSap2Page ()
		{
			InitializeComponent ();

            PlatformInfo platformInfo = new PlatformInfo();
            modelLabel.Text = platformInfo.GetModel();
            versionLabel.Text = platformInfo.GetVersion();
		}
	}
}
