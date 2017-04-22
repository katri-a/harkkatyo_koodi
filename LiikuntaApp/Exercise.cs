using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LiikuntaApp
{
   public class Exercise : INotifyPropertyChanged
    {
        private string name;
        public string Name
        {
            get { return name; }
            set
            {
                name = value;
                RaisePropertyChanged();
            }
        }

        private void RaisePropertyChanged()
        {
            throw new NotImplementedException();
        }

        private string exercise_name;
        public string Exercise_name
        {
            get { return exercise_name; }
            set
            {
                exercise_name = value;
                RaisePropertyChanged();
            }
        }

        private string date;
        public string Date
        {
            get { return date; }
            set
            {
                date = value;
                RaisePropertyChanged();
            }
        }

        private string comments;
        public string Comments
        {
            get { return comments; }
            set
            {
                comments = value;
                RaisePropertyChanged();
            }
        }

        private string time;

        public event PropertyChangedEventHandler PropertyChanged;

        public string Time
        {
            get { return time; }
            set
            {
                time = value;
                RaisePropertyChanged();
            }
        }
    }
}
