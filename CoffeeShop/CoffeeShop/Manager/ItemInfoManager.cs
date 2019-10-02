using System;
using System.Collections.Generic;
using System.Linq;
using System.Data;
using System.Data.SqlClient;
using System.Text;
using System.Threading.Tasks;
using CoffeeShop.Repository;
using CoffeeShop.Model;

namespace CoffeeShop.Manager
{
    public class ItemInfoManager
    {
        ItemInfoRepository _itemInfoRepository = new ItemInfoRepository();

        public bool AddItem(Item item)
        {
            return _itemInfoRepository.AddItem(item);
        }

        public bool IsItemrExist(Item item)
        {
            return _itemInfoRepository.IsItemExist(item);
        }

        public DataTable Display()
        {
            return _itemInfoRepository.Display();
        }

        public DataTable SearchItemByName(Item item)
        {
            return _itemInfoRepository.SearchItemByName(item);
        }

        public DataTable SearchItemById(Item item)
        {
            return _itemInfoRepository.SearchItemById(item);
        }

        public bool DeleteItem(Item item)
        {
            return _itemInfoRepository.DeleteItem(item);
        }

        public bool UpdateItem(Item item)
        {
            return _itemInfoRepository.UpdateItem(item);
        }
    }
}
