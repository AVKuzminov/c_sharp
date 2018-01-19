namespace Universities3.Data.Migrations
{
    using System;
    using System.Collections.Generic;
    using System.Data.Entity;
    using System.Data.Entity.Migrations;
    using System.IO;
    using System.Linq;

    internal sealed class Configuration : DbMigrationsConfiguration<Universities3.Data.Context>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = false;
        }

        protected override void Seed(Universities3.Data.Context context)
        {
            context.Configuration.AutoDetectChangesEnabled = false;
            List<Rating> ratings = new List<Rating>();
            List<University> universities = new List<University>();
            for (int i = 2012; i < 2017; i++)
            {
                string resourse = string.Format("{0}.csv", i);
                string[] cells = File.ReadAllLines(resourse);

                foreach (var item in cells)
                {
                    string[] row = item.Split(';');
                    University univ = new University { Institution = row[1], Location = row[2] };
                    if(!universities.Exists(uni => uni.Institution == univ.Institution))
                        universities.Add(univ);
                    var result = from university in context.Universities
                                 where university.Institution == univ.Institution
                                 select university.Id;
                    
                    Rating rat = new Rating();
                    rat.WorldRank = int.Parse(row[0].Trim());
                    rat.NationalRank = int.Parse(row[3].Trim());
                    rat.QualityOfEducation = int.Parse(row[4].Trim());
                    rat.AlumniEducation = int.Parse(row[5].Trim());
                    rat.QualityOfFacility = int.Parse(row[6].Trim());
                    rat.Publications = int.Parse(row[7].Trim());
                    rat.Influence = int.Parse(row[8].Trim());
                    rat.Citations = int.Parse(row[9].Trim());
                    if (i >= 2014)
                    {
                        rat.BroadImpact = int.Parse(row[10].Trim());
                        rat.Patents = int.Parse(row[11].Trim());
                        rat.Score = double.Parse(row[12], System.Globalization.CultureInfo.InvariantCulture);
                    }
                    else
                    {
                        rat.BroadImpact = 0;
                        rat.Patents = int.Parse(row[10].Trim());
                        rat.Score = double.Parse(row[11], System.Globalization.CultureInfo.InvariantCulture);
                    }
                    rat.Year = i;
                    rat.University = universities.Find(uni => uni.Institution == univ.Institution);
                    ratings.Add(rat);
                }
            }
          
            foreach (var item in universities)
            {
                context.Universities.AddOrUpdate(c => c.Institution, item);
                context.SaveChanges();
            }
            
            foreach (var item in ratings)
            {
                context.Ratings.AddOrUpdate(r => new { r.WorldRank, r.Year }, item);
                context.SaveChanges();
            }            

        }
         
        }
    }
