using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Data;

namespace Custom_Grouping
{
    //ViewModel.cs
    //Converter for the Custom Grouping 
    public class DateConverter : IValueConverter
    {
        string Category;
        public DateConverter(string category)
        {
            Category = category;
        }
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            DateTime result;
            string MyString = value.ToString();
            DateTime.TryParse(MyString, out result);

            if (Category == "Year")
            {
                //Grouping the employee who are all born on 1980-1990 
                if ((DateTime.Compare(new DateTime(1980, 01, 01), result)) <= 0 &&
                    (DateTime.Compare(new DateTime(1990, 12, 31), result)) >= 0)
                {
                    return "Birth Year(1980 - 1990)";
                }
                //Grouping the employee who are all born on 1990-2000 
                else if ((DateTime.Compare(new DateTime(1991, 01, 01), result)) <= 0 &&
                    (DateTime.Compare(new DateTime(2000, 12, 31), result)) >= 0)
                {
                    return "Birth Year(1991 - 2000)";
                }
            }
            else if (Category == "Month")
            {
                //Sub-Grouping the employee who are all born on Jan-Mar 
                if (result.Month >= 1 && result.Month <= 3)
                {
                    return "Quarter-1";
                }
                //Sub-Grouping the employee who are all born on Apr-Jun
                else if (result.Month >= 4 && result.Month <= 6)
                {
                    return "Quarter-2";
                }
                //Sub-Grouping the employee who are all born on Jul-Sep
                else if (result.Month >= 7 && result.Month <= 9)
                {
                    return "Quarter-3";
                }
                //Sub-Grouping the employee who are all born on Oct-Dec
                else
                {
                    return "Quarter-4";
                }
            }
            return "Others";
        }
       
        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            throw new NotImplementedException();
        }
    }
}
