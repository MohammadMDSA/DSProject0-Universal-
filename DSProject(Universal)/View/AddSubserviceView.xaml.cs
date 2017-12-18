using DSProjectUniversal.Model;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using Windows.Foundation;
using Windows.Foundation.Collections;
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

		private void AddSubservice_Click(object sender, RoutedEventArgs e)
		{

		}
	}
}
