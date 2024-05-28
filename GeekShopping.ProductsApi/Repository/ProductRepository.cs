using AutoMapper;
using GeekShopping.ProductsApi.Data.ValueObjects;
using GeekShopping.ProductsApi.Model;
using GeekShopping.ProductsApi.Model.Context;
using Microsoft.EntityFrameworkCore;

namespace GeekShopping.ProductsApi.Repository
{
    public class ProductRepository : IProductRepository
    {
        private readonly MySqlContext _context;
        private IMapper _mapper;

        public ProductRepository(MySqlContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public async Task<IEnumerable<ProductDto>> FindAll()
        {
            List<Product> products = await _context.Products.ToListAsync();
            return _mapper.Map<List<ProductDto>>(products);
        }

        public async Task<ProductDto> FindById(long id)
        {
            Product product = await _context.Products.Where(p => p.Id == id).FirstOrDefaultAsync();
            return _mapper.Map<ProductDto>(product);
        }

        public Task<ProductDto> Create(ProductDto productDto)
        {
            throw new NotImplementedException();
        }

        public Task<bool> Delete(long id)
        {
            throw new NotImplementedException();
        }

        public Task<ProductDto> Update(ProductDto productDto)
        {
            throw new NotImplementedException();
        }
    }
}
