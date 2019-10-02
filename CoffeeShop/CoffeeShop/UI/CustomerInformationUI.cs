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
    public partial class CustomerInformationUI : Form
    {
        CustomerInfoManager _customerManager = new CustomerInfoManager();
        Customer _customer = new Customer();

        public CustomerInformationUI()
        {
            InitializeComponent();
        }

        private void addButton_Click(object sender, EventArgs e)
        {
            try
            {
                if (String.IsNullOrEmpty(customerNameTextBox.Text))
                {
                    MessageBox.Show("Please Enter Customer Name..!");
                    return;
                }

                _customer.Name = customerNameTextBox.Text;

                if (_customerManager.IsCustomerExist(_customer))
                {
                    MessageBox.Show("This Customer Already Exist..!");
                    return;
                }

                if (String.IsNullOrEmpty(contactTextBox.Text))
                {
                    MessageBox.Show("Please Enter Valid Mobile Number..!");
                    return;
                }

                if (String.IsNullOrEmpty(addressTextBox.Text))
                {
                    MessageBox.Show("Please Enter Customer Address..!");
                    return;
                }

                _customer.Contact = contactTextBox.Text;
                _customer.Address = addressTextBox.Text;

                if(_customerManager.AddCustomer(_customer))
                {
                    showDataGridView.DataSource = _customerManager.Display();
                    MessageBox.Show("Customer Added Successfully...!");
                }
                else
                {
                    MessageBox.Show("Not Added...!");
                }
            }
            catch(Exception exception)
            {
                MessageBox.Show(exception.Message);
            }
        }

        private void showAllButton_Click(object sender, EventArgs e)
        {
            try
            {
                DataTable result = _customerManager.Display();

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
            catch(Exception exception)
            {
                MessageBox.Show(exception.Message);
                return;
            }  
        }

        private void updateButton_Click(object sender, EventArgs e)
        {
            try
            {
                //Validation
                if(String.IsNullOrEmpty(idTextBox.Text))
                {
                    MessageBox.Show("Please Enter a ID for Update...!");
                    return;
                }
                _customer.ID = Convert.ToInt32(idTextBox.Text);

                DataTable result = _customerManager.SearchCustomerById(_customer);
                if (result.Rows.Count == 0)
                {
                    MessageBox.Show("No Data Found with this ID");
                    return;
                }

                if (String.IsNullOrEmpty(customerNameTextBox.Text))
                {
                    MessageBox.Show("Please Enter Name...!");
                    return;
                }
                if (String.IsNullOrEmpty(contactTextBox.Text))
                {
                    MessageBox.Show("Please Enter contact number...!");
                    return;
                }
                if (String.IsNullOrEmpty(addressTextBox.Text))
                {
                    MessageBox.Show("Please Enter Address...!");
                    return;
                }

                _customer.Name = customerNameTextBox.Text;

                DataTable isNameExist = _customerManager.SearchCustomerByName(_customer);

                if (isNameExist.Rows.Count > 0 && (Convert.ToInt32(isNameExist.Rows[0]["ID"]) != Convert.ToInt32(idTextBox.Text)))
                {
                    MessageBox.Show("Customer Name already Exist...!");
                    return;
                }

                //Update
                if(_customerManager.UpdateCustomer(Convert.ToInt32(idTextBox.Text),customerNameTextBox.Text, contactTextBox.Text, addressTextBox.Text))
                {
                    showDataGridView.DataSource = _customerManager.Display();
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
                if (String.IsNullOrEmpty(customerNameTextBox.Text))
                {
                    MessageBox.Show("Please Enter a Name...!");
                    return;
                }

                _customer.Name = customerNameTextBox.Text;

                DataTable result = _customerManager.SearchCustomerByName(_customer);

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
            catch(Exception exception)
            {
                MessageBox.Show(exception.Message);
            }
            
        }

        private void deleteButton_Click(object sender, EventArgs e)
        {
            try
            {
                if (String.IsNullOrEmpty(idTextBox.Text))
                {
                    MessageBox.Show("Please Enter ID...!");
                    return;
                }

                _customer.ID = Convert.ToInt32(idTextBox.Text);

                DataTable result = _customerManager.SearchCustomerById(_customer);

                if (result.Rows.Count > 0)
                {
                    bool isDeleted = _customerManager.DeleteCustomer(Convert.ToInt32(idTextBox.Text));

                    showDataGridView.DataSource = _customerManager.Display();

                    if (isDeleted)
                        MessageBox.Show("Delete Successfully...!");
                    else
                        MessageBox.Show("Not Deleted..!");
                }
                else
                {
                    MessageBox.Show("No Data Found with this ID...!");
                    return;
                }
            }
            catch(Exception exception)
            {
                MessageBox.Show(exception.Message);
            }
            
        }

        private void showDataGridView_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                DataGridViewRow dataGridViewRow = showDataGridView.Rows[e.RowIndex];

                idTextBox.Text = dataGridViewRow.Cells[0].Value.ToString();
                customerNameTextBox.Text = dataGridViewRow.Cells[1].Value.ToString();
                contactTextBox.Text = dataGridViewRow.Cells[2].Value.ToString();
                addressTextBox.Text = dataGridViewRow.Cells[3].Value.ToString();
            }
        }
    }
}
