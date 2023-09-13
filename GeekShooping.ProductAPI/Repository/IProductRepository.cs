using GeekShooping.ProductAPI.Data.ValueObjects;
using GeekShooping.ProductAPI.Model;

namespace GeekShooping.ProductAPI.Repository
{
    public interface IProductRepository
    {
        Task<IEnumerable<ProductVo>> FindAll();
        Task<ProductVo> FindById(long id);
        Task<ProductVo> Create(ProductVo vo);
        Task<ProductVo> Update(ProductVo vo);
        Task<bool> Delete(long id);
    }
}
