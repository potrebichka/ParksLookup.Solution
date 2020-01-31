using Microsoft.EntityFrameworkCore;

namespace ParksLookup.Models
{
    public class ParksLookupContext : DbContext
    {
        public ParksLookupContext(DbContextOptions<ParksLookupContext> options)
            : base(options)
        {
        }
        // public virtual DbSet<Destination> Destinations { get; set; }
        // public DbSet<Review> Reviews { get; set; }
        // protected override void OnModelCreating(ModelBuilder builder)
        // {
        // builder.Entity<Destination>()
        //     .HasData(
        //         new Destination { DestinationId = 1, Country = "USA", City = "Seattle", Rating = 4.5 },
        //         new Destination { DestinationId = 2, Country = "Canada", City = "Vancouver", Rating = 5 },
        //         new Destination { DestinationId = 3, Country = "Thailand", City = "Bangkok", Rating = 0 },
        //         new Destination { DestinationId = 4, Country = "Russia", City = "Moscow", Rating = 0 },
        //         new Destination { DestinationId = 5, Country = "France", City = "Paris", Rating = 0 },
        //         new Destination { DestinationId = 6, Country = "Japan", City = "Tokio", Rating = 4 },
        //         new Destination { DestinationId = 7, Country = "Australia", City = "Melbourne", Rating = 2.5 },
        //         new Destination { DestinationId = 8, Country = "China", City = "Bejing", Rating = 0 },
        //         new Destination { DestinationId = 9, Country = "Greece", City = "Athens", Rating = 5 },
        //         new Destination { DestinationId = 10, Country = "USA", City = "Los Angeles", Rating = 0 }
        //     );
        // builder.Entity<Review>()
        //     .HasData(
        //         new Review { ReviewId = 1, Description = "Great city with many things to check out for everyone! One can find a great balance between city life and nature without driving too far. No matter where you are, you will always see evergreen trees and mountains. Along with many lakes and top notch sea food.", user_name = "user1", DestinationId = 1,Rating = 4}, 
        //         new Review { ReviewId = 2, Description = "I love this city. Super expensive to live in, but still great. I could not imagine living anywhere else in the world.", user_name = "user1", Rating = 5, DestinationId = 1},
        //         new Review { ReviewId = 3, Description = "Such a beautiful city with easy access to the ocean, gorgeous hiking trails, places to ski, and so much more. Lots of art, culture, and good food. So much to do and explore within the city. Also easy access to locations like the San Juan Islands and Leavenworth. I have lived here all my life and still have so much to explore.", user_name = "user2", Rating = 4.5, DestinationId = 1},
        //         new Review { ReviewId = 4, Description = "Vancouver, Canada is a beautiful city. We were there in August and the weather was great. Two sights that are a 'must see' are Standley Park and the Capilano Suspension Bridge. A drive along the coastline provides great views.", user_name = "user1", Rating = 5, DestinationId = 2},
        //         new Review { ReviewId = 5, Description = "I love Japan. Food = Super-duper #1, People = Friendly, City = Safe/Clean, Sites = Cool, Not that far away, What else? Oh yeah...THE FOOD!", user_name = "user2", Rating = 5, DestinationId = 6},
        //         new Review { ReviewId = 6, Description = "my Husband and I spent 8 days on vacation in Tokyo, March 28 -April 5th 2010. We had a great time, we went all over the city, we found it clean and safe and the people very helpful. I read they appear to take great pride in their jobs and I would agree with that. Theres a lot of bowing and nodding, very polite people we found. The weather was generally very cold, I had to buy some gloves but we did have alot of sunny days and the cherry blossom was in perfect full bloom all over the city.", user_name = "user3", Rating = 3, DestinationId = 6},
        //         new Review { ReviewId = 7, Description = "It is a living breathing, sleepless city; it is no wonder western civilisation began there. It is the only place where the taxi drivers are the best psychologists, or the most maniacal of the insane. The men and women are stunning, it is a place which is constantly moving but at a human pace; it is all based around living life, not moving up a career ladder. The nightlife is amazing as is the day life.", user_name = "user5", Rating = 5, DestinationId = 9},
        //         new Review { ReviewId = 8, Description = "Some review basjdhfkjasfhjk ...", user_name = "user1", Rating = 3, DestinationId = 7},
        //         new Review { ReviewId = 9, Description = "Some another review jkshfjkhasjf", user_name = "user4", Rating = 2, DestinationId = 7},
        //         new Review {ReviewId = 10, Description = "REviEWWWWWWWWWWWWWW", user_name = "user6", Rating = 0, DestinationId = 10}
        //     );
        // }
    }
}