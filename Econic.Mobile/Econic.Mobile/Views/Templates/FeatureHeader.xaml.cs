
﻿using Econic.Mobile.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Econic.Mobile.Controls;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace Econic.Mobile.Views.Templates
{
	[XamlCompilation(XamlCompilationOptions.Compile)]
	public partial class FeatureHeader : ContentView
	{
		public FeatureHeader()
		{
			InitializeComponent();
		}

		public void SetHeader(string text)
		{

		}
	}
}