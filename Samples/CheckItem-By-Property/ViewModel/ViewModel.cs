using Syncfusion.Windows.Shared;
using System.Collections.ObjectModel;
using System.ComponentModel;

namespace CheckItem_By_Property
{
    //ViewModel.cs
    public class ViewModel : NotificationObject
    {
        private ObservableCollection<GroupItem> virtualCollection;
        private ObservableCollection<GroupDescription> groupDescriptions;

        public ObservableCollection<GroupItem> VirtualCollection
        {
            get
            {
                return virtualCollection;
            }
            set
            {
                virtualCollection = value;
                RaisePropertyChanged("VirtualCollection");
            }
        }
        public ObservableCollection<GroupDescription> GroupDescriptions
        {
            get
            {
                return groupDescriptions;
            }
            set
            {
                groupDescriptions = value;
                RaisePropertyChanged("GroupDescriptions");
            }
        }
        public ViewModel()
        {
            GroupDescriptions = new ObservableCollection<GroupDescription>();

            VirtualCollection = new ObservableCollection<GroupItem>();
            for (int i = 0; i < 1000; i++)
            {
                for (int j = 0; j < 10; j++)
                {
                    GroupItem myitem = new GroupItem() 
                    { 
                        Name = "Module " + i.ToString(), 
                        GroupName = "Group" + j.ToString() 
                    };
                    if (i % 2 == 0)
                    {
                        //Define a checked state for items
                        myitem.IsChecked = true;
                    }
                    VirtualCollection.Add(myitem);
                }
            }
        }
    }
}


