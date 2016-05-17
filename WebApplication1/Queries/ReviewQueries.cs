using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using WebApplication1.Models;

namespace WebApplication1.Queries
{
    public static class WebAppQueries
    {
        public static IEnumerable<ReviewModel> FindTheLatest(this IQueryable<ReviewModel> reviews, int numberOfReviews)
        {
            return reviews.OrderByDescending(r => r.ID)
                          .Take(numberOfReviews);
        }

        public static ReviewModel FindById(this IQueryable<ReviewModel> reviews, int id)
        {
            return reviews.Single(r => r.ID == id);
        }

        public static ReviewModel FindTheBest(this IQueryable<ReviewModel> reviews)
        {
            return reviews.OrderByDescending(r => r.Rating).First();
        }
    }
}