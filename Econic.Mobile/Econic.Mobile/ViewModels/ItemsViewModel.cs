using Econic.Mobile.Models;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Text;
using System.Windows.Input;

namespace Econic.Mobile.ViewModels
{
    public class ItemsViewModel<T>
    {
        private ObservableCollection<GoodModel> goods;
        private ObservableCollection<ServiceModel> services;
        bool isService;
        public ItemsViewModel(string ParentViewModel, ObservableCollection<GoodModel> Goods, ObservableCollection<ServiceModel> Services, string type)
        {
            goods = Goods;
            services = Services;
            if (type == "service")
                isService = true;
        }
        public ICommand AddAnotherTapped { private set; get; }
        public ICommand RemoveServiceClicked { private set; get; }
        public ICommand RemoveGoodClicked { private set; get; }
        public ICommand EditServiceClicked { private set; get; }
        public ICommand EditGoodClicked { private set; get; }
        public ICommand AddNewServiceCommand { private set; get; }
        public ICommand AddNewGoodCommand { private set; get; }
    }
}
