using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using Dapper;
using YumYum.Models;

namespace YumYum.Repositories
{
    public class ReviewsRepository
    {
        private readonly IDbConnection _db;

        public ReviewsRepository(IDbConnection db)
        {
            _db = db;
        }

        internal Review Create(Review r)
        {
            string sql = @"
                INSERT INTO 
                reviews(title, body, rating, creatorId, foodPlaceId)
                VALUES (@Title, @Body, @Rating, @CreatorId, @RestaurantId);
                SELECT LAST_INSERT_ID();
            ";
            r.Id = _db.ExecuteScalar<int>(sql, r);
            return r;
        }

        public List<Review> GetReviews(int foodPlaceId)
        {
            string sql = @"
                SELECT 
                    r.*,
                    a.* 
                FROM reviews r
                JOIN Accounts a ON a.id = r.creatorId
                WHERE r.foodPlaceId = @foodPlaceId;
            ";

            return _db.Query<Review, Profile, Review>(sql, (r, p) =>
            {
                r.Creator = p;
                return r;
            }, new { foodPlaceId }).ToList();
        }
    }
}