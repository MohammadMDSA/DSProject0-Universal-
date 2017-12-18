using DSProjectUniversal.Model;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using Windows.Foundation;
using Windows.Foundation.Collections;
using Windows.UI;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Controls.Primitives;
using Windows.UI.Xaml.Data;
using Windows.UI.Xaml.Input;
using Windows.UI.Xaml.Media;
using Windows.UI.Xaml.Navigation;

// The Blank Page item template is documented at https://go.microsoft.com/fwlink/?LinkId=234238

namespace DSProjectUniversal.View
{
	/// <summary>
	/// An empty page that can be used on its own or navigated to within a Frame.
	/// </summary>
	public sealed partial class AgencyView : Page
	{
		private Priority[] priorities;
		private Agency CurrentAgency;

		public AgencyView()
		{
			this.InitializeComponent();
			priorities = new Priority[5];
			priorities[0] = Priority.VeryLow;
			priorities[1] = Priority.Low;
			priorities[2] = Priority.Normal;
			priorities[3] = Priority.High;
			priorities[4] = Priority.VeryHigh;
		}

		protected override void OnNavigatedTo(NavigationEventArgs e)
		{
			CurrentAgency = e.Parameter as Agency;
			CurrentAgency.AddService(new Service("dsfdsf", "", "", "", 123, 12323));
			TitleTxt.Text = CurrentAgency.AgencyName;
			Orders.ItemsSource = CurrentAgency.Orders;
			OrderPriorityInput.ItemsSource = priorities;
			ServiceInput.ItemsSource = CurrentAgency.Services;
			AgencyServices.ItemsSource = CurrentAgency.Services;
		}

		private void Order_Click(object sender, RoutedEventArgs e)
		{

		}

		private async void AddOrder_Click(object sender, RoutedEventArgs e)
		{
			await Dispatcher.RunAsync(Windows.UI.Core.CoreDispatcherPriority.Normal, () =>
			{
				OrderPriorityInput.Background = new SolidColorBrush(Colors.White);
				OrderNameInput.Background = new SolidColorBrush(Colors.White);
				ServiceInput.Background = new SolidColorBrush(Colors.White);
			});
			if (OrderPriorityInput.SelectedIndex < 0)
			{
				await Dispatcher.RunAsync(Windows.UI.Core.CoreDispatcherPriority.Normal, () =>
				{
					OrderPriorityInput.Background = new SolidColorBrush(Colors.Red);
				});
				return;
			}
			if(ServiceInput.SelectedIndex < 0)
			{
				await Dispatcher.RunAsync(Windows.UI.Core.CoreDispatcherPriority.Normal, () =>
				{
					ServiceInput.Background = new SolidColorBrush(Colors.Red);
				});
				return;
			}
			Priority p;
			switch(OrderPriorityInput.SelectedIndex)
			{
				case 0:
					p = Priority.VeryLow;
					break;
				case 1:
					p = Priority.Low;
					break;
				case 2:
					p = Priority.Normal;
					break;
				case 3:
					p = Priority.High;
					break;
				case 4:
					p = Priority.VeryHigh;
					break;
				default:
					return;
			}
			if (OrderNameInput.Text == string.Empty || !CurrentAgency.AddOrder(new Order(OrderNameInput.Text, ServiceInput.SelectedItem as Service, p)))
			{
				await Dispatcher.RunAsync(Windows.UI.Core.CoreDispatcherPriority.Normal, () =>
				{
					OrderNameInput.Background = new SolidColorBrush(Colors.Red);
					return;
				});
			}
			Orders.ItemsSource = CurrentAgency.Orders;

			OrderNameInput.Text = string.Empty;
			OrderPriorityInput.SelectedIndex = -1;
			ServiceInput.SelectedIndex = -1;
		}

		private void RemoveOrder_Click(object sender, RoutedEventArgs e)
		{
			CurrentAgency.GetFirstOrder();

			Orders.ItemsSource = CurrentAgency.Orders;
		}

		private void Service_Click(object sender, RoutedEventArgs e)
		{
			this.Frame.Navigate(typeof(ServiceView), (sender as Button).DataContext);
		}

		private void RemoveService_Click(object sender, RoutedEventArgs e)
		{
			CurrentAgency.RemoveService((sender as Button).DataContext as Service);
			AgencyServices.ItemsSource = CurrentAgency.Services;
		}
	}
}
