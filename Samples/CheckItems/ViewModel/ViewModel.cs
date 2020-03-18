using Syncfusion.Windows.Shared;
using Syncfusion.Windows.Tools.Controls;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace CheckListBox_CheckItem
{    
    class ViewModel : NotificationObject
    {
        CheckListBox checkListBox;
        private ObservableCollection<Vegetable> vegetables = new ObservableCollection<Vegetable>();
        private ObservableCollection<object> checkedVegetables = new ObservableCollection<object>();
        private string checkedItemsCount = "CheckedItemsCount : ";

        public ICommand SelectionChangedCommand { get; set; }
        public void OnSelectionChanged(object param)
        {
            checkListBox = (CheckListBox)param;
            checkListBox.SelectedItems.CollectionChanged += SelectedItems_CollectionChanged;
        }

        private void SelectedItems_CollectionChanged(object sender, System.Collections.Specialized.NotifyCollectionChangedEventArgs e)
        {
            CheckedItemsCount = "CheckedItemsCount : " + CheckedVegetables.Count.ToString();
        }

        public string CheckedItemsCount
        {
            get
            {
                return checkedItemsCount;
            }
            set
            {
                checkedItemsCount = value;
                this.RaisePropertyChanged("CheckedItemsCount");
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
                this.RaisePropertyChanged("Vegetables");
            }
        }

        //Checked vegetable collection
        public ObservableCollection<object> CheckedVegetables
        {
            get
            {
                return checkedVegetables;
            }
            set
            {
                checkedVegetables = value;
                this.RaisePropertyChanged("CheckedVegetables");
            }
        }
        public ViewModel()
        {
            //Adding a vegetables details into the Vegetables collection
            Vegetables = new ObservableCollection<Vegetable>();
            Vegetables.Add(new Vegetable { Price = "$10", Name = "Yarrow", Category = "Leafy and Salad" });
            Vegetables.Add(new Vegetable { Price = "$20", Name = "Cabbage", Category = "Leafy and Salad" });
            Vegetables.Add(new Vegetable { Price = "$30", Name = "Horse gram", Category = "Beans" });
            Vegetables.Add(new Vegetable { Price = "$20", Name = "Green bean", Category = "Beans" });
            Vegetables.Add(new Vegetable { Price = "$10", Name = "Onion", Category = "Bulb and Stem" });
            Vegetables.Add(new Vegetable { Price = "$30", Name = "Nopal", Category = "Bulb and Stem" });
            
            SelectionChangedCommand = new DelegateCommand<object>(OnSelectionChanged);

            //Adding a checked vegetable into the CheckedVegetables collection
            CheckedVegetables = new ObservableCollection<object>();
            CheckedVegetables.Add(Vegetables[0]);
            CheckedVegetables.Add(Vegetables[2]);
            CheckedVegetables.Add(Vegetables[4]);
            CheckedItemsCount = "CheckedItemsCount : " + CheckedVegetables.Count.ToString();
        }
    }

}
