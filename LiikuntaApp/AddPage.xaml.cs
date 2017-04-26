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
using Windows.UI.Popups;
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
    /// Lisää uusi harjoitus-sivu.
    /// </summary>
    public sealed partial class Add : Page
    {
       

        // lisää tai muuta harjoituksia
        private Exercise exercise;

        private ObservableCollection<Exercise> exercises = new ObservableCollection<Exercise>();


        // constructor
        public Add()
        {
            this.InitializeComponent();
        }

        // page is navigated to
        protected override void OnNavigatedTo(NavigationEventArgs e)
        {
            // add
            if (e.Parameter is ObservableCollection<Exercise>)
            {
                exercises = (ObservableCollection<Exercise>)e.Parameter;
                saveButton.Content = "Tallenna";
            }
            // modify
            if (e.Parameter is Exercise)
            {
                exercise = (Exercise)e.Parameter;
                nameTextBox.Text = exercise.Name;
                exerciseTextBox.Text = exercise.Exercise_name;
                timeTextBox.Text = exercise.Time;
                //DatePicker.DefaultStyleKeyProperty
                sleepTextBox.Text = exercise.Comments;


                saveButton.Content = "Tallenna";
            }

            base.OnNavigatedTo(e);
        }

        // add/modify button clicked
        private void SaveButton_Click(object sender, RoutedEventArgs e)
        {
            // add a new
            if (saveButton.Content.ToString().EndsWith("Tallenna"))
            {
                exercise = new Exercise();
            }
           
            // add
            if (saveButton.Content.ToString().EndsWith("Tallenna"))
            {
                exercises.Add(exercise);
            }

        }
        
        // save to disk
        private async void SaveExercises()
        {
                // folder
                StorageFolder storageFolder = ApplicationData.Current.LocalFolder;


                // -> save collection
                StorageFile employeesFile = await storageFolder.CreateFileAsync("exercises.dat", CreationCollisionOption.OpenIfExists);
                // save friends to disk
                Stream stream = await employeesFile.OpenStreamForWriteAsync();
                DataContractSerializer serializer = new DataContractSerializer(typeof(ObservableCollection<Exercise>));
                serializer.WriteObject(stream, exercises);
                await stream.FlushAsync();
                stream.Dispose();
            
               
        }

     
        /* save button clicked
        private void SaveButton_Click(object sender, RoutedEventArgs e)
        {
            SaveExercises();
        }*/

        // Selaa suorituksia-sivulle
        private void CalendarButton_Click(object sender, RoutedEventArgs e)
        {
            // add and navigate to a new page
            this.Frame.Navigate(typeof(CalendarPage));
        }

        /*private void AddButton_Click(object sender, RoutedEventArgs e)
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
        }*/
        private void BackButton_Click(object sender, RoutedEventArgs e)
        {
            // add and navigate to a new page
            this.Frame.Navigate(typeof(MainPage));
        }
    }
}

