using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LAB_3.Models
{
    public class Student : INotifyPropertyChanged
    {
        private int _id;
        public int Id
        {
            get => _id;
            set
            {
                if (_id == value)
                {
                    return;
                }
                _id = value;
                OnProperetyChanged("Id");
            }
        }

        private string _name;
        public string Name
        {
            get => _name;
            set
            {
                if (_name == value)
                    return;
                _name = value;
                OnProperetyChanged("Name");
            }
        }

        private string _description;
        public string Description
        {
            get => _description;
            set
            {
                if (_description == value)
                    return;
                _description = value;
                OnProperetyChanged("Description");
            }
        }

        private string _typeOfStudents;
        public string TypeOfStudents
        {
            get => _typeOfStudents;
            set
            {
                if (_typeOfStudents == value)
                    return;
                _typeOfStudents = value;
                OnProperetyChanged("TypeOfStudents");
            }
        }

        private string _image;
        public string Image
        {
            get => _image; 
            set
            {
                if (_image == value)
                    return;
                _image = value;
                OnProperetyChanged("Image");
            }
        }

        public event PropertyChangedEventHandler PropertyChanged;

        protected virtual void OnProperetyChanged(string properetyName = "")
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(properetyName));
        }

    }
}
