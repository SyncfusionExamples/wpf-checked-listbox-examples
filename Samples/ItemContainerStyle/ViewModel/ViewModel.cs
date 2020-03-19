using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ItemContainerStyle
{
    class ViewModel
    {
        private ObservableCollection<string> daysCollection = new ObservableCollection<string>();
        public ObservableCollection<string> DaysCollection
        {
            get { return daysCollection; }
            set { daysCollection = value; }
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
