using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace KennellProject2
{
    public partial class Receipt : Form
    {
        public Receipt(Customer customer, ListBox listBox, string total, string discount, string final)
        {
            InitializeComponent();
            NameTextBox.Text = customer.Name;
            AddressTextBox.Text = customer.Address;
            EmailTextBox.Text = customer.EmailAddress;
            MailingListTextBox.Text = "" + customer.isOnMailList;
            for (int i = 0; i < listBox.Items.Count; i++)
                listBox1.Items.Add(listBox.Items[i]);
            totalLabel.Text = total;
            DiscountLabel.Text = discount;
            FinalLabel.Text = final;
        }

        private void ExitButton_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }
    }
}
