using Syncfusion.Windows.Shared;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Data;
using System.Windows.Input;

namespace Custom_Grouping
{
    public class ViewModel : NotificationObject
    {
        private ObservableCollection<GroupDescription> groupDescriptions;
        private EmployeesCollection employeesCollection;

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

        public EmployeesCollection EmployeesCollection
        {
            get
            {
                return employeesCollection;
            }
            set
            {
                employeesCollection = value;
                RaisePropertyChanged("EmployeesCollection");
            }
        }

        public ViewModel()
        {
            EmployeesCollection = new EmployeesCollection();
            GroupDescriptions = new ObservableCollection<GroupDescription>();
        }
    }   
}
