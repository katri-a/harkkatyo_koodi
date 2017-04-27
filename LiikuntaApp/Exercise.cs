using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;
using System.Runtime.Serialization;
using System.IO;



namespace LiikuntaApp
{
    // Ohjelmistopuolen kaveri auttoi koodin kanssa ja lisäsi DataContract
    [DataContract]
    public class Exercise
    {

        public Exercise(string _name, string _exercise_name, string _date, string _comments, string _time)
        {
            name = _name;
            exercise_name = _exercise_name;
            date = _date;
            comments = _comments;
            time = _time;

        }

        [DataMember]
        private string name;
        public string Name
        {
            get { return name; }
            set
            {
                name = value;
            }
        }

        [DataMember]
        private string exercise_name;
        public string Exercise_name
        {
            get { return exercise_name; }
            set
            {
                exercise_name = value;
            }
        }

        [DataMember]
        private string date;
        public string Date
        {
            get { return date; }
            set
            {
                date = value;
            }
        }

        [DataMember]
        private string comments;
        public string Comments
        {
            get { return comments; }
            set
            {
                comments = value;
            }
        }

        [DataMember]
        private string time;

        public string Time
        {
            get { return time; }
            set
            {
                time = value;
            }
        }
    }
}
