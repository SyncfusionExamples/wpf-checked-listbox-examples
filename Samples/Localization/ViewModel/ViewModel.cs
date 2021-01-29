using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Localization
{
	public class ViewModel
	{
		private ObservableCollection<Model> checkList;
		public ObservableCollection<Model> CheckListItems
		{
			get
			{
				return checkList;
			}
			set
			{
				checkList = value;
			}
		}

		public ViewModel()
		{
			CheckListItems = new ObservableCollection<Model>();
			populateItem();
		}

		private void populateItem()
		{
			CheckListItems.Add(new Model() { Name = "Mexico", Description = "Mexico" });
			CheckListItems.Add(new Model() { Name = "Canada", Description = "Canada" });
			CheckListItems.Add(new Model() { Name = "Bermuda", Description = "Bermuda" });
			CheckListItems.Add(new Model() { Name = "Beize", Description = "Beize" });
			CheckListItems.Add(new Model() { Name = "Panama", Description = "Panama" });
		}
	}
}
