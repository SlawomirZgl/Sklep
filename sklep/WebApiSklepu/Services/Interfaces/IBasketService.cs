using Services.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Services
{
    public interface IBasketService
    {
        IEnumerable<BasketItemDto> Get();
        IEnumerable<BasketItemDto> Post(int productId, double count);
        IEnumerable<BasketItemDto> Put(int basketItemId, double count);
        IEnumerable<BasketItemDto> Delete(int basketItemId);
        bool Clear();
        
    }
}
