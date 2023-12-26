﻿using AutoMapper;
using Microsoft.AspNetCore.Http;
using PashaBank.Core.Abstractions;
using PashaBank.Core.Models;
using PashaBank.Core.Models.Enums;
using PashaBank.Services.Abstractions;
using PashaBank.Services.Models.RequestModels.Product;
using PashaBank.Services.Models.RequestModels.Sales;
using PashaBank.Services.Models.ResponseModels.ProductsAndSales;
using PashaBank.Services.Models.ResponseModels.Sales;

namespace PashaBank.Services.Implementation
{
    public class ProductSaleService : IProductSaleService
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;
        public ProductSaleService(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }
        public async Task<UpdateProductResponse> UpdateProduct(ProductDto entity, int id)
        {
            var product = _unitOfWork.Products.GetById(id);
            if (product == null)
            {
                var productToUpdate = await _mapper.Map(entity, product);
                _unitOfWork.Products.Update(productToUpdate);
                await _unitOfWork.SaveAsync();
                return new UpdateProductResponse { Message = "პროდუქტი წარმატებით დააბდეითდა", StatusCode = StatusCodes.Status200OK };
            }
            return new UpdateProductResponse { Message = $"პროდუქტი აიდით{id} ვერ მოიძებნა ", StatusCode = StatusCodes.Status200OK };
        }
        public async Task<AddProductResponse> AddProduct(ProductDto entity)
        {
            var productToInsert = _mapper.Map<Product>(entity);
            await _unitOfWork.Products.Add(productToInsert);
            return new AddProductResponse
            {
                Message = "Product Inserted successfully!",
                StatusCode = StatusCodes.Status200OK
            };
        }
        public async Task<GetProductsResponse> GetProducts()
        {
            var result = await _unitOfWork.Products.GetAllAsync();
            var ProductToReturn = _mapper.Map<List<ProductDto>>(result);
            if (result != null)
            {
                return new GetProductsResponse
                {
                    Products = ProductToReturn,
                    Message = "Products Returned successfully!",
                    StatusCode = StatusCodes.Status200OK
                };
            }
            return new GetProductsResponse
            {
                Products = ProductToReturn,
                Message = $"{nameof(ProductToReturn)}",
                StatusCode = StatusCodes.Status404NotFound
            };
        }
        public async Task<CreateSaleResponse> AddSale(SaleDto entity)
        {
            var saleToCreate = _mapper.Map<Sale>(entity);
            if (saleToCreate.SoldProducts == null)
            {
                saleToCreate.SoldProducts = new List<Product>();
            }
            await _unitOfWork.Sales.Add(saleToCreate);
            await _unitOfWork.SaveAsync();
            return new CreateSaleResponse
            {
                Message = "Sale Created successfully!",
                StatusCode = StatusCodes.Status200OK,
            };
        }
        public async Task<GetSaleResponse> GetSalesByUserId(int userId, DateTime startDate, DateTime endDate)
        {
            var result = await _unitOfWork.Sales
                .FindAsync(s => s.UserId == userId && s.SaleDate >= startDate && s.SaleDate <= endDate);
            var salesToReturn = _mapper.Map<List<SaleDto>>(result);
            if (result != null)
            {
                return new GetSaleResponse
                {
                    Message = "Sales Returned Successfully!",
                    StatusCode = StatusCodes.Status200OK,
                    Sales = salesToReturn
                };
            }

            return new GetSaleResponse
            {
                Message = "Sales Returned Successfully!",
                StatusCode = StatusCodes.Status404NotFound,
                Sales = salesToReturn
            };

        }
    }
}
