using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using System.Runtime.Serialization;
using System.Text;
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
using System.Threading.Tasks;
using System.Threading;

// The Blank Page item template is documented at http://go.microsoft.com/fwlink/?LinkId=234238

namespace LiikuntaApp
{
    /// <summary>
    /// Add new exercise-page.
    /// </summary>
    public sealed partial class Add : Page
    {
        private Exercise exercise;
        private ObservableCollection<Exercise> exercises = new ObservableCollection<Exercise>();


        // constructor
        public Add()
        {
            this.InitializeComponent();
        }


        protected override void OnNavigatedTo(NavigationEventArgs e)
        {
            if (e.Parameter is ObservableCollection<Exercise>)
            {
                exercises = (ObservableCollection<Exercise>)e.Parameter;
                saveButton.Content = "Tallenna";
            }

            if (e.Parameter is Exercise)
            {
                exercise = (Exercise)e.Parameter;
                nameTextBox.Text = exercise.Name;
                exerciseTextBox.Text = exercise.Exercise_name;
                timeTextBox.Text = exercise.Time;
                sleepTextBox.Text = exercise.Comments;

                saveButton.Content = "Tallenna";
            }

            base.OnNavigatedTo(e);
        }

        // save-button click
        private void SaveButton_Click(object sender, RoutedEventArgs e)
        {
            // add a new
            if (saveButton.Content.ToString().EndsWith("Tallenna"))
            {
                DateTime date = datePickerDate.Date.DateTime;
                exercise = new Exercise(nameTextBox.Text, exerciseTextBox.Text, timeTextBox.Text, date.Date.ToString("dd-mm-yyyy"), sleepTextBox.Text);
            }

            // add
            if (saveButton.Content.ToString().EndsWith("Tallenna"))
            {
                exercises.Add(exercise);
                SaveExercises(exercises);
            }

        }

        // save to disk
        private async void SaveExercises(ObservableCollection<Exercise> saveData)
        {
            StorageFolder storageFolder = ApplicationData.Current.LocalFolder;

            StorageFile employeesFile = await storageFolder.CreateFileAsync("exercises.txt", CreationCollisionOption.OpenIfExists);
            Stream stream = await employeesFile.OpenStreamForWriteAsync();
            DataContractSerializer serializer = new DataContractSerializer(typeof(ObservableCollection<Exercise>));
            serializer.WriteObject(stream, exercises);
            await stream.FlushAsync();
            stream.Dispose();
        }

        // to Calendar-page
        private void CalendarButton_Click(object sender, RoutedEventArgs e)
        {
            this.Frame.Navigate(typeof(CalendarPage));
        }

        private void BackButton_Click(object sender, RoutedEventArgs e)
        {
            this.Frame.Navigate(typeof(MainPage));
        }
    }
}

