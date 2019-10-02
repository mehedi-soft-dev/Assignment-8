using System;
using System.Collections.Generic;
using System.Linq;
using System.Data;
using System.Text;
using System.Threading.Tasks;
using CoffeeShop.Repository;
using CoffeeShop.Model;

namespace CoffeeShop.Manager
{
    public class OrderInfoManager
    {
        OrderInfoRepository _orderRepository = new OrderInfoRepository();
        CustomerInfoRepository _customerRepository = new CustomerInfoRepository();
        ItemInfoRepository _itemRepository = new ItemInfoRepository();
        Item _item = new Item();

        public bool AddOrder(Order order)
        {
            _item.ID = order.ItemId;
            DataTable item = _itemRepository.SearchItemById(_item);
            order.TotalPrice = Convert.ToInt32(item.Rows[0]["Price"].ToString()) * order.Quantity;
            
            
            return _orderRepository.AddOrder(order);
        }

        public DataTable Display()
        {
            return _orderRepository.Display();
        }

        public bool IsCustomerExist(Customer customer)
        {
            return _customerRepository.IsCustomerExist(customer);
        }

        public bool IsOrderExist(Order order)
        {
            return _orderRepository.IsOrderExist(order);
        }

        public bool UpdateOrder(Order order)
        {
            _item.ID = order.ItemId;

              
            DataTable searchItem = _itemRepository.SearchItemById(_item);
            order.TotalPrice = Convert.ToInt32(searchItem.Rows[0]["Price"].ToString()) * order.Quantity;

            return _orderRepository.UpdateOrder(order);
        }

        public DataTable SearchOrderByName(Order order)
        {
            return _orderRepository.SearchOrderByName(order);
        }

        public DataTable SearchOrderById(Order order)
        {
            return _orderRepository.SearchOrderById(order);
        }

        public bool DeleteOrder(Order order)
        {
            return _orderRepository.DeleteOrder(order);
        }

        public DataTable CustomerCombo()
        {
            return _orderRepository.CustomerCombo();
        }
        public DataTable ItemCombo()
        {
            return _orderRepository.ItemCombo();
        }
    }
}
