﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WildflowerCoffeeGifts.Models;
using Microsoft.Data.SqlClient;
using Dapper;

namespace WildflowerCoffeeGifts.DataAccess
{
    public class ProductsRepository
    {
        static List<Product> products = new List<Product>();

        const string _connectionString = "Server=localhost;Database=WCG;Trusted_Connection=True";
        public IEnumerable<Product> GetProducts()
        {
            using var db = new SqlConnection(_connectionString);
            var sql = @"select * 
                       from Products";

            var allProducts = db.Query<Product>(sql);

            return allProducts;
        }

        public Product ViewProductById(int id)
        {
            using var db = new SqlConnection(_connectionString);
            var sql = @"select * 
                        from Products
                        where Id = @id";

            var parameters = new { id = id };

            var singleProduct = db.QueryFirstOrDefault<Product>(sql, parameters);

            return singleProduct;
        }

        public Product NewProduct(Product newProduct)
        {
            var sql = @"INSERT INTO [dbo].[Products]
                        ([Title],
                        [ImageUrl],
                        [ProductThemeId],
                        [Price],
                        [Description],
                        [IsActive])
                        Output inserted.Id
                     VALUES
                       (@title,
                        @imageUrl,
                        @productThemeId,
                        @price,
                        @description,
                        @isActive)";

            using var db = new SqlConnection(_connectionString);

            var newProductId = db.ExecuteScalar<int>(sql, newProduct);

            var getProduct = @"select *
                                   from Products
                                   where Id = @id";

            var param = new { id = newProductId };

            var addNewProduct = db.QueryFirstOrDefault<Product>(getProduct, param);

            return addNewProduct;
        }

    }
}