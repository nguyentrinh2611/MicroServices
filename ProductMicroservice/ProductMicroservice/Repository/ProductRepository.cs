﻿using ProductMicroservice.DBContexts;
using ProductMicroservice.Models;
using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using System.Linq;

namespace ProductMicroservice.Repository
{
    public class ProductRepository : IProductRepository
    {
        private readonly ProductContext _dbContext;

        public ProductRepository(ProductContext dbContext)
        {
            _dbContext = dbContext;
        }

        public void DeleteProduct(int ProductId)
        {
            var product = _dbContext.Products.Find(ProductId);
            _dbContext.Products.Remove(product);
            Save();
        }
        public Product GetProductById(int ProductId)
        {
            return _dbContext.Products.Find(ProductId);
        }
        public IEnumerable<Product> GetProducts()
        {
            return _dbContext.Products.ToList();
        }

        public void InsertProduct(Product product)
        {
            _dbContext.Add(product);
            Save();
        }

        public void UpdateProduct(Product product)
        {
            _dbContext.Entry(product).State = EntityState.Modified;
            Save();
        }

        public void Save()
        {
            _dbContext.SaveChanges();
        }

        public Product GetProductByID(int ProductId)
        {
            throw new NotImplementedException();
        }
    }
}
