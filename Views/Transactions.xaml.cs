    using Personal_Trackeer.Model;
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Net.WebSockets;
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
using Microsoft.EntityFrameworkCore;


namespace Personal_Trackeer.Views
{
    /// <summary>
    /// Interaction logic for Transactions.xaml
    /// </summary>
    public partial class Transactions : Window
    {
        public Transactions()
        {
            InitializeComponent();
        }

        private void Withdraw(object sender, RoutedEventArgs e)
        {
            try
            {
                using var context = new PersonalTrackerDB();

                if (!int.TryParse(UID.Text, out int USID))
                {
                    MessageBox.Show("The Id Must Be Number ");
                    return;
                }
                if (!int.TryParse(Vcode.Text, out int Code))
                {
                    MessageBox.Show("The Code of Visa Must Be Number ");
                    return;
                }
                if (!int.TryParse(Pass.Password, out int pass))
                {
                    MessageBox.Show("The Password Must Be Number ");
                    return;

                }
                if (!decimal.TryParse(WithVal.Text, out decimal withdrawVal))
                {
                    MessageBox.Show("The Id Value Be Number ");
                    return;
                }
                if (withdrawVal < 0)
                {
                    MessageBox.Show("You must first deposit firstly. your balance less than zero. ");
                }

                var user = context.Users.FirstOrDefault(u => u.Id == USID);

                if (user != null)
                {
                    var visa = context.Users
                        .Include(u => u.Visas)
                        .FirstOrDefault(u => u.Id == USID);

                    if (visa != null)
                    {
                        if (user.Balance >= withdrawVal)
                        {
                            user.Balance -= withdrawVal;
                            context.SaveChanges();
                            MessageBox.Show("Withdraw successful!");
                        }
                        else
                        {
                            MessageBox.Show("Insufficient balance!");
                        }
                    }
                    else
                    {
                        MessageBox.Show("Invalid Visa Code or Password!");
                    }
                }
                else
                {
                    MessageBox.Show("User not found!");

                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.InnerException?.Message ?? ex.Message);
            }
        }

        private void Deposite(object sender, RoutedEventArgs e)
        {
            using var context = new PersonalTrackerDB();
            try
            {
                if (!int.TryParse(UIDD.Text, out int USID))
                {
                    MessageBox.Show("The Id Must Be Number ");
                    UIDD.Focus();
                    return;
                }
                if (!int.TryParse(Vcode2.Text, out int Code))
                {
                    MessageBox.Show("The Code of Visa Must Be Number ");
                    Vcode2.Focus();
                    return;
                }
                if (!int.TryParse(Pass2.Password, out int pass))
                {
                    MessageBox.Show("The Password Must Be Number ");
                    Pass2.Focus();
                    return;

                }
                if (!decimal.TryParse(DepVal.Text, out decimal DepVal1) || DepVal1 <= 0)
                {
                    MessageBox.Show("Deposit amount must be greater than 0");
                    DepVal.Focus();
                    return;
                }

                var user1 = context.Users.FirstOrDefault(x => x.Id == USID);

                if (user1 != null)
                {
                    var visa1 = context.Users
                        .Include(u => u.Visas)
                        .FirstOrDefault(u => u.Id == USID);

                    if (visa1 != null)
                    {

                        user1.Balance += DepVal1;
                        context.SaveChanges();
                        MessageBox.Show("Deposit successful!");

                    }
                    else
                    {
                        MessageBox.Show("Invalid Visa Code or Password!");

                    }
                }
                else
                {
                    MessageBox.Show("User not found!");

                }

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.InnerException?.Message ?? ex.Message);
            }

        }
    }
}