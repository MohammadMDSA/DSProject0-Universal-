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

		private void AddSubService_Click(object sender, RoutedEventArgs e)
		{
			this.Frame.Navigate(typeof(AddSubserviceView));
		}
		
		private void AllServices_Click(object sender, RoutedEventArgs e)
		{
			this.Frame.Navigate(typeof(AllServicesView));
		}
	}
}
