using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BlogApp.Entity;
using Microsoft.EntityFrameworkCore;

namespace BlogApp.Data.Concrete.EfCore
{
    public class SeedData
    {
        public static void TestVerileriniDoldur(IApplicationBuilder app)
        {
            var context = app.ApplicationServices.CreateScope().ServiceProvider.GetService<BlogContext>();

            if(context != null)
            {
                if(context.Database.GetPendingMigrations().Any())
                {
                    context.Database.Migrate();
                }


                if(!context.Tags.Any())
                {
                    context.Tags.AddRange(
                        new Tag { Text = "web-programlama"},
                        new Tag { Text = "back-end"},
                        new Tag { Text = "front-end"},
                        new Tag { Text = "full-stack"},
                        new Tag { Text = "react"}
                    );
                    context.SaveChanges();
                }
                if(!context.Users.Any())
                {
                    context.Users.AddRange(
                        new User {UserName = "bciga"},
                        new User {UserName = "etkin"}
                    );
                    context.SaveChanges();
                }
                if(!context.Posts.Any())
                {
                    context.Posts.AddRange(
                        new Post { 
                            Title = "Asp.Net Core",
                            Content = "Asp.Net Core Dersleri",
                            IsActive = true,
                            PublishedOn = DateTime.Now.AddDays(-10),
                            Tags = context.Tags.Take(3).ToList(),
                            Image = "1.jpg",
                            UserId = 1
                        },
                         new Post { 
                            Title = "React Js",
                            Content = "React Dersleri",
                            IsActive = true,
                            PublishedOn = DateTime.Now.AddDays(-20),
                            Tags = context.Tags.Take(2).ToList(),
                            Image = "2.jpg",
                            UserId = 1
                        },
                         new Post { 
                            Title = "Mongo Db",
                            Content = "Mongo Db Dersleri",
                            IsActive = true,
                            PublishedOn = DateTime.Now.AddDays(-5),
                            Tags = context.Tags.Take(4).ToList(),
                            Image = "3.jpg",
                            UserId = 2
                        }
                        
                    );
                    context.SaveChanges();
                }
                
            }
        }
    }
}