using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using CoffeeShop.Manager;
using CoffeeShop.Model;

namespace CoffeeShop
{
    public partial class OrderInformationUI : Form
    {
        OrderInfoManager _orderManager = new OrderInfoManager();
        CustomerInfoManager _customerInfoManager = new CustomerInfoManager();
        ItemInfoManager _itemManager = new ItemInfoManager();
        Customer _customer = new Customer();
        Order _order = new Order();

        public OrderInformationUI()
        {
            InitializeComponent();
        }

        private void addButton_Click(object sender, EventArgs e)
        {
            try
            {
                _order.CustomerId = Convert.ToInt32(customerComboBox.SelectedValue);
                _order.ItemId = Convert.ToInt32(itemComboBox.SelectedValue);

                if (String.IsNullOrEmpty(quantityTextBox.Text))
                {
                    MessageBox.Show("Please EnterQuantity..!");
                    return;
                }

                _order.Quantity = Convert.ToInt32(quantityTextBox.Text);


                if(_orderManager.AddOrder(_order))
                {
                    showDataGridView.DataSource = _orderManager.Display();
                    MessageBox.Show("Order Completed..!");
                }
                else
                {
                    MessageBox.Show("Order Not Completed..!");
                }
            }
            catch (Exception exception)
            {
                MessageBox.Show(exception.Message);
            }
        }

        private void showAllButton_Click(object sender, EventArgs e)
        {
            try
            {
                DataTable result = _orderManager.Display();
                if (result.Rows.Count > 0)
                {
                    showDataGridView.DataSource = result;
                }
                else
                {
                    MessageBox.Show("No Data Found");
                    return;
                }
            }
            catch (Exception exception)
            {
                MessageBox.Show(exception.Message);
                return;
            }
        }

        private void updateButton_Click(object sender, EventArgs e)
        {
            try
            {
                

                _order.CustomerId = Convert.ToInt32(customerComboBox.SelectedValue);
                _order.ItemId = Convert.ToInt32(itemComboBox.SelectedValue);

                DataTable searchOrderResult = _orderManager.SearchOrderById(_order);
                _order.ID = Convert.ToInt32(searchOrderResult.Rows[0]["ID"]);

                if (String.IsNullOrEmpty(quantityTextBox.Text))
                {
                    MessageBox.Show("Please Enter Quantity..!");
                    return;
                }
                _order.Quantity = Convert.ToInt32(quantityTextBox.Text);

                if (_orderManager.UpdateOrder(_order))
                {
                    showDataGridView.DataSource = _orderManager.Display();
                    MessageBox.Show("Updated Successfully...!");
                }
                else
                {
                    MessageBox.Show("Not Updated...!");
                }
            }
            catch(Exception exception)
            {
                MessageBox.Show(exception.Message);
            }
        }

        private void searchButton_Click(object sender, EventArgs e)
        {
            try
            {
                _order.CustomerId = Convert.ToInt32(customerComboBox.SelectedValue);

                DataTable result = _orderManager.SearchOrderById(_order);

                if (result.Rows.Count > 0)
                {
                    showDataGridView.DataSource = result;
                }
                else
                {
                    MessageBox.Show("No Data Found...!");
                    return;
                }
            }
            catch (Exception exception)
            {
                MessageBox.Show(exception.Message);
            }
        }

        private void deleteButton_Click(object sender, EventArgs e)
        {
            try
            {
                _order.ID = Convert.ToInt32(idTextBox.Text);

                DataTable result = _orderManager.SearchOrderById (_order);

                if (result.Rows.Count > 0)
                {
                    bool isDeleted = _orderManager.DeleteOrder(_order);

                    showDataGridView.DataSource = _orderManager.Display();

                    if (isDeleted)
                        MessageBox.Show("Delete Successfully...!");
                    else
                        MessageBox.Show("Not Deleted..!");
                }
                else
                {
                    MessageBox.Show("No Data Found With This ID...!");
                    return;
                }
            }
            catch(Exception exception)
            {
                MessageBox.Show(exception.Message);
            }
        }

        private void OrderInformationUI_Load(object sender, EventArgs e)
        {
            customerComboBox.DataSource = _orderManager.CustomerCombo();
            itemComboBox.DataSource = _orderManager.ItemCombo();
        }

        private void showDataGridView_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                DataGridViewRow dataGridViewRow = showDataGridView.Rows[e.RowIndex];

                idTextBox.Text = dataGridViewRow.Cells[0].Value.ToString();
                customerComboBox.Text = dataGridViewRow.Cells[1].Value.ToString();
                itemComboBox.Text = dataGridViewRow.Cells[2].Value.ToString();
                quantityTextBox.Text = dataGridViewRow.Cells[3].Value.ToString();
                totalBilltextBox.Text = dataGridViewRow.Cells[4].Value.ToString();
            }
        }

        private void quantityTextBox_Leave(object sender, EventArgs e)
        {
            if (!String.IsNullOrEmpty(quantityTextBox.Text))
            {
                Item _item = new Item();

                _item.ID = Convert.ToInt32(itemComboBox.SelectedValue);
                DataTable item = _itemManager.SearchItemById(_item);
                int totalBill = Convert.ToInt32(item.Rows[0]["Price"]) * Convert.ToInt32(quantityTextBox.Text);

                totalBilltextBox.Text = totalBill.ToString();
            }
            else
            {
                totalBilltextBox.Text = "";
            }
            
        }

        private void itemComboBox_Leave(object sender, EventArgs e)
        {
            if (!String.IsNullOrEmpty(quantityTextBox.Text))
            {
                Item _item = new Item();

                _item.ID = Convert.ToInt32(itemComboBox.SelectedValue);
                DataTable item = _itemManager.SearchItemById(_item);
                int totalBill = Convert.ToInt32(item.Rows[0]["Price"]) * Convert.ToInt32(quantityTextBox.Text);

                totalBilltextBox.Text = totalBill.ToString();
            }
            else
            {
                totalBilltextBox.Text = "";
            }
        }
    }
}
