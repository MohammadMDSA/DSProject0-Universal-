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


namespace DSProjectUniversal.View
{
	/// <summary>
	/// An empty page that can be used on its own or navigated to within a Frame.
	/// </summary>
	public sealed partial class AddSubserviceView : Page
	{
		private static Random Random = new Random();

		public AddSubserviceView()
		{
			this.InitializeComponent();
		}

		protected override void OnNavigatedTo(NavigationEventArgs e)
		{
			NewToggle.IsChecked = false;
			NewSubserviceNameInput.IsEnabled = true;
			SubservicesListInput.IsEnabled = false;

			var items = new List<SubService>();

			foreach (var item in CompanyViewxaml.Company.SuperServicePool)
			{
				if (!item.IsService)
				{
					items.Add(item as SubService);
				}
			}
			SubservicesListInput.ItemsSource = items;
			ParentS.ItemsSource = CompanyViewxaml.Company.SuperServicePool;
		}
		
		private void NewToggle_Checked(object sender, RoutedEventArgs e)
		{
			NewSubserviceNameInput.IsEnabled = false;
			SubservicesListInput.IsEnabled = true;
		}

		private void NewToggle_Unchecked(object sender, RoutedEventArgs e)
		{
			NewSubserviceNameInput.IsEnabled = true;
			SubservicesListInput.IsEnabled = false;
		}

		private async void AddSubservice_Click(object sender, RoutedEventArgs e)
		{
			await Dispatcher.RunAsync(Windows.UI.Core.CoreDispatcherPriority.Normal, () =>
			{
				NewSubserviceNameInput.Background = new SolidColorBrush(Colors.White);
				SubservicesListInput.Background = new SolidColorBrush(Colors.White);
				ParentS.Background = new SolidColorBrush(Colors.White);
			});

			if(ParentS.SelectedIndex < 0)
			{
				await Dispatcher.RunAsync(Windows.UI.Core.CoreDispatcherPriority.Normal, () =>
				{
					ParentS.Background = new SolidColorBrush(Colors.Red);
				});
				return;
			}

			if (NewToggle.IsChecked.Value)
			{
				if(SubservicesListInput.SelectedIndex < 0 || !(ParentS.SelectedItem as SuperService).AddSubService(SubservicesListInput.SelectedItem as SubService))
				{
					await Dispatcher.RunAsync(Windows.UI.Core.CoreDispatcherPriority.Normal, () =>
					{
						SubservicesListInput.Background = new SolidColorBrush(Colors.Red);
						return;
					});
				}
				
			}
			else
			{
				int id;
				lock (this)
				{
					id = Random.Next();
				}
				var newSub = new SubService(NewSubserviceNameInput.Text, id);
				if (NewSubserviceNameInput.Text == string.Empty || !CompanyViewxaml.Company.AddService(newSub) || !(ParentS.SelectedItem as SuperService).AddSubService(newSub))
				{
					await Dispatcher.RunAsync(Windows.UI.Core.CoreDispatcherPriority.Normal, () =>
					{
						SubservicesListInput.Background = new SolidColorBrush(Colors.Red);
						return;
					});
				}
			}
			SubservicesListInput.SelectedIndex = -1;
			NewSubserviceNameInput.Text = string.Empty;
			ParentS.SelectedIndex = -1;

			var items = new List<SubService>();

			foreach (var item in CompanyViewxaml.Company.SuperServicePool)
			{
				if (!item.IsService)
				{
					items.Add(item as SubService);
				}
			}
			SubservicesListInput.ItemsSource = items;
			ParentS.ItemsSource = CompanyViewxaml.Company.SuperServicePool;
		}
	}
}
