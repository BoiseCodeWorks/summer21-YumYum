using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using Dapper;
using YumYum.Models;

namespace YumYum.Repositories
{
    public class FoodPlacesRepository
    {
        private readonly IDbConnection _db;

        public FoodPlacesRepository(IDbConnection db)
        {
            _db = db;
        }

        internal FoodPlace Create(FoodPlace r)
        {
            string sql = @"
                INSERT INTO 
                food_places(name, creatorId)
                VALUES (@Name, @CreatorId);
                SELECT LAST_INSERT_ID();
            ";
            r.Id = _db.ExecuteScalar<int>(sql, r);
            return r;
        }

        internal FoodPlace GetById(int id)
        {
            string sql = @"
            SELECT 
                r.*, 
                a.* 
            FROM food_places r 
            JOIN Accounts a ON a.id = r.creatorId
            WHERE r.id = @id";
            return _db.Query<FoodPlace, Account, FoodPlace>(sql, (r, a) =>
            {
                r.Creator = a;
                return r;
            }, new { id }).FirstOrDefault();
        }

        internal List<FoodPlace> GetAll()
        {
            string sql = @"
            SELECT 
            r.*,
            a.* 
            FROM food_places r
            JOIN Accounts a ON r.creatorId = a.id;";
            // REVIEW item1 = r item2 = a, what returns
            return _db.Query<FoodPlace, Account, FoodPlace>(sql,
            // similar to array.map
            (r, a) =>
            {
                r.Creator = a;
                return r;
            }, splitOn: "id").ToList();
        }

        internal FoodPlace Update(FoodPlace r)
        {
            string sql = @"
            UPDATE food_places 
            SET 
                name = @Name
            WHERE id = @Id;
            ";
            _db.Execute(sql, r);
            return r;
        }

        internal void Remove(int id)
        {
            string sql = "DELETE FROM food_places WHERE id = @id LIMIT 1;";
            _db.Execute(sql, new { id });
        }
    }
}