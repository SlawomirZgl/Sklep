using Services.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Services
{
    public interface IProductsService
    {
        PaginatedData<ProductDto> Get(PaginationDto dto);
        ProductDto Put(int productId, PostProductDto sto);
        ProductDto Post(PostProductDto sto);
        bool Delete(int produtId);
    }
}
