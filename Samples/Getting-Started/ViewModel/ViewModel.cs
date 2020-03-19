using Syncfusion.Windows.Shared;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Getting_Started.ViewModel
{
    class ViewModel : NotificationObject
    {
        private ObservableCollection<string> daysCollection = new ObservableCollection<string>();
        private ObservableCollection<object> checkedDays = new ObservableCollection<object>();

        public ObservableCollection<string> DaysCollection
        {
            get 
            { 
                return daysCollection;
            }
            set 
            { 
                daysCollection = value;
            }
        }

        //Checked vegetable collection
        public ObservableCollection<object> CheckedDays
        {
            get
            {
                return checkedDays;
            }
            set
            {
                checkedDays = value;
                this.RaisePropertyChanged("CheckedDays");
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

            //Days added in the checked dates collection
            CheckedDays.Add("Monday");
            CheckedDays.Add("Wednesday");
            CheckedDays.Add("Friday");

        }
    }
}
