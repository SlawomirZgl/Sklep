using Models;
using Services.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Services
{
    class BasketService : IBasketService
    {
        private DataBase _database;

        public BasketService(DataBase database)
        {
            _database = database;
        }
        public bool Clear()
        {
            List<BasketItem> list = _database.BasketItems.Where(b => b.IdUser == _database.Users.First().Id).ToList();
            bool removed = false;
            if(list != null)
            {
                foreach(BasketItem b in list)
                {
                    _database.BasketItems.Remove(b);
                }                
                removed = true;
            }

            return removed;
        }

        public IEnumerable<BasketItemDto> Delete(int basketItemId)
        {
            BasketItem basketItem = _database.BasketItems.Where(b => b.Id == basketItemId).FirstOrDefault();
            if (basketItem != null)
            {
                _database.BasketItems.Remove(basketItem);
            }

            return Get();        
        }

        public IEnumerable<BasketItemDto> Get()
        {
            int firstUserId = _database.Users.First().Id;
            List<BasketItemDto> list = new List<BasketItemDto>();
            foreach(var b in _database.BasketItems)
            {
                if(b.IdUser == firstUserId)
                {
                    Product product = _database.Products.Where(p => p.Id == b.IdProduct).FirstOrDefault();
                    BasketItemDto basketItemDto = new BasketItemDto { Id = b.Id, Price = product.Price, Count = b.Count, Name = product.Name };
                    list.Add(basketItemDto);
                }
            }

            return list;
        }

        public IEnumerable<BasketItemDto> Post(int id, double count)
        {
            BasketItem basketItem = new BasketItem();
            _database.BasketItems.Add(new BasketItem { 
                                Count = count, 
                                IdProduct = id, 
                                IdUser = _database.Users.First().Id,
                            });
            _database.SaveChanges();

            return Get();
        }

        public IEnumerable<BasketItemDto> Put(int basketItemId, double count)
        {
            BasketItem basketItem = _database.BasketItems.Where(b => b.Id == basketItemId).FirstOrDefault();
            basketItem.Count = count;
            _database.BasketItems.Update(basketItem);
            return Get();
        }
    }
}
