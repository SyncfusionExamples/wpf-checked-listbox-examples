using Syncfusion.Windows.Shared;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Data;
using System.Windows.Input;

namespace Custom_Grouping
{

    public class ViewModel : NotificationObject {
        private CollectionView view;
        private ICommand loadedCommand;
        private ObservableCollection<Employee> employees = new ObservableCollection<Employee>();

        public ObservableCollection<Employee> Employees {
            get {
                return employees;
            }
            set {
                employees = value;
                RaisePropertyChanged("Employees");
            }
        }

        public ICommand LoadedCommand {
            get {
                return loadedCommand;
            }
        }

        public void OnLoaded(object param) {
            view = (CollectionView)CollectionViewSource.GetDefaultView(Employees);

            //Group descriptions for the employees
            view.GroupDescriptions.Add(new PropertyGroupDescription("DOB", new DataConvert("Year")));
            view.GroupDescriptions.Add(new PropertyGroupDescription("DOB", new DataConvert("Month")));
        }

        public ViewModel() {
            loadedCommand = new DelegateCommand<object>(OnLoaded);
            //Adding the items in Vegetable collection
            Employees = new ObservableCollection<Employee>();
            Employees.Add(new Employee() { Name = "Daniel", DOB = new DateTime(1983, 02, 15), Age = 37 });
            Employees.Add(new Employee() { Name = "James", DOB = new DateTime(1988, 06, 29), Age = 32 });

            Employees.Add(new Employee() { Name = "Michael", DOB = new DateTime(1987, 06, 10), Age = 33 });
            Employees.Add(new Employee() { Name = "Robert", DOB = new DateTime(1980, 08, 23), Age = 40 });

            Employees.Add(new Employee() { Name = "John", DOB = new DateTime(1990, 12, 22), Age = 30 });
            Employees.Add(new Employee() { Name = "Paul", DOB = new DateTime(1997, 04, 08), Age = 23 });
           
            Employees.Add(new Employee() { Name = "Mark", DOB = new DateTime(1994, 08, 05), Age = 26 });
            Employees.Add(new Employee() { Name = "George", DOB = new DateTime(1998, 10, 01), Age = 22 });

            Employees.Add(new Employee() { Name = "Kevin", DOB = new DateTime(1996, 12, 02), Age = 24 });
            
            Employees.Add(new Employee() { Name = "Thomes", DOB = new DateTime(1995, 10, 08), Age = 25 });
           Employees.Add(new Employee() { Name = "Steven", DOB = new DateTime(1982, 12, 15), Age = 38 });
             }
    }

    public class DataConvert : IValueConverter {
        string Category;
        public DataConvert(string category) {
            Category = category;
        }
        public object Convert(object value, Type targetType, object parameter, System.Globalization.CultureInfo culture) {            
            DateTime result;
            string MyString = value.ToString();
            DateTime.TryParse(MyString, out result);

            if (Category == "Year") {
                //Grouping the employee who are all born on 1980-1990 
                if ((DateTime.Compare(new DateTime(1980,01,01), result)) <= 0 && (DateTime.Compare(new DateTime(1990, 12, 31), result)) >= 0) {
                    return "Birth Year(1980 - 1990)";
                }
                //Grouping the employee who are all born on 1990-2000 
                else if ((DateTime.Compare(new DateTime(1991, 01, 01), result)) <= 0 && (DateTime.Compare(new DateTime(2000, 12, 31), result)) >= 0) {
                    return "Birth Year(1991 - 2000)";
                }

            }
            else if (Category == "Month") {
                //Sub-Grouping the employee who are all born on Jan-Mar 
                if (result.Month >=1 && result.Month<=3) {
                    return "Quarter-1";
                }
                //Sub-Grouping the employee who are all born on Apr-Jun
                else if (result.Month >= 4 && result.Month <= 6) {
                    return "Quarter-2";
                }
                //Sub-Grouping the employee who are all born on Jul-Sep
                else if (result.Month >= 7 && result.Month <= 9) {
                    return "Quarter-3";
                }
                //Sub-Grouping the employee who are all born on Oct-Dec
                else {
                    return "Quarter-4";
                }
            }
            return "Others";
        }
        public object ConvertBack(object value, Type targetType, object parameter, System.Globalization.CultureInfo culture) {
            throw new NotImplementedException();
        }
    }
}
