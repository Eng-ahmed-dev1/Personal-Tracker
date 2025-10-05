using Personal_Trackeer.Model;
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
using System.Windows.Shapes;

namespace Personal_Trackeer.Views
{
    /// <summary>
    /// Interaction logic for Add_New_User.xaml
    /// </summary>
    public partial class Add_New_User : Window
    {
        public Add_New_User()
        {
            InitializeComponent();
        }

        private void AddNewUser(object sender, RoutedEventArgs e)
        {
            try
            {
                using var context = new PersonalTrackerDB();
                string name = txtUsername.Text;
                string email = txtEmail.Text;

                if (!int.TryParse(txtPassword.Password, out int pass))
                {
                    MessageBox.Show("The Password Must Be a Number !!");
                    return;

                }

                var redan = context.Users.FirstOrDefault(u => u.Name == name || u.Email == email);

                if (redan != null)
                {
                    MessageBox.Show("This user already exist !!");
                }

                var user = new Users
                {
                    Name = name,
                    Email = email,
                    Balance = 5000m,
                    Visas = new List<Visa>
                    {
                    new Visa
                         {
                             Password = pass,
                         }
                    }
                };

                context.Users.Add(user);
                context.SaveChanges();
                MessageBox.Show("User added successfully!");
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.InnerException?.Message ?? ex.Message);
            }
        }
    }
}