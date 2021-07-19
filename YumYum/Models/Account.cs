using System;
using System.Collections.Generic;
using YumYum.Interfaces;

namespace YumYum.Models
{
    public class Account : Profile, IDbItem<string>
    {
        public string Id { get; set; }
        public string Email { get; set; }
        public DateTime CreatedAt { get; set; }
        public DateTime UpdatedAt { get; set; }
    }

}