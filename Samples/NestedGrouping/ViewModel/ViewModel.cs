using Syncfusion.Windows.Shared;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Input;

namespace CheckListBox_NestedGrouping
{
    class ViewModel : INotifyPropertyChanged
    {
        private ObservableCollection<Vegetable> vegetables = new ObservableCollection<Vegetable>();
        private ObservableCollection<object> checkedItems = new ObservableCollection<object>();
        private ObservableCollection<string> propertyNames = new ObservableCollection<string>();
        CollectionView view;
        public event PropertyChangedEventHandler PropertyChanged;

        //Property collection in the Vegetable class
        public ObservableCollection<string> PropertyNames
        {
            get
            {
                return propertyNames;
            }
            set
            {
                propertyNames = value;
                OnPropertyChanged("PropertyNames");
            }
        }

        //Vegetables collection
        public ObservableCollection<Vegetable> Vegetables
        {
            get
            {
                return vegetables;
            }
            set
            {
                vegetables = value;
                OnPropertyChanged("Vegetables");
            }
        }

        //Checked vegetable collection
        public ObservableCollection<object> CheckedItems
        {
            get
            {
                return checkedItems;
            }
            set
            {
                checkedItems = value;
                OnPropertyChanged("CheckedItems");
            }
        }

        private void OnPropertyChanged(string name)
        {
            PropertyChangedEventHandler handler = PropertyChanged;
            if (handler != null)
            {
                handler(this, new PropertyChangedEventArgs(name));
            }
        }

        private ICommand loadedCommand;

        public ICommand LoadedCommand
        {
            get
            {
                return loadedCommand;
            }
        }
        public void OnLoaded(object param)
        {
            view = (CollectionView)CollectionViewSource.GetDefaultView(Vegetables);
            view.GroupDescriptions.Add(new PropertyGroupDescription("Category"));
            view.GroupDescriptions.Add(new PropertyGroupDescription("Price"));
        }


     
        public void OnSelectioChanged(object param)
        {
            if (view != null && (param as ComboBox).SelectedItem != null)
            {
                view.GroupDescriptions.Clear();
                view.GroupDescriptions.Add(new PropertyGroupDescription((param as ComboBox).SelectedValue.ToString()));
            }
        }

        public ViewModel()
        {
            //Adding the items in Vegetable collection
            Vegetables = new ObservableCollection<Vegetable>();
            PopulateItems();

            //Items added in this collection to be Checked.
            //CheckedItems = new ObservableCollection<object>();
            //CheckedItems.Add(Vegetables[0]);
            //CheckedItems.Add(Vegetables[2]);
            //CheckedItems.Add(Vegetables[4]);
            //CheckedItems.Add(Vegetables[6]);
            //CheckedItems.Add(Vegetables[8]);

            //Initialize the CheckListBox loaded command and ComboBox selection changed commands
            loadedCommand = new DelegateCommand<object>(OnLoaded);

        }

        public void PopulateItems()
        {
           // Vegetables = new ObservableCollection<Vegetable>();
            Vegetables.Add(new Vegetable { Price = 10, Name = "Yarrow", Category = "Leafy and Salad" });
            Vegetables.Add(new Vegetable { Price = 20, Name = "Cabbage", Category = "Leafy and Salad" });
            Vegetables.Add(new Vegetable { Price = 30, Name = "Horse gram", Category = "Beans" });
            Vegetables.Add(new Vegetable { Price = 20, Name = "Green bean", Category = "Beans" });
            Vegetables.Add(new Vegetable { Price = 10, Name = "Onion", Category = "Bulb and Stem" });
            Vegetables.Add(new Vegetable { Price = 30, Name = "Nopal", Category = "Bulb and Stem" });

        }
    }
}
