using Syncfusion.Windows.Shared;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CheckListBox_FirstClick
{
    class ViewModel : NotificationObject
    {
        private ObservableCollection<string> daysCollection = new ObservableCollection<string>();
        private bool isCheckOnFirstClick = true;

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

        public bool IsCheckOnFirstClick
        {
            get
            {
                return isCheckOnFirstClick;
            }
            set
            {
                isCheckOnFirstClick = value;
                this.RaisePropertyChanged("IsCheckOnFirstClick");
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
