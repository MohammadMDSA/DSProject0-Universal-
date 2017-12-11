using System;
using System.Collections;
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

// The User Control item template is documented at https://go.microsoft.com/fwlink/?LinkId=234236

namespace DSProjectUniversal.View.Component
{
	public sealed partial class SubserviceTree : UserControl
	{
		
		public object ItemSource {
			get => list.ItemsSource;
			set {if(value != null) list.ItemsSource = value; }
		}
		public bool IsOpen {
			get => (list.Visibility == Visibility.Collapsed ? false : true);
			set => list.Visibility = (value ? Visibility.Visible : Visibility.Collapsed);
		}

		public SubserviceTree()
		{
			this.InitializeComponent();
		}

		private void list_LostFocus(object sender, RoutedEventArgs e)
		{
			list.SelectedIndex = -1;
		}
	}
}
