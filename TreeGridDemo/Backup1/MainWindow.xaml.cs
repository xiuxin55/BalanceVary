using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace TreeGridDemo
{
    public partial class MainWindow : Window
    {
        private ObservableCollection<Person> People;
        private ObservableCollection<Person> DataSource;
        public MainWindow()
        {
            InitializeComponent();
            this.Loaded += MainWindow_Loaded;
        }

        private void BuildDataSource()
        {
            People = new ObservableCollection<Person>();
            for (int i = 0; i < 5; i++)
            {
                var p1 = new Person("ID" + i.ToString(), "Name" + i.ToString());
                p1.MarginLeft = 10;
                for (int j = 0; j < 3; j++)
                {
                    var p2 = new Person("ID" + i.ToString() + j.ToString(), "Name" + i.ToString() + j.ToString());
                    p2.MarginLeft = 30;
                    for (int t = 0; t < 3; t++)
                    {
                        var p3 = new Person("ID" + i.ToString() + j.ToString() + t.ToString(), "Name" + i.ToString() + j.ToString() + t.ToString());
                        p3.MarginLeft = 50;
                        p3.IsVisible = Visibility.Collapsed;
                        p2.Subordinates.Add(p3);
                    }
                    p1.Subordinates.Add(p2);
                }
                People.Add(p1);
            }
        }

        void MainWindow_Loaded(object sender, RoutedEventArgs e)
        {
            BuildDataSource();
            DataSource = new ObservableCollection<Person>();
            foreach (var p in People)
            {
                p.PropertyChanged += p_PropertyChanged;
                DataSource.Add(p);
            }
            TreeGrid.ItemsSource = DataSource;
        }

        void p_PropertyChanged(object sender, System.ComponentModel.PropertyChangedEventArgs e)
        {
            var selectedObj = sender as Person;
            if (selectedObj == null)
                return;
            if (selectedObj.IsChecked)
            {
                int next = DataSource.IndexOf(selectedObj) + 1;
                for (int i = 0; i < selectedObj.Subordinates.Count;i++ )
                {
                    var p = selectedObj.Subordinates[i];
                    if (DataSource.FirstOrDefault(t => t.Id == p.Id) != null)
                        return;
                    p.PropertyChanged += p_PropertyChanged;
                    p.IsChecked = false;
                    DataSource.Insert(next++, p);
                }
            }
            else if (!selectedObj.IsChecked)
            {
                for (int i = 0; i < selectedObj.Subordinates.Count; i++)
                {
                    var p = selectedObj.Subordinates[i];
                    RemoveNode(p);
                }
            }
        }

        private void RemoveNode(Person person)
        {
            for (int i = 0; i < person.Subordinates.Count; i++)
            {
                var p = person.Subordinates[i];
                RemoveNode(p);
            }
            for (int i = 0; i < DataSource.Count; i++)
            {
                var p = DataSource[i];
                if (p.Id == person.Id)
                    DataSource.Remove(p);
            }
        }
    }
}
