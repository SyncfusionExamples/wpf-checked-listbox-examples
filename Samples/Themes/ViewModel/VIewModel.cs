using Syncfusion.SfSkinManager;
using Syncfusion.Windows.Shared;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;

namespace CheckListBox_Themes
{
    public class ViewModel : NotificationObject
    {
        private ObservableCollection<string> themes = new ObservableCollection<string>();
        private ObservableCollection<string> daysCollection = new ObservableCollection<string>();
        private ICommand selectionChangedCommand;

        public ICommand SelectionChangedCommand
        {
            get
            {
                return selectionChangedCommand;
            }
        }

        public ObservableCollection<string> Themes
        {
            get
            {
                return themes;
            }
            set
            {
                themes = value;
                this.RaisePropertyChanged("Themes");
            }
        }

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

            //Theme list  added in the collection
            Themes.Add("Blend");
            Themes.Add("Lime");
            Themes.Add("MaterialDark");
            Themes.Add("MaterialDarkBlue");
            Themes.Add("MaterialLight");
            Themes.Add("MaterialLightBlue");
            Themes.Add("Metro");
            Themes.Add("Office2010Black");
            Themes.Add("Office2010Blue");
            Themes.Add("Office2010Silver");
            Themes.Add("Office2013DarkGray");
            Themes.Add("Office2013LightGray");
            Themes.Add("Office2013White");
            Themes.Add("Office2016Colorful");
            Themes.Add("Office2016DarkGray");
            Themes.Add("Office2016White");
            Themes.Add("Office2019Black");
            Themes.Add("Office2019Colorful");
            Themes.Add("Office365");
            Themes.Add("Saffron");
            Themes.Add("VisualStudio2013");
            Themes.Add("VisualStudio2015");
            selectionChangedCommand = new DelegateCommand<object>(selectionChanged);
        }

        public void selectionChanged(object parameter)
        {
            WindowCollection windows = Application.Current.Windows;
            if (windows.Count > 0)
            {
                Window samplewindow = windows[0];
                ComboBox combo = parameter as ComboBox;
                if (combo != null)
                {
                    if (combo.SelectedItem != null)
                    {
                        string themename = combo.SelectedValue.ToString();
                        SfSkinManager.SetVisualStyle(samplewindow, (VisualStyles)Enum.Parse(typeof(VisualStyles), themename));
                    }
                }
            }
        }
    }
}
