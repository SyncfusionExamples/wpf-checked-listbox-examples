using Syncfusion.Windows.Shared;
using System.Collections.ObjectModel;
using System.ComponentModel;

namespace CheckListBox_Virtualization
{
    public class ViewModel : NotificationObject
    {
        private ObservableCollection<GroupDescription> groupDescriptions;
        private ObservableCollection<Model> collection = new ObservableCollection<Model>();
        public ObservableCollection<Model> Collection
        {
            get 
            { 
                return collection;
            }
            set 
            { 
                collection = value; 
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

            //Define virtualisation items
            Collection = new ObservableCollection<Model>();
            for (int i = 0; i < 1000; i++)
            {
                for (int j = 0; j < 10; j++)
                {                  
                    Collection.Add(
                        new Model()
                        {
                            Name = "Module " + i.ToString(),
                            GroupName = "Group" + j.ToString() 
                        });
                }
            }
        }
    }
}
