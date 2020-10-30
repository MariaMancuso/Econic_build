using Econic.Mobile.Models;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Text;

namespace Econic.Mobile.ViewModels
{
	class GenerateDeal
	{
		ObservableCollection<Deals> deals = new ObservableCollection<Deals>();
		public GenerateDeal() { }
		public void GenerateColor()
		{
			var rand = new Random();
			var color = rand.Next(1, 5);

			switch (color) 
			{
				case 1: //red deal
					RedDeal();
					break;

				case 2: //green deal
					GreenDeal();
					break;
				case 3: //blue deal
					BlueDeal();
					break;
				case 4: //Black Friday
					break;

				default:
					break;
			}
				

		}

		private void RedDeal()
		{
			var rand = new Random();
			var redCat = rand.Next(1, 4);

			switch(redCat)
			{
				case 1: 
					break;
				case 2:
					break;

				case 3:
					break;
				default:
					break;
			}

		}

		private void GreenDeal()
		{

		}

		private void BlueDeal()
		{

		}

	}

}
