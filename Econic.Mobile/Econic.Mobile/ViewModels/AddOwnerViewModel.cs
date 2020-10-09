using Econic.Mobile.Models;
using Econic.Mobile.ViewModel;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Text;
using System.Text.RegularExpressions;
using System.Windows.Input;
using Xamarin.Forms;

namespace Econic.Mobile.ViewModels
{
    public class AddOwnerViewModel : BaseVM, INotifyPropertyChanged
    {
        public AddOwnerViewModel()
        {
           
        }
        string businessname;
        string product;
        string service;
        int monthlysale;
        string servicearea;
        Address address;
        ClassificationModel classificationModel;

        List<Item> items = new List<Item>();
        List<OwnerGoal> ownerGoals = new List<OwnerGoal>() { 
            new OwnerGoal() { Goal = "Connect you to your customers", Value = 0},
            new OwnerGoal() { Goal = "Increate your profibility", Value = 0},
            new OwnerGoal() { Goal = "Identify your best products and service - every day", Value = 0},
            new OwnerGoal() { Goal = "Identify and reward your most loyal customers", Value = 0},
            new OwnerGoal() { Goal = "Lower your transactions costs", Value = 0}
        };

        public string BusinessName
        {
            get { return businessname; }
            set { businessname = value; }
        }
        public string Product
        {
            get { return product; }
            set { product = value; }
        }
        public string Service
        {
            get { return service; }
            set { service = value; }
        }
        public Address Address
        {
            get { return address = new Address(); }
            set { address = value; }
        }
        public int MonthlySales
        {
            get { return monthlysale; }
            set { monthlysale = value; }
        }
        public string ServiceArea
        {
            get { return servicearea; }
            set { servicearea = value; }
        }
        public List<OwnerGoal> OwnerGoals
        {
            get { return ownerGoals; }
            set { ownerGoals = value; }
        }
        public ClassificationModel ClassificationModel
        {
            get { return classificationModel = new ClassificationModel(); }
            set { classificationModel = value; }
        }
        public List<Item> Items
        {
            get { return items; }
            set { items = value; }
        }
        public string GetInitials()
        {
            Regex initials = new Regex(@"(\b[a-zA-Z])[a-zA-Z]* ?");
            string init = initials.Replace(businessname, "$1");

            return init;
        }
        void SaveOwner()
        {
            //do to
        }
    }
}
