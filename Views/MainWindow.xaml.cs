using Microsoft.EntityFrameworkCore;
using Personal_Trackeer.Model;
using Personal_Trackeer.Views;
using System.Linq;
using System.Text;
using System.Windows;

namespace Personal_Tracker
{
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }

        private void Trans(object sender, RoutedEventArgs e)
        {
            Transactions transactions = new Transactions();
            transactions.Show();
            this.Close();
        }

        private void AddNewUser(object sender, RoutedEventArgs e)
        {
            Add_New_User Nuser = new Add_New_User();
            Nuser.Show();
            this.Close();
        }

        private void LoadUsers()
        {
            using var context = new PersonalTrackerDB();

            var userData = context.Users
                .Include(u => u.Visas)
                .Select(u => new
                {
                    u.Name,
                    u.Email,
                    u.Balance,
                    VisasInfo = string.Join(", ", u.Visas.Select(v => $"Code:{v.Code}\nPass:{v.Password}"))
                })
                .ToList();

            var displayText = new StringBuilder();

            foreach (var user in userData)
            {
                displayText.AppendLine($"Name: {user.Name}");
                displayText.AppendLine($"Email: {user.Email}");
                displayText.AppendLine($"Balance: {user.Balance}");
                displayText.AppendLine($"Visas{user.VisasInfo}");
                displayText.AppendLine(new string('-', 40));
            }

            Screen2.Text = displayText.ToString();
        }


        private void GetAll(object sender, RoutedEventArgs e)
        {
            LoadUsers();
        }

        private void GetSpacificUser(object sender, RoutedEventArgs e)
        {
            try
            {
                using var context = new PersonalTrackerDB();
                if (!int.TryParse(ForGet.Text, out int userId))
                {
                    MessageBox.Show("Please enter a valid numeric Id!");
                    return;
                }

                var Spauser = context.Users.Find(userId);
                if (Spauser != null)
                {
                    Labname.Content = Spauser.Name;
                    txtbalance.Text = Spauser.Balance.ToString();
                }
                else
                {
                    MessageBox.Show("User does not exist!");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void DeleteUser(object sender, RoutedEventArgs e)
        {
            try
            {
                using var context = new PersonalTrackerDB();
                if (!int.TryParse(ForDel.Text, out int userId))
                {
                    MessageBox.Show("Please enter a valid numeric Id!");
                    return;
                }

                var deluser = context.Users.Find(userId);
                if (deluser != null)
                {
                    var userVisas = context.Visa.Where(v => v.User_id == userId).ToList();
                    context.Visa.RemoveRange(userVisas);

                    context.Users.Remove(deluser);
                    context.SaveChanges();

                    MessageBox.Show("User and related visas deleted successfully!");
                    LoadUsers();
                }
                else
                {
                    MessageBox.Show("User does not exist!");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
    }
}