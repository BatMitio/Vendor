﻿using AutoMapper;
using Vendor.Domain.Entities;
using Vendor.Services.Products.Commands.CreateProductCommand;
using Vendor.Services.Products.DTO;
using Vendor.Services.Products.Views;

namespace Vendor.Services.Products.MappingProfiles;

public class ProductProfiles : Profile
{
    public ProductProfiles()
    {
        CreateMap<CreateProductDto, CreateProductCommand>();
        CreateMap<Product, ProductView>();
    }
}