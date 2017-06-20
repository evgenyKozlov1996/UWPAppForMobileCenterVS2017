using Microsoft.Azure.Mobile;
using Microsoft.Azure.Mobile.Analytics;
using Microsoft.Azure.Mobile.Push;
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

// Документацию по шаблону элемента "Пустая страница" см. по адресу https://go.microsoft.com/fwlink/?LinkId=402352&clcid=0x419

namespace UWPAppForMobileCenterVS2017
{
    /// <summary>
    /// Пустая страница, которую можно использовать саму по себе или для перехода внутри фрейма.
    /// </summary>
    public sealed partial class MainPage : Page
    {
		public MainPage()
        {
			this.InitializeComponent();
			System.Diagnostics.Debug.WriteLine(MobileCenter.InstallId);
			Push.PushNotificationReceived += (sender, par) =>
			{
				//Add the notification message and title to the message
				var summary = $"Push notification received:" +
								$"\n\tNotification title: {par.Title}" +
								$"\n\tMessage: {par.Message}";
				//If there is the custom data associated with the notification,
				//print the entries
				if (par.CustomData != null)
				{
					summary += "\n\tCustom data:\n";
					foreach (var key in par.CustomData.Keys)
					{
						summary += $"\t\t{key} : {par.CustomData[key]}\n";
					}
					System.Diagnostics.Debug.WriteLine(summary);
					
				}
			};
		}

		public void ShowPush(string arg)
		{
			output.Text = arg;	
		}

		private void analitycs25_Click(object sender, RoutedEventArgs e)
		{
			string name = "abcdefghabcdefghabcdefghabcdefghabcdefghabcdefgh" +
				"abcdefghabcdefghabcdefghabcdefghabcdefghabcdefghab" +
				"cdefghabcdefghabcdefghabcdefghabcdefghabcdefghabcdefghabcdefgh" +
				"abcdefghabcdefghabcdefghabcdefghabcdefghabcdefghabcdefgh" +
				"abcdefghabcdefghabcdefghabcdefghabcdefgha";
			Analytics.TrackEvent(name);//257 characters
			output.Text += "Name: " + name + "\n";
			output.Text += "Event properties: None";
		}

		private void analitycs27_Click(object sender, RoutedEventArgs e)
		{
			Analytics.TrackEvent("Test event8", new Dictionary<string, string>
			{
				{"Category1", "FileName1"},
				{"Category2", "FileName2"},
				{"Category3", "FileName3"},
				{"Category4", "FileName4"},
				{"Category5", "FileName5"},
				{"Category6", "FileName6"},
			});
			output.Text = "";
			output.Text = "Name: Test event8\nEvent properties:\n\tCategory1: FileName1" +
			"\n\tCategory2: FileName2\n\tCategory3: FileName3\n\tCategory4: FileName4" +
			"\n\tCategory5: FileName5\n\tCategory6: FileName6";
			
		}

		private void analytics16_Click(object sender, RoutedEventArgs e)
		{
			Analytics.TrackEvent("Test event1");
			output.Text = "Event name: Test event1\nEvent propertirs: none";
		}

		private void analytics18_Click(object sender, RoutedEventArgs e)
		{
			Dictionary<string, string> eventBody = new Dictionary<string, string>();
			eventBody.Add("abcdefghabcdefghabcdefghabcd" +
				"efghabcdefghabcdefghabcdefghabcdefgha", "Music");
			Analytics.TrackEvent("Test event3", eventBody);
			output.Text = "Analytics-18:\nEvent name: Test event3\n Poperties:\n\tabcdefghabcdefghabcdefghabcdefghabcdefghabcdefghabcdefghabcdefgha: Music";
		}

		private void analytics19_Click(object sender, RoutedEventArgs e)
		{
			Dictionary<string, string> eventBody = new Dictionary<string, string>();
			eventBody.Add("Music", "abcdefghabcdefghabcdefghabcd" +
				"efghabcdefghabcdefghabcdefghabcdefgha");
			Analytics.TrackEvent("Test event4", eventBody);
			output.Text = "Analytics-19:\nEvent name: Test event4\n Poperties:\n\t Music: abcdefghabcdefghabcdefghabcdefghabcdefghabcdefghabcdefghabcdefgha";
		}

		private void analytics20_Click(object sender, RoutedEventArgs e)
		{
			output.Text = "Analytics-20";
			for(int i=0; i<200; i++)
			{
				string name = "Event" + i;
				Analytics.TrackEvent(name);
				output.Text += "Name: " + name + "\nProperties: none\n";
			}
		}

		private void analytics21_Click(object sender, RoutedEventArgs e)
		{
			Analytics.TrackEvent("Test event6", new Dictionary<string, string> { { "!@#$%^&*()?<>,.\']}~`", "Music" } });
			output.Text = "Analytics-21\nName: Test event6\nProperty:\n\t !@#$%^&*()?<>,.\']}~`: Music";
		}

		private void analytics22_Click(object sender, RoutedEventArgs e)
		{
			Analytics.TrackEvent("Test event7", new Dictionary<string, string> { { "Music", "!@#$%^&*()?<>,.\']}~`" } });
			output.Text = "Analytics-22\nName: Test event6\nProperty:\n\t Music: !@#$%^&*()?<>,.\']}~`";
		}

		private void analytics23_Click(object sender, RoutedEventArgs e)
		{
			Analytics.TrackEvent("!@#$%^&*()?<>,.\']}~`");
			output.Text = "Analytics-23\nName: !@#$%^&*()?<>,.\']}~`\nProperties: None";
		}

		private void analytics24_Click(object sender, RoutedEventArgs e)
		{
			Analytics.TrackEvent(null);
			output.Text = "Analytics-24\nName: null\nProperties: None";
		}

		private void analitycs26_Click(object sender, RoutedEventArgs e)
		{
			Analytics.TrackEvent("");
			output.Text = "Analytics-26\nName: ''\nProperties: None";
		}

		//Push notifications
		
	}
}
