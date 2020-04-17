using Syncfusion.Windows.Shared;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Input;

namespace ItemTemplateSelector
{
    // A class that choose DataTemplate for the group items
    public class MyTemplateSelector : DataTemplateSelector {
        public DataTemplate Template { get; set; }
        public DataTemplate itemTemplate { get; set; }

        public override DataTemplate SelectTemplate(object item, DependencyObject container)
        {
            if (item is Vegetable && (item as Vegetable).Category == "Beans")
                return itemTemplate;
            else
                return Template;
        }
    }


    class ViewModel {
        public ObservableCollection<Vegetable> Vegetables { get; set; }
        public ICommand LoadedCommand { get; set; }
        public void OnLoaded(object param) {
            CollectionView view = (CollectionView)CollectionViewSource.GetDefaultView(Vegetables);

            //Adding group description
            view.GroupDescriptions.Add(new PropertyGroupDescription("Category"));
        }
        public ViewModel() {
            Vegetables = new ObservableCollection<Vegetable>();
            Vegetables.Add(new Vegetable { Price = 10, Name = "Yarrow", Category = "Leafy and Salad" });
            Vegetables.Add(new Vegetable { Price = 20, Name = "Pumpkins", Category = "Leafy and Salad" });
            Vegetables.Add(new Vegetable { Price = 30, Name = "Cabbage", Category = "Leafy and Salad" });
            Vegetables.Add(new Vegetable { Price = 10, Name = "Spinach", Category = "Leafy and Salad" });
            Vegetables.Add(new Vegetable { Price = 20, Name = "Wheat Grass", Category = "Leafy and Salad" });
            Vegetables.Add(new Vegetable { Price = 30, Name = "Horse gram", Category = "Beans" });
            Vegetables.Add(new Vegetable { Price = 10, Name = "Chickpea", Category = "Beans" });
            Vegetables.Add(new Vegetable { Price = 20, Name = "Green bean", Category = "Beans" });
            Vegetables.Add(new Vegetable { Price = 30, Name = "Garlic", Category = "Bulb and Stem" });
            Vegetables.Add(new Vegetable { Price = 10, Name = "Onion", Category = "Bulb and Stem" });
            Vegetables.Add(new Vegetable { Price = 20, Name = "Nopal", Category = "Bulb and Stem" });

            //Initialize the checklistbox LoadedCommand
            LoadedCommand = new DelegateCommand<object>(OnLoaded);
        }
    }
}
