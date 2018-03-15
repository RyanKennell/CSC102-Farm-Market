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
    public partial class Main : Form
    {
        private decimal totalCost = 0;
        private Customer customer;
        private PictureBox[] pictureBoxes;
        private Label[] invalidLabels;

        public Main()
        {
            InitializeComponent();
            this.tableTableAdapter.Fill(this.productsDataSet.Table);
            pictureBoxes = new PictureBox[] { pictureBox1, pictureBox2, pictureBox3, pictureBox4, pictureBox5 };
            invalidLabels = new Label[] { label10, label11, label12, label13, label14 };
        }

        /// <summary>
        /// Adds up the total cost of all purchases made in one
        /// add to cart click. 
        /// 
        ///Calculates the discount and updates the 
        ///total, discount, and final labels
        /// </summary>
        private void CartButton_Click_1(object sender, EventArgs e)
        {
            totalCost += getPurchase(IDTextBox1, ItemNameTextBox1, ItemPriceTextBox1, QuantityTextBox1, 0);
            totalCost += getPurchase(IDTextBox2, ItemNameTextBox2, ItemPriceTextBox2, QuantityTextBox2, 1);
            totalCost += getPurchase(IDTextBox3, ItemNameTextBox3, ItemPriceTextBox3, QuantityTextBox3, 2);
            totalCost += getPurchase(IDTextBox4, ItemNameTextBox4, ItemPriceTextBox4, QuantityTextBox4, 3);
            totalCost += getPurchase(IDTextBox5, ItemNameTextBox5, ItemPriceTextBox5, QuantityTextBox5, 4);
            totalLabel.Text = "Total: " + totalCost.ToString("c");

            decimal discount = 0m;
            if (totalCost >= 501 && totalCost < 1000)
                discount = .05m;
            if (totalCost > 1000)
                discount = .1m;

            DiscountLabel.Text = "Discount " + discount * 100 + "%";
            FinalLabel.Text = "Final: " + (totalCost * (1 - discount)).ToString("c");
        }

        /// <summary>
        /// Creates a instance of the Receipt class and
        /// hides the current form while displaying the
        /// instance of reciept.
        /// </summary>
        /// <param name="sender">Not Used</param>
        /// <param name="e">Not Used</param>
        private void PurchaseButton_Click_1(object sender, EventArgs e)
        {
            this.Hide();
            Receipt receipt = new Receipt(customer, listBox1, totalLabel.Text, DiscountLabel.Text, FinalLabel.Text);
            receipt.ShowDialog();
            this.Close();
        }

        /// <summary>
        /// Tests the validity of the input, if the input
        /// is valid, the purchase will be carried out
        /// and the shopping cart and indicator labels
        /// will be updated
        /// 
        /// if not, the validity indicators will be updated
        /// </summary>
        /// <param name="t1">ID of the item</param>
        /// <param name="t2">Name of the item</param>
        /// <param name="t3">Price of the item</param>
        /// <param name="t4">Quantity of the item</param>
        /// <param name="iteration">Level of the row being purchased</param>
        /// <returns></returns>
        private decimal getPurchase(TextBox t1, TextBox t2, TextBox t3, TextBox t4, int iteration)
        {
            int quantity = 0;
            decimal price = 0;

            try
            {
                //test the validity of the input
                Int32.TryParse(t4.Text, out quantity);
                price = decimal.Parse("" + this.tableTableAdapter.PurchaseQuery(Int32.Parse(t1.Text), t2.Text.ToLower(), Decimal.Parse(t3.Text), quantity));

                updateConfirmationPicture(iteration, true);
                updateShoppingCart(t2.Text, t4.Text);
            }
            catch
            {
                updateConfirmationPicture(iteration, false);
            }
            return price * quantity;
        }

        /// <summary>
        /// updates the confirmation pictures and labels
        /// off of the validity of the data 
        /// </summary>
        /// <param name="iteration">the current line of item request</param>
        /// <param name="state">is the item valid or not</param>
        private void updateConfirmationPicture(int iteration, bool state)
        {
            if (state)
            {
                pictureBoxes[iteration].Image = imageList1.Images[0];
                invalidLabels[iteration].Text = "Confirmed!";
            }
            else
            {
                pictureBoxes[iteration].Image = imageList1.Images[1];
                invalidLabels[iteration].Text = "Invalid Data!";
            }
        }

        /// <summary>
        /// Iterates through the items in the shopping cart to test
        /// if the item being bought already exists, if it does, the
        /// quantity is updated, if it doesn't, a new item is added
        /// </summary>
        /// <param name="name">Name of the item being updated to the shopping cart</param>
        /// <param name="quantity">the quantity being added to the total</param>
        private void updateShoppingCart(string name, string quantity)
        {
            for (int i = 0; i < listBox1.Items.Count; i++)
            {
                if (listBox1.Items[i].ToString().Contains(name.ToLower() + "("))
                {
                    int length = listBox1.Items[i].ToString().Length;
                    int oldQuantity = Int32.Parse(listBox1.Items[i].ToString().Substring(name.Length + 1, length - (name.Length + 2)));
                    int updatedQuantity = oldQuantity + Int32.Parse(quantity);

                    listBox1.Items[i] = name.ToLower() + "(" + updatedQuantity + ")";
                    return;
                }
            }
            listBox1.Items.Add(name.ToLower() + "(" + quantity + ")");
        }

        /// <summary>
        /// Checks to see if all fields are filled to create a customer
        /// if they are, a customer is created
        /// </summary>
        /// <param name="sender">Not Used</param>
        /// <param name="e">Not Used</param>
        private void SubmitButton_Click(object sender, EventArgs e)
        {
            bool mailList = checkBox1.Checked;

            //ignore the customer and add them anyways
            //mailList = true;

            //evaluating if customer fields are met
            if ((NameTextBox.Text.Equals("") || AddressTextBox.Text.Equals("") || EmailTextBox.Text.Equals("")))
                return;

            customer = new Customer(NameTextBox.Text, AddressTextBox.Text, EmailTextBox.Text, mailList);

            PurchaseButton.Enabled = true;
            CartButton.Enabled = true;
            groupBox1.Enabled = true;
            SubmitButton.Enabled = false;
        }

        /// <summary>
        /// Exits the application upon clicking 
        /// the exit button
        /// </summary>
        /// <param name="sender">Not Used</param>
        /// <param name="e">Not Used</param>
        private void ExitButton_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }
    }
}
