using AutoMapper;
using GeekShooping.ProductAPI.Data.ValueObjects;
using GeekShooping.ProductAPI.Model;
using GeekShooping.ProductAPI.Model.Contex;
using Microsoft.EntityFrameworkCore;

namespace GeekShooping.ProductAPI.Repository
{
    public class ProductRepository : IProductRepository
    {
        private readonly MySQLContex _contex;
        private IMapper _mapper;

        public ProductRepository(MySQLContex contex, IMapper mapper)
        {
            _contex = contex;
            _mapper = mapper;
        }

        public async Task<IEnumerable<ProductVo>> FindAll()
        {
            List<Product> products = await _contex.Products.ToListAsync();
            return _mapper.Map<List<ProductVo>>(products);
        }

        public async Task<ProductVo> FindById(long id)
        {
            Product product = 
                await _contex.Products.Where(p => p.Id == id)
                .FirstOrDefaultAsync();
            return _mapper.Map<ProductVo>(product);
        }
        public async Task<ProductVo> Create(ProductVo vo)
        {
            Product product = _mapper.Map<Product>(vo);
            _contex.Products.Add(product);
            await _contex.SaveChangesAsync();
            return _mapper.Map<ProductVo>(product);
        }

        public async Task<ProductVo> Update(ProductVo vo)
        {
            Product product = _mapper.Map<Product>(vo);
            _contex.Products.Add(product);
            await _contex.SaveChangesAsync();
            return _mapper.Map<ProductVo>(product);
        }


        public async Task<bool> Delete(long id)
        {
            try
            {
                Product product =
                await _contex.Products.Where(p => p.Id == id)
                    .FirstOrDefaultAsync();
                if (product == null) return false;
                _contex.Products.Remove(product);
                await _contex.SaveChangesAsync();
                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }
    }
}
