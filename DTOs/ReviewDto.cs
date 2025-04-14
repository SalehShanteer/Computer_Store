using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DTOs
{
    public class ReviewDto
    {
        public int? ID { get; set; }
        public int? ProductID { get; set; }
        public int? UserID { get; set; }
        public string? ReviewText { get; set; }
        public byte? Rating { get; set; }
        public DateTime? ReviewDate { get; set; }

        public ReviewDto()
        {
            this.ID = null;
            this.ProductID = null;
            this.UserID = null;
            this.ReviewText = null;
            this.Rating = null;
            this.ReviewDate = null;
        }

        public ReviewDto(int? id, int? productID, int? userID,
                       string? reviewText, byte? rating, DateTime? reviewDate)
        {
            this.ID = id;
            this.ProductID = productID;
            this.UserID = userID;
            this.ReviewText = reviewText;
            this.Rating = rating;
            this.ReviewDate = reviewDate;
        }
    }
}
