using System;
using System.Collections.Generic;
using YumYum.Models;
using YumYum.Repositories;

namespace YumYum.Services
{
    public class FoodPlacesService
    {
        private readonly FoodPlacesRepository _rp;
        private readonly ReviewsRepository _reviewsRepo;

        public FoodPlacesService(FoodPlacesRepository rp, ReviewsRepository reviewsRepo)
        {
            _rp = rp;
            _reviewsRepo = reviewsRepo;
        }

        public FoodPlace Create(FoodPlace r)
        {
            return _rp.Create(r);
        }

        public List<FoodPlace> GetAll()
        {
            return _rp.GetAll();
        }

        public FoodPlace Update(FoodPlace r, string id)
        {
            // Business Logic
            FoodPlace restaurant = _rp.GetById(r.Id);

            // let x = findOneAndUpdate({userId: userId, id: id}, update)

            if (restaurant == null)
            {
                throw new Exception("Invalid Id");
            }
            if (restaurant.CreatorId != id)
            {
                throw new Exception("You are not allowed to edit because you do not own this r");
            }

            return _rp.Update(r);
        }

        public FoodPlace Get(int id)
        {
            var r = _rp.GetById(id);
            if (r == null)
            {
                throw new Exception("Invalid Id");
            }
            return r;
        }

        public void Remove(int id, string userId)
        {
            // Business Logic
            // REVIEW notice I can re-use my own coolness
            FoodPlace restaurant = Get(id);

            // let x = findOneAndUpdate({userId: userId, id: id}, update)

            if (restaurant.CreatorId != userId)
            {
                throw new Exception("You are not allowed to delete because you do not own this r");
            }
            _rp.Remove(id);
        }

        public List<Review> GetReviews(int id)
        {
            return _reviewsRepo.GetReviews(id);
        }
    }
}