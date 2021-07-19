using System;
using YumYum.Models;
using YumYum.Repositories;

namespace YumYum.Services
{
    public class ReviewsService
    {
        private readonly ReviewsRepository _rp;

        public ReviewsService(ReviewsRepository rp)
        {
            _rp = rp;
        }

        internal Review Create(Review r)
        {
            return _rp.Create(r);
        }
    }

}