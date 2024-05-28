using AutoMapper;
using GeekShopping.ProductsApi.Data.ValueObjects;
using GeekShopping.ProductsApi.Model;

namespace GeekShopping.ProductsApi.Config
{
    public class MappingConfig
    {
        public static MapperConfiguration RegisterMaps()
        {
            var mappingConfig = new MapperConfiguration(config =>
            {
                config.CreateMap<ProductVO, Product>();
                config.CreateMap<Product, ProductVO>();
            });

            return mappingConfig;
        }
    }
}
