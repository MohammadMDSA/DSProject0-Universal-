using DSProjectUniversal.View;
using DSProjectUniversal.Model;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using Windows.ApplicationModel;
using Windows.ApplicationModel.Activation;
using Windows.Foundation;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Controls.Primitives;
using Windows.UI.Xaml.Data;
using Windows.UI.Xaml.Input;
using Windows.UI.Xaml.Media;
using Windows.UI.Xaml.Navigation;

namespace DSProjectUniversal
{
	/// <summary>
	/// Provides application-specific behavior to supplement the default Application class.
	/// </summary>
	sealed partial class App : Application
	{
		public object CompanyView { get; private set; }

		/// <summary>
		/// Initializes the singleton application object.  This is the first line of authored code
		/// executed, and as such is the logical equivalent of main() or WinMain().
		/// </summary>
		public App()
		{
			this.InitializeComponent();
			this.Suspending += OnSuspending;
		}

		/// <summary>
		/// Invoked when the application is launched normally by the end user.  Other entry points
		/// will be used such as when the application is launched to open a specific file.
		/// </summary>
		/// <param name="e">Details about the launch request and process.</param>
		protected override void OnLaunched(LaunchActivatedEventArgs e)
		{
			Frame rootFrame = Window.Current.Content as Frame;
			
			// Do not repeat app initialization when the Window already has content,
			// just ensure that the window is active
			if (rootFrame == null)
			{
				// Create a Frame to act as the navigation context and navigate to the first page
				rootFrame = new Frame();

				rootFrame.NavigationFailed += OnNavigationFailed;

				if (e.PreviousExecutionState == ApplicationExecutionState.Terminated)
				{
					//TODO: Load state from previously suspended application
				}

				// Place the frame in the current Window
				Window.Current.Content = rootFrame;
			}







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
			CompanyViewxaml.Company.AddService("name1", "", "", "", 10);
			CompanyViewxaml.Company.AddService("name2", "", "", "", 10);
			CompanyViewxaml.Company.AddService("name3", "", "", "", 10);
			CompanyViewxaml.Company.AddService("name4", "", "", "", 10);
			CompanyViewxaml.Company.AddService("name5", "", "", "", 10);

			CompanyViewxaml.Company.AddAgency("Agency1");
			CompanyViewxaml.Company.AddAgency("Agency2");
			CompanyViewxaml.Company.AddAgency("Agency3");
			CompanyViewxaml.Company.AddAgency("Agency4");



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
			CompanyViewxaml.Company.AddService(Ss1);
			CompanyViewxaml.Company.AddService(Ss2);
			CompanyViewxaml.Company.AddService(Ss3);
			CompanyViewxaml.Company.AddService(SW1);
			CompanyViewxaml.Company.AddService(SW2);
			CompanyViewxaml.Company.AddService(SW3);








			Windows.UI.Core.SystemNavigationManager.GetForCurrentView().BackRequested += App_BackRequested;
			Windows.UI.Core.SystemNavigationManager.GetForCurrentView().AppViewBackButtonVisibility = Windows.UI.Core.AppViewBackButtonVisibility.Visible;

			if (e.PrelaunchActivated == false)
			{
				if (rootFrame.Content == null)
				{
					// When the navigation stack isn't restored navigate to the first page,
					// configuring the new page by passing required information as a navigation
					// parameter
					rootFrame.Navigate(typeof(CompanyViewxaml), e.Arguments);
				}
				// Ensure the current window is active
				Window.Current.Activate();
			}
		}

		/// <summary>
		/// Invoked when Navigation to a certain page fails
		/// </summary>
		/// <param name="sender">The Frame which failed navigation</param>
		/// <param name="e">Details about the navigation failure</param>
		void OnNavigationFailed(object sender, NavigationFailedEventArgs e)
		{
			throw new Exception("Failed to load Page " + e.SourcePageType.FullName);
		}

		/// <summary>
		/// Invoked when application execution is being suspended.  Application state is saved
		/// without knowing whether the application will be terminated or resumed with the contents
		/// of memory still intact.
		/// </summary>
		/// <param name="sender">The source of the suspend request.</param>
		/// <param name="e">Details about the suspend request.</param>
		private void OnSuspending(object sender, SuspendingEventArgs e)
		{
			var deferral = e.SuspendingOperation.GetDeferral();
			//TODO: Save application state and stop any background activity
			deferral.Complete();
		}

		private void App_BackRequested(object sender, Windows.UI.Core.BackRequestedEventArgs e)
		{
			Frame rootFrame = Window.Current.Content as Frame;
			if (rootFrame == null)
				return;

			// Navigate back if possible, and if the event has not 
			// already been handled .
			if (rootFrame.CanGoBack && e.Handled == false)
			{
				e.Handled = true;
				rootFrame.GoBack();
			}
		}
	}
}
