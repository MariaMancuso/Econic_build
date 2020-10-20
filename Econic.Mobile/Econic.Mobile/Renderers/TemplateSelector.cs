using System;
using Econic.Mobile.Models;
using Xamarin.Forms;

namespace Econic.Mobile.Renderers
{
	public class TemplateSelector : DataTemplateSelector
	{
		public DataTemplate classicTemplate { get; set; }
		public DataTemplate modernTemplate { get; set; }
		public DataTemplate friendlyTemplate { get; set; }

		protected override DataTemplate OnSelectTemplate(object item, BindableObject container)
		{
			
			//DataTemplate template = null;
			//switch((DataTemplate)item)
			//{
			//	case :
			//		template = classicTemplate;
			//		break;

				
			//}
			throw new NotImplementedException();
		}
	}
}
