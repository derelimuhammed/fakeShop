using AutoMapper;
using ECommerceProject.Domain.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ECommerceProject.Application.Features.Commands.ProductCom.CreateProduct;
using ECommerceProject.Application.Features.Commands.ProductCom.UpdateProduct;
using ECommerceProject.Application.Features.Queries.ProductQuery.GetAllProduct;
using ECommerceProject.Application.DTOs;
using Microsoft.AspNetCore.Identity;
using ECommerceProject.Application.Features.Commands.AppUser.AppUserRegister;

namespace ECommerceProject.Application.Profiles
{
    public class ProductProfile:Profile
    { 
        public ProductProfile()
        {
            CreateMap<CreateProductCommandRequest, Product>();
            CreateMap<Product,GetAllProductQueryResponse>();
            CreateMap<UpdateProductCommandRequest,Product>();
            CreateMap<Product, GetProductByPageSizeDto>();
            CreateMap<IdentityResult, AppUserRegisterCommandResponse>();
            CreateMap<AppUserRegisterCommandRequest, AppUser>().ReverseMap();
        }
    }
}
