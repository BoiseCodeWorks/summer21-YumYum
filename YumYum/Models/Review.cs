using System;
using System.ComponentModel.DataAnnotations;
using YumYum.Interfaces;

namespace YumYum.Models
{
    public class Review : IDbItem<int>
    {
        public int Id { get; set; }
        public DateTime CreatedAt { get; set; }
        public DateTime UpdatedAt { get; set; }
        [Required]
        public string Body { get; set; }
        public int Rating { get; set; }
        public string CreatorId { get; set; }
        public string FoodPlaceId { get; set; }
        public Profile Creator { get; set; }
    }

}