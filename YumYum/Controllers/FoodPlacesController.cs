using System.Collections.Generic;
using System.Threading.Tasks;
using CodeWorks.Auth0Provider;
using YumYum.Models;
using YumYum.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace YumYum.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class FoodPlacesController : ControllerBase
    {

        private readonly FoodPlacesService _rs;

        public FoodPlacesController(FoodPlacesService rs)
        {
            _rs = rs;
        }

        [HttpGet]
        public ActionResult<List<FoodPlace>> GetAll()
        {
            try
            {
                List<FoodPlace> FoodPlaces = _rs.GetAll();
                return Ok(FoodPlaces);
            }
            catch (System.Exception e)
            {
                return BadRequest(e.Message);
            }
        }

        [HttpGet("{id}")]
        public ActionResult<FoodPlace> Get(int id)
        {
            try
            {
                FoodPlace FoodPlace = _rs.Get(id);
                return Ok(FoodPlace);
            }
            catch (System.Exception e)
            {
                return BadRequest(e.Message);
            }
        }

        [HttpGet("{id}/reviews")]
        public ActionResult<List<Review>> GetReviews(int id)
        {
            try
            {
                List<Review> reviews = _rs.GetReviews(id);
                return Ok(reviews);
            }
            catch (System.Exception e)
            {
                return BadRequest(e.Message);
            }
        }


        [Authorize]
        [HttpPost]
        public async Task<ActionResult<FoodPlace>> Create([FromBody] FoodPlace r)
        {
            try
            {
                Account userInfo = await HttpContext.GetUserInfoAsync<Account>();
                // REVIEW DO NOT TRUST THE CLIENT..... EVER
                r.CreatorId = userInfo.Id;
                FoodPlace newR = _rs.Create(r);
                // REVIEW cool inheritance thing account : profile
                newR.Creator = userInfo;
                return Ok(newR);

            }
            catch (System.Exception e)
            {
                return BadRequest(e.Message);
            }
        }

        [Authorize]
        [HttpPut("{id}")]

        public async Task<ActionResult<FoodPlace>> Update(int id, [FromBody] FoodPlace r)
        {
            try
            {
                Account userInfo = await HttpContext.GetUserInfoAsync<Account>();
                // REVIEW DO NOT TRUST THE CLIENT..... EVER
                r.Id = id;
                FoodPlace newR = _rs.Update(r, userInfo.Id);
                // REVIEW cool inheritance thing account : profile
                newR.Creator = userInfo;
                return Ok(newR);

            }
            catch (System.Exception e)
            {
                return BadRequest(e.Message);
            }
        }
        // REVIEW if not using [authorize] always null check the userInfo with elvis ?
        [Authorize]
        [HttpDelete("{id}")]

        public async Task<ActionResult<string>> Remove(int id)
        {
            try
            {
                // REVIEW DO NOT TRUST THE CLIENT..... EVER
                Account userInfo = await HttpContext.GetUserInfoAsync<Account>();
                _rs.Remove(id, userInfo.Id);
                return Ok("Successfully Removed");

            }
            catch (System.Exception e)
            {
                return BadRequest(e.Message);
            }
        }

    }
}