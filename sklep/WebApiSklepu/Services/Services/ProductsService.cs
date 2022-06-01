using Models;
using Services.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Services
{
    class ProductsService : IProductsService
    {
        private DataBase _database;

        public ProductsService(DataBase database)
        {
            _database = database;
            if (!database.Products.Any())
            {
                database.AddRange(new List<Product>
                {
                    new Product{Description = "Opis 1", Name = "Produkt 1", Price = 10},
                    new Product{Description = "Opis 2", Name = "Produkt 2", Price = 20},
                    new Product{Description = "Opis 3", Name = "Produkt 3", Price = 30},
                    new Product{Description = "Opis 4", Name = "Produkt 4", Price = 40},
                    new Product{Description = "Opis 5", Name = "Produkt 5", Price = 50},
                });
            }
            database.SaveChanges();
        }

        public bool Delete(int productId)
        {
            bool removed = false;
            Product product = _database.Products.Where(p => p.Id == productId).FirstOrDefault();
            if (product != null)
            {
                removed = true;
                _database.Products.Remove(product);
            }
            _database.SaveChanges();
            return removed;
        }

        public PaginatedData<ProductDto> Get(PaginationDto dto)
        {
            PaginatedData<ProductDto> data = new PaginatedData<ProductDto>();

            data.Count = _database.Products.Count();

            switch (dto.SortColumn)
            {
                case "name":
                    if (dto.SortAscending)
                    {
                        data.Data = _database.Products.OrderBy(p => p.Name).Select(x => new ProductDto
                        {
                            Name = x.Name,
                            Description = x.Description,
                            Price = x.Price,
                            Id = x.Id,
                        });
                    }
                    else
                    {
                        data.Data = _database.Products.OrderByDescending(p => p.Name).Select(x => new ProductDto
                        {
                            Name = x.Name,
                            Description = x.Description,
                            Price = x.Price,
                            Id = x.Id,
                        });
                    }
                    break;
                case "description":
                    if (dto.SortAscending)
                    {
                        data.Data = _database.Products.OrderBy(p => p.Description).Select(x => new ProductDto
                        {
                            Name = x.Name,
                            Description = x.Description,
                            Price = x.Price,
                            Id = x.Id,
                        });
                    }
                    else
                    {
                        data.Data = _database.Products.OrderByDescending(p => p.Description).Select(x => new ProductDto
                        {
                            Name = x.Name,
                            Description = x.Description,
                            Price = x.Price,
                            Id = x.Id,
                        });
                    }
                    break;
                case "price":
                    if (dto.SortAscending)
                    {
                        data.Data = _database.Products.OrderBy(p => p.Price).Select(x => new ProductDto
                        {
                            Name = x.Name,
                            Description = x.Description,
                            Price = x.Price,
                            Id = x.Id,
                        });
                    }
                    else
                    {
                        data.Data = _database.Products.OrderByDescending(p => p.Price).Select(x => new ProductDto
                        {
                            Name = x.Name,
                            Description = x.Description,
                            Price = x.Price,
                            Id = x.Id,
                        });
                    }
                    break;
                case "id":
                    if (dto.SortAscending)
                    {
                        data.Data = _database.Products.OrderBy(p => p.Id).Select(x => new ProductDto
                        {
                            Name = x.Name,
                            Description = x.Description,
                            Price = x.Price,
                            Id = x.Id,
                        });
                    }
                    else
                    {
                        data.Data = _database.Products.OrderByDescending(p => p.Id).Select(x => new ProductDto
                        {
                            Name = x.Name,
                            Description = x.Description,
                            Price = x.Price,
                            Id = x.Id,
                        });
                    }
                    break;
                default:
                    // code block
                    break;
            }

            return data;
        }

        public ProductDto GetById(int productid)
        {
            Product product = _database.Products.SingleOrDefault(x => x.Id == productid);

            if (product == null)
                return null;

            return new ProductDto
                        {
                            Id = product.Id,
                            Description = product.Description,
                            Name = product.Name,
                            Price = product.Price,
                        };
        }

        public ProductDto Post(PostProductDto dto)
        {
            _database.Products.Add(new Product { Name = dto.Name, Description = dto.Description, Price = dto.Price });
            var product = _database.Products.LastOrDefault();
            ProductDto productDto = new ProductDto { Id = product.Id, Description = product.Description, 
                                                        Name = product.Name, Price = product.Price };
            _database.SaveChanges();
            return productDto;
        }

        public ProductDto Put(int productId, PostProductDto dto)
        {
            Product product = _database.Products.Where(p => p.Id == productId).FirstOrDefault();
            product.Name = dto.Name;
            product.Description = dto.Description;
            product.Price = dto.Price;
            _database.Products.Update(product);
            ProductDto p = 
                new ProductDto
                {
                    Id = product.Id,
                    Price = product.Price,
                    Description = product.Description,
                    Name = product.Name
                };
            _database.SaveChanges();
            return p;
        }
    }
}
