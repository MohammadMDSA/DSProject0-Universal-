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
	public sealed partial class CompanyViewxaml : Page
	{

		public static Company Company;

		public CompanyViewxaml()
		{
			this.InitializeComponent();
			CompanyViewxaml.Company = new Company();
			var SW1 = new Service("name111", "", "", "", 10, 5);
			var SW2 = new Service("name122", "", "", "", 10, 4);
			var SW3 = new Service("name133", "", "", "", 10, 3);
			var Su1 = new SubService("subservice", 19920);
			var Su2 = new SubService("subservice1", 1920);
			var Su4 = new SubService("subservice3", 192);
			var Su3 = new SubService("subservice2", 9920);
			Su1.AddSubService(Su2);
			SW1.AddSubService(Su3);
			SW1.AddSubService(Su1);
			SW2.AddSubService(Su4);
			var s = new Service[5]{
				SW1,
				SW2,
				SW3,
				new Service("name1", "", "", "", 10, 2),
				new Service("name1", "", "", "", 10, 1)
			};
			Company.AddService("name1", "", "", "", 10);
			Company.AddService("name2", "", "", "", 10);
			Company.AddService("name3", "", "", "", 10);
			Company.AddService("name4", "", "", "", 10);
			Company.AddService("name5", "", "", "", 10);

			Company.AddAgency("Agency1");
			Company.AddAgency("Agency2");
			Company.AddAgency("Agency3");
			Company.AddAgency("Agency4");



			var Ss1 = new Service("nameww4", "", "", "", 10, 5);
			var Ss2 = new Service("nameww3", "", "", "", 10, 4);
			var Ss3 = new Service("nameww2", "", "", "", 10, 3);
			var Ssu1 = new SubService("subservice", 19920);
			var Ssu2 = new SubService("subservice1", 1920);
			var Ssu4 = new SubService("subservice3", 192);
			var Ssu3 = new SubService("subservice2", 9920);
			Su1.AddSubService(Su2);
			SW1.AddSubService(Su3);
			SW1.AddSubService(Su1);
			SW2.AddSubService(Su4);
			Company.AddService(Ss1);
			Company.AddService(Ss2);
			Company.AddService(Ss3);
			Company.AddService(SW1);
			Company.AddService(SW2);
			Company.AddService(SW3);
		}

		protected override void OnNavigatedTo(NavigationEventArgs e)
		{
			var services = new List<Service>();
			foreach (var item in Company.SuperServicePool)
			{
				if (item.IsService)
					services.Add(item as Service);
			}

			ServicesList.ItemsSource = services;
			AgenciesList.ItemsSource = Company.Agencies;
		}

		private void ServiceList_Click(object sender, RoutedEventArgs e)
		{
			this.Frame.Navigate(typeof(ServiceView), (sender as Button).DataContext);
		}

		private void AgencyList_Click(object sender, RoutedEventArgs e)
		{
			this.Frame.Navigate(typeof(AgencyView), (sender as Button).DataContext);
		}

		private async void CreateServiceBtn(object sender, RoutedEventArgs e)
		{
			int ex;
			await Dispatcher.RunAsync(Windows.UI.Core.CoreDispatcherPriority.Normal, () =>
			{
				ExpenceInput.Background = new SolidColorBrush(Colors.White);
				ServiceNameInput.Background = new SolidColorBrush(Colors.White);
			});
			if (!int.TryParse(ExpenceInput.Text, out ex))
			{
				await Dispatcher.RunAsync(Windows.UI.Core.CoreDispatcherPriority.Normal, () =>
				{
					ExpenceInput.Background = new SolidColorBrush(Colors.Red);
				});
				return;
			}
			await Dispatcher.RunAsync(Windows.UI.Core.CoreDispatcherPriority.Normal, () =>
			{
				ExpenceInput.Background = new SolidColorBrush(Colors.White);
			});
			if (ServiceNameInput.Text == string.Empty || !Company.AddService(ServiceNameInput.Text, CusDescInput.Text, TechDescInput.Text, CarModelInput.Text, ex))
			{
				await Dispatcher.RunAsync(Windows.UI.Core.CoreDispatcherPriority.Normal, () =>
				{
					ServiceNameInput.Background = new SolidColorBrush(Colors.Red);
				});
				return;
			}

			ServiceNameInput.Text = string.Empty;
			CusDescInput.Text = string.Empty;
			TechDescInput.Text = string.Empty;
			CarModelInput.Text = string.Empty;
			ExpenceInput.Text = string.Empty;

			var services = new List<Service>();
			foreach (var item in Company.SuperServicePool)
			{
				if (item.IsService)
					services.Add(item as Service);
			}

			ServicesList.ItemsSource = services;
		}

		private void RemoveService_Click(object sender, RoutedEventArgs e)
		{
			var service = (sender as Button).DataContext as Service;
			Company.RemoveService(service.Id);
			var services = new List<Service>();
			foreach (var item in Company.SuperServicePool)
			{
				if (item.IsService)
					services.Add(item as Service);
			}

			ServicesList.ItemsSource = services;
		}

		private async void CreateAgencyBtn(object sender, RoutedEventArgs e)
		{
			await Dispatcher.RunAsync(Windows.UI.Core.CoreDispatcherPriority.High, () =>
			{
				AgencyNameInput.Background = new SolidColorBrush(Colors.White);
			});

			if (AgencyNameInput.Text == string.Empty || !Company.AddAgency(AgencyNameInput.Text))
			{
				await Dispatcher.RunAsync(Windows.UI.Core.CoreDispatcherPriority.Normal, () =>
				{
					AgencyNameInput.Background = new SolidColorBrush(Colors.Red);
				});
				return;
			}

			AgencyNameInput.Text = string.Empty;

			AgenciesList.ItemsSource = Company.Agencies;
		}
	}
}
