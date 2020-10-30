using Econic.Mobile.Models;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Text;

namespace Econic.Mobile.ViewModels
{
	public class ProductsViewModel : INotifyPropertyChanged
	{
		

		private ObservableCollection<Models.Products> productCollection;

		public ObservableCollection<Models.Products> ProductCollection
		{
			get { return productCollection; }
			set { productCollection = value; }
		}
		public ProductsViewModel() 
		{
			productCollection = new ObservableCollection<Models.Products>();
			productCollection.Add(new Models.Products() { Name = "Goods" });
			productCollection.Add(new Models.Products() { Name = "Apparel" });
			productCollection.Add(new Models.Products() { Name = "Food Service" });
			productCollection.Add(new Models.Products() { Name = "Household Goods" });
			productCollection.Add(new Models.Products() { Name = "Sports" });
			productCollection.Add(new Models.Products() { Name = "Health and Beauty" });
			productCollection.Add(new Models.Products() { Name = "Jewlery" });
		}

		public event PropertyChangedEventHandler PropertyChanged;
		public void RaisePropertyChanged(String name)
		{
			if (PropertyChanged != null)
				this.PropertyChanged(this, new PropertyChangedEventArgs(name));
		}

		public ObservableCollection<Products> SetProducts()
		{
			productCollection = new ObservableCollection<Models.Products>();
			productCollection.Add(new Models.Products() { Name = "Brow Crayon", Price = "$19.00", img="browcrayon.png" });
			productCollection.Add(new Models.Products() { Name = "Brow Trio", Price = "$19.00", img = "browtrio.png"});
			productCollection.Add(new Models.Products() { Name = "Finishing Wax", Price = "$10.00", img = "finishwax.png" });
			productCollection.Add(new Models.Products() { Name = "Brow Collection Home Signature Kit", Price = "$39.00", img = "homesignaturekit.png" });
			return productCollection;
		}
	}
}
