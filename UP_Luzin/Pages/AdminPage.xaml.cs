﻿using System;
using System.Collections.Generic;
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
using UP_Luzin.Pages;

namespace UP_Luzin
{
    /// <summary>
    /// Логика взаимодействия для AdminPage.xaml
    /// </summary>
    public partial class AdminPage : Page
    {
        private readonly Entities db;
        public AdminPage()
        {
            InitializeComponent();
            db = new Entities();

            DataGridUsers.ItemsSource = db.User_.ToList();
        }

        private void AddButton_Click(object sender, RoutedEventArgs e)
        {
            NavigationService?.Navigate(new AddUserPage(null));
        }

        private void DeleteButton_Click(object sender, RoutedEventArgs e)
        {
            // NavigationService?.Navigate(new AddUserPage((sender as Button).DataContext as User_));
            var usersForRemoving = DataGridUsers.SelectedItems.Cast<User_>().ToList();

            if (MessageBox.Show($"Вы точно хотите удалить записи в количестве {usersForRemoving.Count()} элементов?", "Внимание",
                            MessageBoxButton.YesNo, MessageBoxImage.Question) == MessageBoxResult.Yes)
            {
                try
                {
                    Entities.GetContext().User_.RemoveRange(usersForRemoving);
                    Entities.GetContext().SaveChanges();
                    MessageBox.Show("Данные успешно удалены!");

                    DataGridUsers.ItemsSource = Entities.GetContext().User_.ToList();
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message.ToString());
                }
            }
        }

        private void RedactButton_Click(object sender, RoutedEventArgs e)
        {
            NavigationService?.Navigate(new AddUserPage((sender as Button).DataContext as User_));

        }

        private void Page_IsVisibleChanged(object sender, DependencyPropertyChangedEventArgs e)
        {
            if (Visibility == Visibility.Visible)
            {
                Entities.GetContext().ChangeTracker.Entries().ToList().ForEach(x => x.Reload());
                DataGridUsers.ItemsSource = Entities.GetContext().User_.ToList();
            }
            
            
        }
    }
}
