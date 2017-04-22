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
        // link to main page collection
        private ObservableCollection<Exercise> exercises;


        // constructor
        public void AddPage()
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


                saveButton.Content = "Modify";
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
            // add / modify data

            nameTextBox.Text = exercise.Name;
            exerciseTextBox.Text = exercise.Exercise_name;
            timeTextBox.Text = exercise.Time;
            //DatePicker.DefaultStyleKeyProperty
            sleepTextBox.Text = exercise.Comments;

            exercise.Name = nameTextBox.Text;
            exercise.Exercise_name = exerciseTextBox.Text;
            exercise.Time = timeTextBox.Text;
            //date täytyy lisätä
            exercise.Comments = sleepTextBox.Text;

            // add
            if (saveButton.Content.ToString().EndsWith("Tallenna"))
            {
                exercises.Add(exercise);
            }

        }

        // save friends to disk
        private async void SaveExercises()
        {
            try
            {
                // folder
                StorageFolder storageFolder = ApplicationData.Current.LocalFolder;

                // delete file if exists
                IStorageItem employeesItem = await storageFolder.TryGetItemAsync("ecercises.dat");
                if (await storageFolder.TryGetItemAsync("exercises.dat") != null)
                {
                    await employeesItem.DeleteAsync();
                }
                // -> save collection
                StorageFile employeesFile = await storageFolder.CreateFileAsync("exercises.dat", CreationCollisionOption.OpenIfExists);
                // save friends to disk
                Stream stream = await employeesFile.OpenStreamForWriteAsync();
                DataContractSerializer serializer = new DataContractSerializer(typeof(ObservableCollection<Exercise>));
                serializer.WriteObject(stream, exercises);
                await stream.FlushAsync();
                stream.Dispose();
                ShowMessageBox("Tallennettu.");
            }
            catch (Exception ex)
            {
                ShowMessageBox(ex.Message);
            }
        }

        // show message box
        private async void ShowMessageBox(string message)
        {
            var messageDialog = new MessageDialog(message);
            messageDialog.Commands.Add(new UICommand("Ok"));
            messageDialog.DefaultCommandIndex = 0;
            await messageDialog.ShowAsync();
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
    }
}

