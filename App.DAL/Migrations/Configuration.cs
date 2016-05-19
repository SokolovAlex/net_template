using System;
using App.DAL.Entities.Base;
using App.DAL.Entities.Blog;
using App.DAL.Entities.News;
using App.DTO.Enums;

namespace App.DAL.Migrations
{
    using System.Data.Entity.Migrations;

    internal sealed class Configuration : DbMigrationsConfiguration<DataContext>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = false;
        }

        protected override void Seed(DataContext context)
        {
            const int userId = 1;

            SeedBaseModule(context, userId);
            SeedNewsModule(context, userId);
            SeedBlogModule(context, userId);
        }

        #region Base

        private static void SeedBaseModule(DataContext context, int userId)
        {
            SeedBaseUser(context, userId);
            SeedBaseReference(context, userId);
        }

        private static void SeedBaseUser(DataContext context, int userId)
        {
            context.User.AddOrUpdate(p => p.Id,
                new UserEntity
                {
                    Id = userId,
                    Name = "Admin",
                    Surname = "Bigboss",
                    Email = "admin@magora-systems.ru",
                    IsActive = true
                }
            );

            context.User.AddOrUpdate(p => p.Id,
                new UserEntity
                {
                    Id = 111,
                    Name = "Gogol",
                    Surname = "Bardello",
                    Email = "Bardello@magora-systems.ru",
                    IsActive = true
                }
            );

            context.User.AddOrUpdate(p => p.Id,
                new UserEntity
                {
                    Id = 222,
                    Name = "Kuchma",
                    Surname = "Kuchma",
                    Email = "Kuchma@magora-systems.ru",
                    IsActive = true
                }
            );

            context.User.AddOrUpdate(p => p.Id,
                new UserEntity
                {
                    Id = 333,
                    Name = "Pushkin",
                    Surname = "Pushkin",
                    Email = "Pushkin@magora-systems.ru",
                    IsActive = true
                }
            );


            context.User.AddOrUpdate(p => p.Id,
                new UserEntity
                {
                    Id = 444,
                    Name = "Sartr",
                    Surname = "Sartr",
                    Email = "Sartr@magora-systems.ru",
                    IsActive = true
                }
            );

            context.User.AddOrUpdate(p => p.Id,
                new UserEntity
                {
                    Id = 555,
                    Name = "Gesse",
                    Surname = "Gesse",
                    Email = "Gesse@magora-systems.ru",
                    IsActive = true
                }
            );

            context.User.AddOrUpdate(p => p.Id,
                new UserEntity
                {
                    Id = 666,
                    Name = "Miller",
                    Surname = "Miller",
                    Email = "Miller@magora-systems.ru",
                    IsActive = true
                }
            );

            context.User.AddOrUpdate(p => p.Id,
                new UserEntity
                {
                    Id = 777,
                    Name = "Bart",
                    Surname = "Bart",
                    Email = "Bart@magora-systems.ru",
                    IsActive = true
                }
            );

            context.SaveChanges();
        }

        private static void SeedBaseReference(DataContext context, int userId)
        {
            context.Category.AddOrUpdate(p => p.Id,
                new CategoryEntity
                {
                    Id = (int)BaseEnums.Reference.Category.Settings,
                    Name = "Settings",
                    IsActive = true
                },
                new CategoryEntity
                {
                    Id = (int)BaseEnums.Reference.Category.Gender,
                    Name = "Gender",
                    IsActive = true
                }
            );
            context.SaveChanges();

            context.Reference.AddOrUpdate(p => p.Id,
                new ReferenceEntity
                {
                    Id = (int)BaseEnums.Reference.Gender.Male,
                    CategoryId = (int)BaseEnums.Reference.Category.Gender,
                    Key = "Male",
                    Value = "Male",
                    IsActive = true
                },
                new ReferenceEntity
                {
                    Id = (int)BaseEnums.Reference.Gender.Female,
                    CategoryId = (int)BaseEnums.Reference.Category.Gender,
                    Key = "Female",
                    Value = "Female",
                    IsActive = true
                },
                new ReferenceEntity
                {
                    Id = (int)BaseEnums.Reference.Settings.AppHost,
                    CategoryId = (int)BaseEnums.Reference.Category.Settings,
                    Key = "AppHost",
                    Value = "magora.loc",
                    IsActive = true
                },
                new ReferenceEntity
                {
                    Id = (int)BaseEnums.Reference.Settings.ResizerHost,
                    CategoryId = (int)BaseEnums.Reference.Category.Settings,
                    Key = "ResizerHost",
                    Value = "build.magora-systems.loc:8083",
                    IsActive = true
                }
            );
            context.SaveChanges();
        }

        #endregion

        #region News

        private static void SeedNewsModule(DataContext context, int userId)
        {
            SeedNews(context, userId);
        }

        private static void SeedNews(DataContext context, int userId)
        {
            context.News.AddOrUpdate(p => p.Id,
                new NewsEntity
                {
                    Id = 1,
                    IsActive = true,
                    Name = "What will power tomorrow’s spacecraft?",
                    Text = "<p>Power systems are a critical part of a spacecraft. They need to be able to operate in extreme environments and be utterly reliable. Yet, with the ever-increasing power demands of more complex spacecraft, what does the future hold for their power technologies?</p><p>The latest mobile phones can barely last a day without the need to be plugged into a power socket. Yet the Voyager space probe, which was launched 38 years ago, is still sending us information from beyond the edges of our solar system. The Voyager probes are capable of efficiently processing 81,000 instructions every second, but the average smartphone is more than 7,000 times faster.</p>",
                    Date = new DateTime(2016, 01, 01),
                    IsPublished = true,
                    Views = 25
                },
                new NewsEntity
                {
                    Id = 2,
                    IsActive = true,
                    Name = "Asian stock markets suffer further losses",
                    Text = "<p>Investors remain worried over slumping oil prices and slowing growth in China.</p><p>Asian markets failed to hold onto the slight gains they made in early trading, and Japan's Nikkei index closed more than 2% lower.</p><p>Thursday's retreat added to the losses financial markets have seen since the start of the year.</p>",
                    Date = new DateTime(2016, 01, 20),
                    IsPublished = true,
                    Views = 70
                }
            );

            context.SaveChanges();
        }

        #endregion

        #region Blog

        private static void SeedBlogModule(DataContext context, int userId)
        {
            SeedBlogReference(context, userId);
            SeedBlogPost(context, userId);
            SeedBlogPartialBaseUser(context, userId);
        }

        private static void SeedBlogReference(DataContext context, int userId)
        {
            // Category 
            context.Category.AddOrUpdate(p => p.Id,
                new CategoryEntity
                {
                    Id = (int)BlogEnums.Reference.Category.Settings,
                    Name = "Settings",
                    IsActive = true
                },
                new CategoryEntity
                {
                    Id = (int)BlogEnums.Reference.Category.BlogPostStatus,
                    Name = "BlogPostStatus",
                    IsActive = true
                }
            );
            context.SaveChanges();

            // Reference
            context.Reference.AddOrUpdate(p => p.Id,
                new ReferenceEntity
                {
                    Id = (int)BlogEnums.Reference.Settings.IsCommentsAllowed,
                    CategoryId = (int)BlogEnums.Reference.Category.Settings,
                    Key = "IsCommentsAllowed",
                    Value = "True",
                    IsActive = true
                },
                new ReferenceEntity
                {
                    Id = (int)BlogEnums.Reference.BlogPostStatus.Draft,
                    CategoryId = (int)BlogEnums.Reference.Category.BlogPostStatus,
                    Key = "Draft",
                    Value = "Draft",
                    IsActive = true
                },
                new ReferenceEntity
                {
                    Id = (int)BlogEnums.Reference.BlogPostStatus.Published,
                    CategoryId = (int)BlogEnums.Reference.Category.BlogPostStatus,
                    Key = "Published",
                    Value = "Published",
                    IsActive = true
                }
            );
            context.SaveChanges();
        }

        private static void SeedBlogPost(DataContext context, int userId)
        {
            context.Blog.AddOrUpdate(x => x.Id,
                new BlogEntity
                {
                    Id = 1,
                    UserId = userId,
                    StatusId = (int)BlogEnums.Reference.BlogPostStatus.Published,
                    IsActive = true,
                    Title = "Where is Business Collaboration Headed in 2016?",
                    Text = "<p>The future of business collaboration is moving fast, and if you don’t keep up, you risk your company being left behind! The technologies are ever-changing, as new cutting-edge developments constantly come into the market, and times, trends and concepts evolve. The Internet and the Workplace of Things are becoming more prevalent, and will be increasingly important to collaboration. In this article, we will take a look at these, as well as other important trends such as Big Data technology, asynchronous work, anywhere-ization and convergence, all set to shape and impact the future of business collaboration. First let’s look at why business collaboration is so important.</p><p>As most businesses know, a successful future is the result of effective collaboration with your on-site employees and your customers. However, success increasingly also lies in collaboration within your company’s own virtual walls, in collaborating with employees, more and more of whom are working remotely. Collusion and communication is essential to getting an entire company on the same page to work toward a common goal. Your business must stay ahead of the game in terms of technology in order to make collaboration effective and efficient. In a market where many companies are taking advantage of the technology advances to improve collaboration, it is essential to adopt and integrate them to stay competitive.</p>",
                    Date = new DateTime(2016, 01, 10),
                    IsPublished = true
                },
                new BlogEntity
                {
                    Id = 2,
                    UserId = userId,
                    StatusId = (int)BlogEnums.Reference.BlogPostStatus.Draft,
                    IsActive = true,
                    Title = "On-Demand Apps and the Logistics & Transportation Industry",
                    Text = "<p>Technology and Logistics & Transportation are a match made in heaven. This industry is so linked with the cross examination of such diverse sets of data that computers and their counterparts have become the keystone of so much of the work that is done. However, are new technologies, new innovations and new trends being used to their full potential?</p><p>There are few sadder sights Every year, there is an estimated loss of $16 billion dollars simply as a result of empty containers. That’s not a typo, but ‘billion’, with a ‘b’. Truckers and shipping companies spend these massive sums each year for the simple reason that they cannot fill those containers quickly enough, resulting in those losses increasing other prices all around and limiting competitiveness. So how do we solve it?</p>",
                    Date = new DateTime(2016, 01, 25),
                    IsPublished = true
                }
            );

            context.SaveChanges();
        }

        private static void SeedBlogPartialBaseUser(DataContext context, int userId)
        {
            foreach (var baseUser in context.User)
                baseUser.Nickname = $"Mr. {baseUser.Name}";
            
            context.SaveChanges();
        }

        #endregion

        }
}
