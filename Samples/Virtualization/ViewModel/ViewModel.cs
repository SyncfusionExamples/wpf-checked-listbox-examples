using Syncfusion.Windows.Shared;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Data;
using System.Windows.Input;

namespace CheckListBox_Virtualization
{
    public class ViewModel
    {
        private ObservableCollection<Model> collection = new ObservableCollection<Model>();
        public ObservableCollection<Model> Collection
        {
            get { return collection; }
            set { collection = value; }
        }

        public ICommand LoadedCommand { get; set; }
        public void OnLoaded(object param)
        {
            CollectionView view = (CollectionView)CollectionViewSource.GetDefaultView(Collection);

            //Adding group description
            view.GroupDescriptions.Add(new PropertyGroupDescription("GroupName"));
        }

        public ViewModel()
        {
            Collection = new ObservableCollection<Model>();
            for (int i = 0; i < 1000; i++)
            {
                for (int j = 0; j < 10; j++)
                {
                    Model myitem = new Model() { Name = "Module " + i.ToString(), GroupName = "Group" + j.ToString() };
                    Collection.Add(myitem);
                }
            }

            //Initialize the checklistbox LoadedCommand
            LoadedCommand = new DelegateCommand<object>(OnLoaded);

        }
    }
}
