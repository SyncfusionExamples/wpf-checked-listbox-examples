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

namespace Sorting
{
    class ViewModel : INotifyPropertyChanged
    {
        private ObservableCollection<Vegetable> vegetables = new ObservableCollection<Vegetable>();
        private ObservableCollection<object> checkedItems = new ObservableCollection<object>();
        CollectionView view;
        public event PropertyChangedEventHandler PropertyChanged;
        private ICommand selectionChangedCommand;
        private ICommand checkChangedCommand;        

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
        }
  
        public ICommand SelectionChangedCommand
        {
            get
            {
                return selectionChangedCommand;
            }
        }
       

        public ICommand CheckChangedCommand
        {
            get
            {
                return checkChangedCommand;
            }
        }
        public void OnCheckChanged(object param)
        {
            if (view != null && (param as CheckBox) != null)
            {
                if ((param as CheckBox).IsChecked == false)
                {
                    view.GroupDescriptions.Clear();
                }
                else
                {
                    view.GroupDescriptions.Clear();
                    view.GroupDescriptions.Add(new PropertyGroupDescription("Category"));
                }
            }
        }

        public void OnSelectionChanged(object param)
        {
            if (view != null && (param as ComboBox).SelectedItem != null)
            {
                ComboBoxItem boxItem = (param as ComboBox).SelectedItem as ComboBoxItem;
                if (boxItem.Content.Equals("Default Order"))
                {
                    view.SortDescriptions.Clear();
                }
                else if (boxItem.Content.Equals("Ascending"))
                {
                    view.SortDescriptions.Clear();
                    view.SortDescriptions.Add(new SortDescription { PropertyName = "Name", Direction = ListSortDirection.Ascending });
                }
                else if (boxItem.Content.Equals("Descending"))
                {
                    view.SortDescriptions.Clear();
                    view.SortDescriptions.Add(new SortDescription { PropertyName = "Name", Direction = ListSortDirection.Descending });
                }
            }
        }

        public ViewModel()
        {
            //Adding the items in Vegetable collection
            Vegetables = new ObservableCollection<Vegetable>();
            PopulateItems();

            //Items added in this collection to be Checked.
            CheckedItems = new ObservableCollection<object>();
            CheckedItems.Add(Vegetables[0]);
            CheckedItems.Add(Vegetables[2]);
            CheckedItems.Add(Vegetables[4]);
            CheckedItems.Add(Vegetables[6]);
            CheckedItems.Add(Vegetables[8]);

            //Initialize the CheckListBox loaded command and ComboBox selection changed commands
            loadedCommand = new DelegateCommand<object>(OnLoaded);
            selectionChangedCommand = new DelegateCommand<object>(OnSelectionChanged);
            checkChangedCommand = new DelegateCommand<object>(OnCheckChanged);
        }

        public void PopulateItems()
        {
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
        }
    }
}
