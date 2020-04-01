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
        private ObservableCollection<GroupDescription> groupDescriptions =
            new ObservableCollection<GroupDescription>();
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
            //Adding group description to the GroupDescriptions collection
            GroupDescriptions = new ObservableCollection<GroupDescription>();
            GroupDescriptions.Add(new PropertyGroupDescription("DOB", new DateConverter("Year")));
            GroupDescriptions.Add(new PropertyGroupDescription("DOB", new DateConverter("Month")));
        }
    }   
}
