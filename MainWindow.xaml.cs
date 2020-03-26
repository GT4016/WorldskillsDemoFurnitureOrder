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

namespace Worldskills
{
    /// <summary>
    /// Логика взаимодействия для MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private Random rand = new Random();
        private char[] symbols = new char[36] { 'A','B','C', 'D','E','F','G','H','I','J','K','L','M','N','O','P','Q','R','S','T','U','V','W','X','Y','Z','0','1','2','3','4','5','6','7','8','9' };
        private string CapString = "";
        private FurnitureDataBase DataBase = new FurnitureDataBase();
        private string[] roles = new string[] { "Заказчик", "Заместительдиректора", "Директор", "Менеджер", "Мастер" };
        public MainWindow()
        {
            InitializeComponent();
            generateCapschaString();
        }

        private void  LogInButton_Click(object sender, RoutedEventArgs e)
        {
            
            if (CapchaInput.Text != CapString)
            {
                nullTextBoxes();
            }
            else
            {
                var res = from  Users in DataBase.Users  where Users.Login== LoginTextBox.Text && Users.Password == PasswordInput.Password select Users;

                if (res.Count()==1)
                {
                    Window1 userswindow = new Window1();
                    userswindow.Owner = this;
                    userswindow.ShowDialog();
                    nullTextBoxes();
                    switch (res.First().Role)
                    {
                        case "Заказчик":
                            userswindow.CustomerGrid.Visibility = Visibility.Visible;
                            break;
                        case "Заместительдиректора":
                            userswindow.ZamDirGrid.Visibility = Visibility.Visible;
                            break;
                        case "Менеджер":
                            userswindow.ManagerGrid.Visibility = Visibility.Visible;
                            break;
                        case "Директор":
                            userswindow.DirectorGrid.Visibility = Visibility.Visible;
                            break;
                        case "Мастер":
                            userswindow.MasterGrid.Visibility = Visibility.Visible;
                            break;
                    }
                }
            }
        }

        private void nullTextBoxes()
        {
            generateCapschaString();
            LoginTextBox.Text = "";
            PasswordInput.Password = "";
        }

        void generateCapschaString() 
        {
            CapString = null;
            CapchaLabel.Content = null;
            for (int i = 0; i < 4; i++)
            {
                CapString += symbols[rand.Next(0, 35)];
            }
            CapchaLabel.Content = CapString;
        }

        private void LogUp_Click(object sender, RoutedEventArgs e)
        {

        }
    }
}
