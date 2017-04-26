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
    /// Calendar page
    /// </summary>
    public sealed partial class CalendarPage : Page
    {
        private IStorageFile sampleFile;
        private ObservableCollection<Exercise> exercises;

       
        public CalendarPage()
        {
            this.InitializeComponent();

            // read from disk
            ReadExercises();
        }
        private void BackButton_Click(object sender, RoutedEventArgs e)
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

        // read and display file content
        private async void ReadFile()
        {
            textBlock.Text = await Windows.Storage.FileIO.ReadTextAsync(sampleFile);
        }

        // read data from disk
        private async void ReadExercises()
        {
            // find a file
            try
            {
                StorageFolder storageFolder = ApplicationData.Current.LocalFolder;
                Stream stream = await storageFolder.OpenStreamForReadAsync("exercises.dat");
                // read data
                DataContractSerializer serializer = new DataContractSerializer(typeof(ObservableCollection<Exercise>));
                exercises = (ObservableCollection<Exercise>)serializer.ReadObject(stream);
            }
            catch (Exception ex)
            {
                // not exists create a new collection
                exercises = new ObservableCollection<Exercise>();
                Debug.WriteLine(ex.Message);
            }
        }

    }
}
