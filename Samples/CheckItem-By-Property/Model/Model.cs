using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CheckItem_By_Property
{
    //Model.cs
    public class GroupItem : INotifyPropertyChanged
    {
        public string Name { get; set; }
        public string GroupName { get; set; }
        private bool enabled;       
        public bool Enabled
        {
            get { return enabled; }
            set 
            {
               enabled = value;
               OnPropertyChanged("Enabled");
            }
        }

        public event PropertyChangedEventHandler PropertyChanged;
        protected virtual void OnPropertyChanged(string propertyName)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }   
}
