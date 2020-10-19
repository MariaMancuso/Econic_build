using System;
using System.Collections.Generic;
using System.Text;
using Xamarin.Forms;
using Econic.Mobile.Models;

namespace Econic.Mobile.ViewModels
{
	public class BoxColorViewModel
	{
		public BoxColorViewModel() { }
		public IList<BoxColorModel> SetColors()
		{
			List<BoxColorModel> list = new List<BoxColorModel>();
			list.Add(new BoxColorModel { color = Color.FromHex("#C72129") });
			list.Add(new BoxColorModel { color = Color.FromHex("#FF8611") });
			list.Add(new BoxColorModel { color = Color.FromHex("#32922C") });
			list.Add(new BoxColorModel { color = Color.FromHex("#11A18E") });
			list.Add(new BoxColorModel { color = Color.FromHex("#000059") });
			list.Add(new BoxColorModel { color = Color.FromHex("#0070F4") });
			list.Add(new BoxColorModel { color = Color.FromHex("#CC4A82") });
			list.Add(new BoxColorModel { color = Color.FromHex("#754313") });
			list.Add(new BoxColorModel { color = Color.FromHex("#354134") });
			list.Add(new BoxColorModel { color = Color.FromHex("#7323A8") });
			list.Add(new BoxColorModel { color = Color.FromHex("#6F6F6F") });
			list.Add(new BoxColorModel { color = Color.FromHex("#C9A015") });
			return list;
		}
	}
}
