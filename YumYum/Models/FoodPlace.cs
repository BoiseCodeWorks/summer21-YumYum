using System;
using YumYum.Interfaces;

namespace YumYum.Models
{
    public class FoodPlace : IDbItem<int>
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public DateTime CreatedAt { get; set; }
        public DateTime UpdatedAt { get; set; }
        public string CreatorId { get; set; }

        // REVIEW Dapper populates virtuals
        public Account Creator { get; set; }

    }
}