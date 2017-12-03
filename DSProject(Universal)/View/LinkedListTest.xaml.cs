using System;
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

using DSProjectUniversal.Util;
using System.Threading.Tasks;

// The Blank Page item template is documented at https://go.microsoft.com/fwlink/?LinkId=234238

namespace DSProject_Universal_.View
{
	/// <summary>
	/// An empty page that can be used on its own or navigated to within a Frame.
	/// </summary>
	public sealed partial class LinkedListTest : Page
	{
		public LinkedListTest()
		{
			this.InitializeComponent();
		}

		async protected override void OnNavigatedTo(NavigationEventArgs e)
		{
			var list = new LinkedList<int>();
			list.AddLast(1).AddLast(2).AddLast(3).AddLast(4).AddLast(5).AddLast(6).AddLast(72).AddLast(2);
			var nodeAr = list.ToNodeArray();
			nodes.ItemsSource = nodeAr;
			foreach (var item in nodeAr)
			{
				textbox.Text += item.Data + ", ";
			}

			await Task.Delay(10000);

			list.RemoveLast();
			nodes.ItemsSource = list.ToNodeArray();

			await Task.Delay(10000);

			list.RemoveElement(4);
			nodes.ItemsSource = list.ToNodeArray();


		}
	}
}
