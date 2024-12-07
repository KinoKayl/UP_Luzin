using System;
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

namespace UP_Luzin.Pages
{
    /// <summary>
    /// Логика взаимодействия для UserPage.xaml
    /// </summary>
    public partial class UserPage : Page
    {
        public UserPage()
        {
            InitializeComponent();
            var currentUsers = Entities.GetContext().User_.ToList();
            ListUser.ItemsSource = currentUsers;
            ComboBoxSort.SelectedIndex = 0;
            UserCheckBox.IsChecked = false;
            UpdateUser();

        }

        public void UpdateUser()
        {
            var currentUsers = Entities.GetContext().User_.ToList();
            ListUser.ItemsSource = currentUsers;

            //Сортировка по введенному ФИО
            currentUsers = currentUsers.Where(x => x.FIO.ToLower().Contains(FIOBox.Text.ToLower())).ToList();
            
            //Сортировка по роли пользователь
            if (UserCheckBox.IsChecked == true)
            {
                currentUsers = currentUsers.Where(x => x.Role == 2).ToList();
            }

            //Сортировка в зависимости от выбора
            if (ComboBoxSort.SelectedIndex == 0)
            {
                ListUser.ItemsSource = currentUsers.OrderBy(x => x.FIO).ToList();
            }
            else
            {
                ListUser.ItemsSource = currentUsers.OrderByDescending(x => x.FIO).ToList();
            }
        }
        private void FIOBox_TextChanged(object sender, TextChangedEventArgs e)
        {
            UpdateUser();
        }

        private void ComboBoxSort_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            UpdateUser();
        }

        private void UserCheckBox_Checked(object sender, RoutedEventArgs e)
        {
            UpdateUser();
        }

        private void UserCheckBox_Unchecked(object sender, RoutedEventArgs e)
        {
            UpdateUser();
        }

        private void ClearButton_Click(object sender, RoutedEventArgs e)
        {
            UpdateUser();
        }
    }
}
