﻿using Econic.Mobile.Views.Templates;
using System;
using System.Collections.Generic;
using System.Text;
using Xamarin.Forms;

namespace Econic.Mobile.Models
{
	public class Services
	{
		public ImageSource ServiceImg;
		public string Name { private set; get; }
		public string ServiceType { private set; get; }

		public Services(string name)
		{
			this.Name = name;
		}

		public void FavoriteServices(string name, string serviceType)
		{
			this.Name = name;
			this.ServiceType = serviceType;
		}
	}
}
