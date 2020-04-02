using Syncfusion.Windows.Shared;
using System.Collections.ObjectModel;

namespace CheckListBox_CheckItem
{
    //ViewModel.cs
    class ViewModel : NotificationObject
    {
        private ObservableCollection<Vegetable> vegetables = new ObservableCollection<Vegetable>();
        private ObservableCollection<object> checkedVegetables = new ObservableCollection<object>();

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

        //Selected vegetable collection
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
            //Adding a vegetables details
            Vegetables = new ObservableCollection<Vegetable>();
            Vegetables.Add(new Vegetable
            {
                Price = 10,
                Name = "Yarrow",
                Category = "Leafy and Salad"
            });
            Vegetables.Add(new Vegetable
            {
                Price = 20,
                Name = "Cabbage",
                Category = "Leafy and Salad"
            });
            Vegetables.Add(new Vegetable
            {
                Price = 30,
                Name = "Horse gram",
                Category = "Beans"
            });
            Vegetables.Add(new Vegetable
            {
                Price = 20,
                Name = "Green bean",
                Category = "Beans"
            });
            Vegetables.Add(new Vegetable
            {
                Price = 10,
                Name = "Onion",
                Category = "Bulb and Stem"
            });
            Vegetables.Add(new Vegetable
            {
                Price = 30,
                Name = "Nopal",
                Category = "Bulb and Stem"
            });

            //Adding a selected vegetable
            CheckedVegetables = new ObservableCollection<object>();
            CheckedVegetables.Add(Vegetables[0]);
            CheckedVegetables.Add(Vegetables[2]);
            CheckedVegetables.Add(Vegetables[4]);
        }
    }
}
