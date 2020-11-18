using Microsoft.UI.Xaml.Controls;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
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

// The Blank Page item template is documented at https://go.microsoft.com/fwlink/?LinkId=402352&clcid=0x409

namespace TableViewItem
{
    public class ProfileTab
    {
        public string TabHeader { get; set; }
        public Microsoft.UI.Xaml.Controls.IconSource TabIconSource { get; set; }
        public object TabContent { get; set; }
    }
    /// <summary>
    /// An empty page that can be used on its own or navigated to within a Frame.
    /// </summary>
    public sealed partial class MainPage : Page
    {
        public ObservableCollection<ProfileTab> ProfileTabs { get; set; }

        public MainPage()
        {
            this.InitializeComponent();
            InitializeSampleProfile();
        }

        private void TabView_AddButtonClick(TabView sender, object args)
        {
            var profile = new ProfileTab();
            ProfileTabs.Add(CreateNewTab(new SettingsProfile()));
        }

        private void TabView_TabCloseRequested(TabView sender, TabViewTabCloseRequestedEventArgs args)
        {
            ProfileTabs.Remove(args.Item as ProfileTab);
        }

        private ProfileTab CreateNewTab(SettingsProfile profile)
        {
            var profileTab = new ProfileTab
            {
                TabHeader = $"{profile.PrettyName()}",
                TabIconSource = new Microsoft.UI.Xaml.Controls.SymbolIconSource() { Symbol = Symbol.Document },
            };

            // The content of the tab is a frame that contains a page, pass the profile as parameter
            Frame frame = new Frame();
            frame.Navigate(typeof(ProfilePage), profile);
            profileTab.TabContent = frame;

            return profileTab;
        }

        private void InitializeSampleProfile()
        {
            ProfileTabs = new ObservableCollection<ProfileTab>();

            // load sample data

            ProfileTabs.Add(CreateNewTab(new SettingsProfile()));
        }
    }
}
