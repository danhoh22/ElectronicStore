using Library;
using Microsoft.AspNetCore.Mvc;
using TestOperations;

namespace ElectronicStore.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class ReviewController : ControllerBase
    {
        private readonly ReviewAccess _reviewAccess;

        public ReviewController(ReviewAccess reviewAccess)
        {
            _reviewAccess = reviewAccess;
        }

        [HttpGet("{reviewId}", Name = "GetReviewById")]
        public ActionResult<Review> GetById(int reviewId)
        {
            var review = _reviewAccess.GetReviewById(reviewId);
            if (review == null)
            {
                return NotFound();
            }
            return review;
        }

        [HttpGet(Name = "GetAllReviews")]
        public ActionResult<IEnumerable<Review>> GetAll()
        {
            var reviews = _reviewAccess.GetAllReview();
            return Ok(reviews);
        }

        [HttpPost(Name = "AddReview")]
        public IActionResult Add(Review review)
        {
            _reviewAccess.AddReview(review);
            return CreatedAtRoute("GetReviewById", new { reviewId = review.ReviewId }, review);
        }

        [HttpPut("{reviewId}", Name = "UpdateReview")]
        public IActionResult Update(int reviewId, Review review)
        {
            if (reviewId != review.ReviewId)
            {
                return BadRequest();
            }

            _reviewAccess.UpdateReview(review);
            return NoContent();
        }

        [HttpDelete("{reviewId}", Name = "DeleteReview")]
        public IActionResult Delete(int reviewId)
        {
            _reviewAccess.DeleteReview(reviewId);
            return NoContent();
        }
    }
}
