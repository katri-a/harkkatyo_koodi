using System;
using System.Collections.ObjectModel;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Runtime.Serialization;
using Windows.Foundation;
using Windows.Storage;
using Windows.UI.Popups;
using Windows.UI.ViewManagement;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Media.Imaging;
using Windows.UI.Xaml.Navigation;

namespace LiikuntaApp
{
    public sealed partial class MainPage : Page
    {
        // collection
        private ObservableCollection<Exercise> exercises;
        private object ExercisesListView;

        public MainPage()
        {
            this.InitializeComponent();

            // set window size
            ApplicationView.PreferredLaunchWindowingMode = ApplicationViewWindowingMode.PreferredLaunchViewSize;
            ApplicationView.PreferredLaunchViewSize = new Size(1000, 800);

            // read from disk
            //ReadExercises();
            /* bind collection to view
            ExercisesListView.ItemsSource = exercises;
            // select first friend
            if (exercises != null)
            {
                if (exercises.Count > 0) ExercisesListView.SelectedIndex = 0;
            }*/
        }

        /* maybe coming back from modify -> update friends UI
        protected override void OnNavigatedTo(NavigationEventArgs e)
        {
            if (ExercisesListView.SelectedIndex != -1) UpdateExercise(ExercisesListView.SelectedIndex);
            base.OnNavigatedTo(e);
        }*/

        // add a new friend
        private void AddButton_Click(object sender, RoutedEventArgs e)
        {
            this.Frame.Navigate(typeof(Add), exercises);
        }

        /* modify selected friend
        private void ModifyButton_Click(object sender, RoutedEventArgs e)
        {
            int index = ExercisesListView.SelectedIndex;
            if (index != -1)
            {
                this.Frame.Navigate(typeof(AddPage), exercises.ElementAt(index));
            }
        }*/

        /* delete button clicked, ask confirmation
        private async void DeleteButton_Click(object sender, RoutedEventArgs e)
        {
            var messageDialog = new MessageDialog("Delete a selected friend?");
            messageDialog.Commands.Add(new UICommand(
                "Ok",
                new UICommandInvokedHandler(this.Delete)));
            messageDialog.Commands.Add(new UICommand(
                "Cancel",
                new UICommandInvokedHandler(this.Delete)));
            messageDialog.DefaultCommandIndex = 0;
            messageDialog.CancelCommandIndex = 1;
            await messageDialog.ShowAsync();
        }

        // delete friend if OK pressed
        private void Delete(IUICommand command)
        {
            if (command.Label.Equals("Ok"))
            {
                // delete
                int index = FriendsListView.SelectedIndex;
                if (index != -1)
                {
                    friends.RemoveAt(index);
                }
                // show previous
                if (index > 0) FriendsListView.SelectedIndex = index - 1;
                // there is no previous, show first if there is some
                else if (friends.Count > 0) FriendsListView.SelectedIndex = 0;
                // no frieds left
                else
                {
                    NameTextBlock.Text = "";
                    AddressTextBlock.Text = "";
                    PhoneTextBlock.Text = "";
                    EmailTextBlock.Text = "";
                    InfoTextBlock.Text = "";
                    FriendImage.Source = null;
                }
            }
        }*/

        /* save button clicked
        private void SaveButton_Click(object sender, RoutedEventArgs e)
        {
            SaveExercises();
        }

        /* read data from disk
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
        }*/

        /* save friends to disk
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
        }*/

        /* a new friend is selected from the list
        private void FriendsListView_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (FriendsListView.SelectedIndex != -1)
            {
                UpdateFriend(FriendsListView.SelectedIndex);
            }
        }

        // update friends data in UI
        private async void UpdateFriend(int index)
        {
            // friend
            Friend friend = friends.ElementAt(index);
            // strings
            NameTextBlock.Text = friend.Name;
            AddressTextBlock.Text = friend.Address;
            PhoneTextBlock.Text = friend.Phone;
            EmailTextBlock.Text = friend.Email;
            InfoTextBlock.Text = friend.Info;
            // image
            try
            {
                StorageFolder localFolder = ApplicationData.Current.LocalFolder;
                StorageFile file = await localFolder.GetFileAsync(friend.Image);
                var stream = await file.OpenAsync(FileAccessMode.Read);
                BitmapImage image = new BitmapImage();
                image.SetSource(stream);
                FriendImage.Source = image;
            }
            catch (Exception ex)
            {
                Debug.WriteLine("Cannot read friends image from the disk!");
                Debug.WriteLine(ex);
            }
        }*/

        private void CalendarButton_Click(object sender, RoutedEventArgs e)
        {
            // add and navigate to a new page
            this.Frame.Navigate(typeof(CalendarPage));
        }



    }
}
