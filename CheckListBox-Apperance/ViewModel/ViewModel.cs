using Syncfusion.Windows.Shared;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Media;

namespace CheckListBox_Apperance
{
    class ViewModel : NotificationObject
    {
        private Brush foregroundBrush = Brushes.Red;
        private Brush backgroundBrush = Brushes.SkyBlue;
        private Brush mouseOverBackgroundBrush = Brushes.Pink;
        private Brush selectedItemBackground = Brushes.Yellow;
        private ObservableCollection<string> daysCollection = new ObservableCollection<string>();

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
        
        public Brush ForegroundBrush
        {
            get
            {
                return foregroundBrush;
            }
            set
            {
                foregroundBrush = value;
                this.RaisePropertyChanged("ForegroundBrush");
            }
        }

        public Brush BackgroundBrush
        {
            get
            {
                return backgroundBrush;
            }
            set
            {
                backgroundBrush = value;
                this.RaisePropertyChanged("BackgroundBrush");
            }
        }
        public Brush MouseOverBackgroundBrush
        {
            get
            {
                return mouseOverBackgroundBrush;
            }
            set
            {
                mouseOverBackgroundBrush = value;
                this.RaisePropertyChanged("MouseOverBackgroundBrush");
            }
        }
        
        public Brush SelectedItemBackground
        {
            get
            {
                return selectedItemBackground;
            }
            set
            {
                selectedItemBackground = value;
                this.RaisePropertyChanged("SelectedItemBackground");
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
