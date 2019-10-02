using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using CoffeeShop.Manager;
using CoffeeShop.Model;

namespace CoffeeShop
{
    public partial class ItemInformationUI : Form
    {
        ItemInfoManager _itemInfoManager = new ItemInfoManager();
        Item _item = new Item();

        public ItemInformationUI()
        {
            InitializeComponent();
        }

        private void addButton_Click(object sender, EventArgs e)
        {
            try
            {
                if (String.IsNullOrEmpty(itemNameTextBox.Text))
                {
                    MessageBox.Show("Please Enter Item Name...!");
                    return;
                }

                _item.Name = itemNameTextBox.Text;

                if (_itemInfoManager.IsItemrExist(_item))
                {
                    MessageBox.Show("Item already Exist..!");
                    return;
                }

                if (String.IsNullOrEmpty(priceTextBox.Text))
                {
                    MessageBox.Show("Please Enter Item Price...!");
                    return;
                }

                _item.Price = Convert.ToInt32(priceTextBox.Text);

                if(_itemInfoManager.AddItem(_item))
                {
                    showDataGridView.DataSource = _itemInfoManager.Display();
                    MessageBox.Show("Item Added Successfully..!");
                }
                else
                {
                    MessageBox.Show("Not Added..!");
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
                DataTable result = _itemInfoManager.Display();
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
                if (String.IsNullOrEmpty(idTextBox.Text))
                {
                    MessageBox.Show("Please Enter a ID for Update...!");
                    return;
                }

                _item.ID = Convert.ToInt32(idTextBox.Text);

                DataTable result = _itemInfoManager.SearchItemById(_item);
                if(result.Rows.Count == 0)
                {
                    MessageBox.Show("No Data Found With this ID..!");
                    return;
                }

                if (String.IsNullOrEmpty(itemNameTextBox.Text))
                {
                    MessageBox.Show("Please Enter Item Name...!");
                    return;
                }

                _item.Name = itemNameTextBox.Text;

                if (String.IsNullOrEmpty(priceTextBox.Text))
                {
                    MessageBox.Show("Please Enter Price...!");
                    return;
                }

                _item.Price = Convert.ToInt32(priceTextBox.Text);

                DataTable isItemExist = _itemInfoManager.SearchItemByName(_item);

                if (isItemExist.Rows.Count > 0 && (Convert.ToInt32(isItemExist.Rows[0]["ID"]) != Convert.ToInt32(idTextBox.Text)))
                {
                    MessageBox.Show("Item already Exist...!");
                    return;
                }
                    
                //Update
                if (_itemInfoManager.UpdateItem(_item))
                {
                    showDataGridView.DataSource = _itemInfoManager.Display();
                    MessageBox.Show("Item Information Updated Successfully...!");
                }
                else
                {
                    if (result.Rows.Count <= 0)
                        MessageBox.Show("No Data Found with this ID...!");
                }
            }
            catch (Exception exception)
            {
                MessageBox.Show(exception.Message);
            }
        }

        private void searchButton_Click(object sender, EventArgs e)
        {
            try
            {
                if (String.IsNullOrEmpty(itemNameTextBox.Text))
                {
                    MessageBox.Show("Please Enter a Name...!");
                    return;
                }

                _item.Name = itemNameTextBox.Text;

                DataTable result = _itemInfoManager.SearchItemByName(_item);

                if (result.Rows.Count > 0)
                {
                    showDataGridView.DataSource = result;
                }
                else
                {
                    MessageBox.Show("No Data Found With This Name...!");
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
                if (String.IsNullOrEmpty(idTextBox.Text))
                {
                    MessageBox.Show("Please Enter a ID...!");
                    return;
                }

                _item.ID = Convert.ToInt32(idTextBox.Text);

                DataTable result = _itemInfoManager.SearchItemById(_item);

                if (result.Rows.Count > 0)
                {
                    bool isDeleted = _itemInfoManager.DeleteItem(_item);

                    showDataGridView.DataSource = _itemInfoManager.Display();

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

        private void showDataGridView_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                DataGridViewRow dataGridViewRow = showDataGridView.Rows[e.RowIndex];

                idTextBox.Text = dataGridViewRow.Cells[0].Value.ToString();
                itemNameTextBox.Text = dataGridViewRow.Cells[1].Value.ToString();
                priceTextBox.Text = dataGridViewRow.Cells[2].Value.ToString();
            }
        }
    }
}
