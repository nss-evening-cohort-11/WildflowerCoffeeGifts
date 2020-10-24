﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WildflowerCoffeeGifts.Models;
using Microsoft.Data.SqlClient;
using Dapper;

namespace WildflowerCoffeeGifts.DataAccess
{
    public class ProductThemeRepository
    {
        static List<ProductTheme> productThemes = new List<ProductTheme>();

        const string _connectionString = "Server=localhost;Database=WCG;Trusted_Connection=True";

        public IEnumerable<ProductTheme> GetAllThemes()
        {
            using var db = new SqlConnection(_connectionString);
            var sql = "select * from ProductThemes";

            var allThemes = db.Query<ProductTheme>(sql);

            return allThemes;
        }
    }
}
