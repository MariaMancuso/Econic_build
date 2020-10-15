using Econic.Mobile.Models;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Text;

namespace Econic.Mobile.ViewModels
{
    public class CrossingUIModelViewModel
    {
        public ObservableCollection<CrossingUIModel> BindCrossingUIModel { get; set; }

        public CrossingUIModelViewModel()
        {
            BindCrossingUIModel = new ObservableCollection<CrossingUIModel>();

            for (int i = 1; i < 7; i++)
            {
                CrossingUIModel model = new CrossingUIModel();
                model.Id = i;
                BindCrossingUIModel.Add(model);
            }
            BindCrossingUIModel.First().IsDisabled = false;
            BindCrossingUIModel.First().IsFocus = true;
            foreach (CrossingUIModel model in BindCrossingUIModel)
            {
                model.PropertyChanged += Model_PropertyChanged;
 
            }
        }

        private void Model_PropertyChanged(object sender, PropertyChangedEventArgs e)
        {
            if (e.PropertyName == "FieldValue")
            {
                var model = sender as CrossingUIModel;

                if (model.FieldValue.Length == 1)
                {
                    model.FieldValue = model.FieldValue.Substring(0, 1);

                    int id = model.Id;

                    if (id < 6)
                    {
                        BindCrossingUIModel[id].IsFocus = true;
                        BindCrossingUIModel[id].IsDisabled = false;
                    }
                    else
                        model.IsFocus = false;
                }
            }
        }
    }
}
