using Syncfusion.Windows.Shared;
using Syncfusion.Windows.Tools.Controls;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Data;
using System.Windows.Input;

namespace CheckItem_By_Property
{
    
    public class ViewModel : NotificationObject
    {
        private ObservableCollection<Model> collection = new ObservableCollection<Model>();
        private string checkedItemsCount = "CheckedItemsCount : ";
        private CheckListBox checkListBox;

        public ObservableCollection<Model> Collection {
            get { return collection; }
            set { collection = value; }
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
        public ICommand LoadedCommand { get; set; }
        public void OnLoaded(object param) {
            CollectionView view = (CollectionView)CollectionViewSource.GetDefaultView(Collection);

            //Adding group description
            view.GroupDescriptions.Add(new PropertyGroupDescription("GroupName"));

            checkListBox = (CheckListBox)param;
            checkListBox.SelectedItems.CollectionChanged += SelectedItems_CollectionChanged;
        }
        private void SelectedItems_CollectionChanged(object sender, System.Collections.Specialized.NotifyCollectionChangedEventArgs e)
        {
            CheckedItemsCount = "CheckedItemsCount : " + (sender as CheckListBox).SelectedItems.Count.ToString();
        }

        public ViewModel() {
            Collection = new ObservableCollection<Model>();
            for (int i = 0; i < 100; i++) {
                for (int j = 0; j < 10; j++) {
                    Model myitem = new Model() { Name = "Module " + i.ToString(), GroupName = "Group" + j.ToString() };
                    if (i % 2 == 0)
                        myitem.IsChecked = true;
                    Collection.Add(myitem);
                }
            }

            //Initialize the checklistbox LoadedCommand
            LoadedCommand = new DelegateCommand<object>(OnLoaded);
        }
    }
}

 
