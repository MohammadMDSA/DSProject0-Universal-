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


namespace DSProjectUniversal.View.Component
{
	public sealed partial class SubserviceTreeItem : UserControl
	{
		private SuperService _Service;
		public SuperService Service {
			get
			{
				return _Service;
			}
			set
			{
				_Service = value;
				list.ItemSource = _Service.SubServices;
			}
		}
		public object ItemSource { get => list.ItemSource; private set => list.ItemSource = value; }

		public SubserviceTreeItem()
		{
			this.InitializeComponent();
			_Service = null;
		}

		private void Button_Click(object sender, RoutedEventArgs e)
		{
			if(list.IsOpen)
			{
				list.IsOpen = false;
				arrow.Glyph = "\uE00F";
			}
			else
			{
				list.IsOpen = true;
				arrow.Glyph = "\uE011";
			}
		}
	}
}
