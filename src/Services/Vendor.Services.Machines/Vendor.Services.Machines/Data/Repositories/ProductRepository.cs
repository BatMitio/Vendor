﻿using Newtonsoft.Json;
using Vendor.Domain.Entities;
using Vendor.Domain.Types;
using Vendor.Services.Machines.Data.Repositories.Interfaces;

namespace Vendor.Services.Machines.Data.Repositories;

public class ProductRepository : IProductRepository
{
    private readonly HttpClient _httpClient;

    public ProductRepository(HttpClient httpClient)
    {
        _httpClient = httpClient;
    }

    public async Task<ApiResponse<Product>> GetProductAsync(string name)
    {
        var responseString = await _httpClient.GetStringAsync("products/GetProduct");

        var response = JsonConvert.DeserializeObject<ApiResponse<Product>>(responseString)!;
        return response;
    }
}