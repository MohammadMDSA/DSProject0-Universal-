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
    public sealed partial class ServiceView : Page
    {
        public ServiceView()
        {
            this.InitializeComponent();
        }

		protected override void OnNavigatedTo(NavigationEventArgs e)
		{
			Service currentService = e.Parameter as Service;

			ServiceNameTxt.Text = currentService.Name;
			CarModelTxt.Text = currentService.CarModel;
			CusDescTxt.Text = currentService.CustomerDescription;
			TechDescTxt.Text = currentService.TechnicalDescription;
			ExpTxt.Text = currentService.Expence.ToString();

			TitleTxt.Text = currentService.Name;
			SubserviceTree.Service= currentService;
		}
	}
}
