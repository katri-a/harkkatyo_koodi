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
    /// Lisää uusi harjoitus sivu.
    /// </summary>
    public sealed partial class Add : Page
    {
        public Add()
        {
            this.InitializeComponent();
        }

        //lisää harjoitus
        private Exercise exercise;
        private ObservableCollection<Exercise> exercises;

        // page is navigated to
        protected override void OnNavigatedTo(NavigationEventArgs e)
        {
            // add
            if (e.Parameter is ObservableCollection<Exercise>)
            {
                exercise = (ObservableCollection<Exercise>)e.Parameter;
                saveButton.Content = "Tallenna";
            }
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
            // add and navigate to a new page
            this.Frame.Navigate(typeof(CalendarPage));
        }


        private async void Save()
            {
                try
                {
                    // open/create a file
                    StorageFolder storageFolder = ApplicationData.Current.LocalFolder;
                    StorageFile testFile = await storageFolder.CreateFileAsync("testi.dat", CreationCollisionOption.OpenIfExists);

                    // save to disk
                    Stream stream = await testFile.OpenStreamForWriteAsync();
                    DataContractSerializer serializer = new DataContractSerializer(typeof(List<string>));
                    serializer.WriteObjectContent(stream, exercise);
                    await stream.FlushAsync();
                    stream.Dispose();
                }
                catch (Exception ex)
                {
                    Debug.WriteLine("Following exception has happend (writing): " + ex.ToString());
                }
                }
    
    }
}
