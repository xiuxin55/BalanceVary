using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace TreeGridDemo
{
    class Person : INotifyPropertyChanged
    {
        private String _id;
        public String Id
        {
            get
            {
                return _id;
            }
            set
            {
                _id = value;
            }
        }
        public String _name;
        public String Name
        {
            get
            {
                return _name;
            }
            set
            {
                _name = value;
            }
        }

        private double _marginLeft;
        public double MarginLeft
        {
            get
            {
                return _marginLeft;
            }
            set
            {
                _marginLeft = value;
            }
        }

        private bool _isChecked = false;
        public bool IsChecked
        {
            get
            {
                return _isChecked;
            }
            set
            {
                _isChecked = value;
                if (PropertyChanged != null)
                    PropertyChanged(this, new PropertyChangedEventArgs("IsChecked"));
            }
        }

        private Visibility _isVisible=Visibility.Visible;
        public Visibility IsVisible
        {
            get
            {
                return _isVisible;
            }
            set
            {
                _isVisible = value;
            }
        }

        private ObservableCollection<Person> _subordinates;
        public ObservableCollection<Person> Subordinates
        {
            get
            {
                return _subordinates ?? (_subordinates = new ObservableCollection<Person>());
            }
            set
            {
                _subordinates = value;
            }
        }

        public Person()
        {
        }
        public Person(String id, String name)
        {
            Id = id;
            Name = name;
        }

        public event PropertyChangedEventHandler PropertyChanged;
    }
}
