using Syncfusion.Windows.Shared;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CheckListBox_SelectAll
{
    class ViewModel : NotificationObject
    {
        private ObservableCollection<string> daysCollection= new ObservableCollection<string>();
        private bool isSelectAllEnabled= true;

        public ObservableCollection<string> DaysCollection
        {
            get
            {
                return daysCollection;
            }
            set
            {
                daysCollection = value;
                this.RaisePropertyChanged("DaysCollection");
            }
        }

        public bool IsSelectAllEnabled
        {
            get
            {
                return isSelectAllEnabled;
            }
            set
            {
                isSelectAllEnabled = value;
                this.RaisePropertyChanged("IsSelectAllEnabled");
            }
        }

        public ViewModel()
        {
            //Days added in the collection
            DaysCollection.Add("Sunday");
            DaysCollection.Add("Monday");
            DaysCollection.Add("Tuesday");
            DaysCollection.Add("Wednesday");
            DaysCollection.Add("Thursday");
            DaysCollection.Add("Friday");
            DaysCollection.Add("Saturday");
        }
    }
}
