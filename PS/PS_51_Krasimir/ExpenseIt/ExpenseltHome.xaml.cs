using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using System.Xml;

namespace ExpenseIt
{
	/// <summary>
	/// Interaction logic for ExpenseltHome.xaml
	/// </summary>
	public partial class ExpenseltHome : Page, INotifyPropertyChanged
	{
		public event PropertyChangedEventHandler PropertyChanged;
		private DateTime lastChecked;

		public DateTime LastChecked
		{
			get { return lastChecked; }
			set
			{
				lastChecked = value;
				PropertyChanged?.Invoke(this, new PropertyChangedEventArgs("LastChecked"));
			}
		}

		public ObservableCollection<string> PersonsChecked { get; set; }

		public ExpenseltHome()
		{
			InitializeComponent();
			LastChecked = DateTime.Now;
			this.DataContext = this;
			PersonsChecked = new ObservableCollection<string>();
		}

		private void Button_Click(object sender, RoutedEventArgs e)
		{
			// View Expense Report
			//ExpenseReportPage expenseReportPage = new ExpenseReportPage();
			//this.NavigationService.Navigate(expenseReportPage);
			ExpenseReportPage expenseReportPage =
			new ExpenseReportPage(this.peopleListBox.SelectedItem);
			this.NavigationService.Navigate(expenseReportPage);
		}

		private void Button_Click_1(object sender, RoutedEventArgs e)
		{
			string greetingMsg;
			greetingMsg = (peopleListBox.SelectedItem as XmlElement).GetAttribute("Name");
			MessageBox.Show("Hi " + greetingMsg);
		}

		private void PeopleListBox_SelectionChanged_1(object sender, SelectionChangedEventArgs e)
		{
			LastChecked = DateTime.Now;
			PersonsChecked.Add((peopleListBox.SelectedItem as XmlElement).Attributes["Name"].Value);
		}
	}
}
