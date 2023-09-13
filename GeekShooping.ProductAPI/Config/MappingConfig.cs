﻿using AutoMapper;
using GeekShooping.ProductAPI.Data.ValueObjects;
using GeekShooping.ProductAPI.Model;

namespace GeekShooping.ProductAPI.Config
{
    public class MappingConfig
    {
        public static MapperConfiguration RegisterMaps() 
        { 
            var mappingConfig = new MapperConfiguration(config =>
            {
                config.CreateMap<ProductVo, Product>();
                config.CreateMap<Product, ProductVo>();
            }); 
            return mappingConfig;
        }
    }
}
