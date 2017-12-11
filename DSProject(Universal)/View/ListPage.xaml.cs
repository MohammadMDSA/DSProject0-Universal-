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

// The Blank Page item template is documented at https://go.microsoft.com/fwlink/?LinkId=234238

namespace DSProjectUniversal.View
{
	/// <summary>
	/// An empty page that can be used on its own or navigated to within a Frame.
	/// </summary>
	public sealed partial class ListPage : Page
	{
		public ListPage()
		{
			this.InitializeComponent();
			

		}

		protected override void OnNavigatedTo(NavigationEventArgs e)
		{
			var S1 = new Service("name1", "", "", "", 10, 5);
			var S2 = new Service("name1", "", "", "", 10, 4);
			var S3 = new Service("name1", "", "", "", 10, 3);
			var Su1 = new SubService("subservice", 19920);
			var Su2 = new SubService("subservice1", 1920);
			var Su4 = new SubService("subservice3", 192);
			var Su3 = new SubService("subservice2", 9920);
			Su1.AddSubService(Su2);
			S1.AddSubService(Su3);
			S1.AddSubService(Su1);
			S2.AddSubService(Su4);
			tree.ItemSource = new Service[5]{
				S1,
				S2,
				S3,
				new Service("name1", "", "", "", 10, 2),
				new Service("name1", "", "", "", 10, 1)
			};
		}
	}
}
