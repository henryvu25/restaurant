using Microsoft.EntityFrameworkCore;

namespace restaurant_project.Models
{
    public class RestaurantContext : DbContext
    {
        public RestaurantContext(DbContextOptions<RestaurantContext> options) : base(options){}
        public DbSet<Review> Reviews {get;set;}
    }
}