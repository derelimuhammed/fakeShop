﻿using AutoMapper;
using ECommerceProject.Domain.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ECommerceProject.Application.Features.Commands.ProductCom.CreateProduct;
using ECommerceProject.Application.Features.Queries.ProductQuery.GetAllProduct;

namespace ECommerceProject.Application.Profiles
{
    public class ProductProfile:Profile
    { 
        public ProductProfile()
        {
            CreateMap<CreateProductCommandRequest, Product>();
            CreateMap<Product,GetAllProductQueryResponse>();
        }
    }
}