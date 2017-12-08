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

using DSProject_Universal_.Util;

// The Blank Page item template is documented at https://go.microsoft.com/fwlink/?LinkId=234238

namespace DSProject_Universal_.View
{
	/// <summary>
	/// An empty page that can be used on its own or navigated to within a Frame.
	/// </summary>
	public sealed partial class RootPage : Page
	{
		public RootPage()
		{
			this.InitializeComponent();
		}

		protected override void OnNavigatedTo(NavigationEventArgs e)
		{
			var heap = new MaxHeap<int>(10);
			box.Text += "hey\n";
			heap.Add(9); print(heap);
			heap.Add(8); print(heap);
			heap.Add(3); print(heap);
			heap.Add(7); print(heap);
			heap.Add(4); print(heap);
			heap.Add(2); print(heap);
			heap.Add(1); print(heap);
			heap.Add(6); print(heap);
			heap.Add(5); print(heap);
			heap.Add(0); print(heap);
			heap.remove(9); print(heap);
		}

		private void print(MaxHeap<int> heap)
		{
			foreach (var item in heap.HeapArray)
			{
				box.Text += item + ", ";
			}
			box.Text += Environment.NewLine;
		}
	}
}
