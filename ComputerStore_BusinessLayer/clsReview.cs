using ComputerStore_DataAccessLayer;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DTOs;

namespace ComputerStore_BusinessLayer
{
    public class clsReview
    {
        public enum enMode { AddNew, Update }
        private enMode _Mode;

        public int? ID { get; set; }
        public int? ProductID { get; set; }
        public int? UserID { get; set; }
        public string? ReviewText { get; set; }
        public byte? Rating { get; set; }
        public DateTime? ReviewDate { get; set; }

        public ReviewDto ReviewDto
        {
            get
            {
                return new ReviewDto(this.ID, this.ProductID, this.UserID,
                                  this.ReviewText, this.Rating, this.ReviewDate);
            }
        }

        public clsReview()
        {
            this.ID = null;
            this.ProductID = null;
            this.UserID = null;
            this.ReviewText = null;
            this.Rating = null;
            this.ReviewDate = null;

            _Mode = enMode.AddNew;
        }

        public clsReview(ReviewDto reviewDto, enMode mode)
        {
            this.ID = reviewDto.ID;
            this.ProductID = reviewDto.ProductID;
            this.UserID = reviewDto.UserID;
            this.ReviewText = reviewDto.ReviewText;
            this.Rating = reviewDto.Rating;
            this.ReviewDate = reviewDto.ReviewDate;

            _Mode = mode;
        }

        private bool AddNewReview()
        {
            this.ID = clsReviewData.AddNewReview(this.ReviewDto);
            return this.ID is not null;
        }

        private bool UpdateReview() => clsReviewData.UpdateReview(this.ReviewDto);

        public bool Save()
        {
            switch (_Mode)
            {
                case enMode.AddNew:
                    {
                        if (AddNewReview())
                        {
                            _Mode = enMode.Update;
                            return true;
                        }
                        break;
                    }

                case enMode.Update:
                    {
                        return UpdateReview();
                    }
            }
            return false;
        }

        public static bool Delete(int id) => clsReviewData.DeleteReview(id);

        public static clsReview Find(int id)
        {
            ReviewDto reviewDto = clsReviewData.GetReviewByID(id);
            if (reviewDto is not null)
            {
                return new clsReview(reviewDto, enMode.Update);
            }
            return null;
        }

        public static clsReview Find(int productId, int userId)
        {
            ReviewDto reviewDto = clsReviewData.FindReviewByProductIDUserID(productId, userId);
            if (reviewDto is not null)
            {
                return new clsReview(reviewDto, enMode.Update);
            }
            return null;
        }

        public static List<clsReview> FindByProduct(int productId)
        {
            List<ReviewDto> reviewDtos = clsReviewData.GetReviewsByProductID(productId);
            return reviewDtos.Select(dto => new clsReview(dto, enMode.Update)).ToList();
        }

        public static List<clsReview> FindByUser(int userId)
        {
            List<ReviewDto> reviewDtos = clsReviewData.GetReviewsByUserID(userId);
            return reviewDtos.Select(dto => new clsReview(dto, enMode.Update)).ToList();
        }

        public static bool IsExist(int? id) => clsReviewData.IsReviewExistByID(id);

        public static double? GetAverageRatingForProduct(int productId)
        {
            return clsReviewData.GetAverageRatingForProduct(productId);
        }

        public static int GetTotalReviewsForProduct(int productId)
        {
            return clsReviewData.GetTotalReviewsForProduct(productId);
        }
    }
}
