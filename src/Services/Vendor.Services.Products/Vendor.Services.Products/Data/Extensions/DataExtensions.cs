﻿using Microsoft.AspNetCore.Builder;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Vendor.Services.Products.Data.Persistence;
using Vendor.Services.Products.Data.Persistence.Interface;

namespace Vendor.Services.Products.Data.Extensions;

public static class DataExtensions
{
    public static void AddPersistence(this WebApplicationBuilder builder, string stringName = "Database")
    {
        var connectionString = builder.Configuration.GetConnectionString(stringName);
        builder.Services.AddDbContext<ProductsDbContext>(o => o.UseSqlServer(connectionString));
        builder.Services.AddTransient<IProductsDbContext, ProductsDbContext>();
        builder.Services.AddTransient<ProductsDbContext, ProductsDbContext>();
    }

    public static void EnsureDatabaseCreated(this WebApplication app)
    {
        using var scope = app.Services.CreateScope();
        var db = scope.ServiceProvider.GetService<ProductsDbContext>();
        db!.Database.EnsureCreated();
    }
}