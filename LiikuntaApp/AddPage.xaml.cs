using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using System.Runtime.Serialization;
using Windows.Foundation;
using Windows.Foundation.Collections;
using Windows.Storage;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Controls.Primitives;
using Windows.UI.Xaml.Data;
using Windows.UI.Xaml.Input;
using Windows.UI.Xaml.Media;
using Windows.UI.Xaml.Navigation;

// The Blank Page item template is documented at http://go.microsoft.com/fwlink/?LinkId=234238

namespace LiikuntaApp
{
    /// <summary>
    /// Add new exercise page.
    /// </summary>
    public sealed partial class Add : Page
    {
        private void CalendarButton_Click(object sender, RoutedEventArgs e)
        {
            // get root frame (which show pages)
            Frame rootFrame = Window.Current.Content as Frame;
            // did we get it correctly
            if (rootFrame == null) return;
            // navigate back if possible
            if (rootFrame.CanGoBack)
            {
                rootFrame.GoBack();
            }
        }
        
        // define storage file
        private Windows.Storage.StorageFile sampleFile;

        // constructor
        public Add()
        {
            this.InitializeComponent();

            // create or open file
            CreateOrOpenFile();
        }

        // create or open local file
        private async void CreateOrOpenFile()
        {
            Windows.Storage.StorageFolder storageFolder =
                Windows.Storage.ApplicationData.Current.LocalFolder;
            sampleFile =
                await storageFolder.CreateFileAsync("liikunta.txt", Windows.Storage.CreationCollisionOption.OpenIfExists);
        }

        // write a new line to file
        private async void SaveButton_Click(object sender, RoutedEventArgs e)
        {
            await Windows.Storage.FileIO.AppendTextAsync(sampleFile, nameTextBox.Text + Environment.NewLine);
            
        }

        
    }

   


}

