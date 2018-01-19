using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Universities3.Data
{
    public class ResultForQuery1
    {
        public int? WorldRank { get; set; }
        public string Institution { get; set; }
        public string Location { get; set; }
        public int? NationalRank { get; set; }
        public int? QualityOfEducation { get; set; }
        public int? AlumniEmployment { get; set; }
        public int? Publications { get; set; }
        public int? Influence { get; set; }
        public int? Citations { get; set; }
        public int? BroadImpact { get; set; }
        public int? Patents { get; set; }
        public double? Score { get; set; }
    }

    public class ResultForQuery2
    {
        public string Country { get; set; }
        public IEnumerable<ResultForQuery1> Results { get; set; }
    }
    public class ResultForQuery3:ResultForQuery1
    {
        public int Year { get; set; }
    }
    public class ResultForQuery4
    {
        public string Institution { get; set; }
        public string Location { get; set; }
        public double? Min { get; set; }
        public double? Max { get; set; }
        public double? Average { get; set; }
    }

    public class Repository
    {
        public List<ResultForQuery1> Query1(int Year)
        {
            using (Context context = new Context())
            {
                var result1 = from univer in context.Universities
                              join rating in context.Ratings
                              on univer equals rating.University
                              where rating.Year == Year
                              orderby rating.Score descending
                              select new ResultForQuery1
                              {
                                  WorldRank = rating.WorldRank,
                                  Institution = univer.Institution,
                                  Location = univer.Location,
                                  NationalRank = rating.NationalRank,
                                  QualityOfEducation = rating.QualityOfEducation,
                                  AlumniEmployment = rating.AlumniEducation,
                                  Publications = rating.Publications,
                                  Influence = rating.Influence,
                                  Citations = rating.Citations,
                                  BroadImpact = rating.BroadImpact,
                                  Patents = rating.Patents,
                                  Score = rating.Score
                              };
                List<ResultForQuery1> resultlist = new List<ResultForQuery1>();
                foreach (var item in result1)
                    resultlist.Add(item);
                return (resultlist);
            }

        }

        //University rankings for a given year grouped by country.In each
        //group entries should be sorted in descending order of the score.

        public List<ResultForQuery2> Query2(int Year)
        {
            using (Context context = new Context())
            {
                var result21 = Query1(Year); // так получим рейтинги только нужного года
                var result22 = from univer in result21
                               orderby univer.Score descending
                               group univer by univer.Location into g
                               select new ResultForQuery2 { Country = g.Key, Results = g };
                List<ResultForQuery2> resultlist = new List<ResultForQuery2>();
                foreach (var item in result22)
                {
                    resultlist.Add(item);
                }
                return (resultlist);

            }
        }

        //Dynamics for a given university(how a particular university evolved
        //in the rating table from 2012 to 2016)

        public List<ResultForQuery3> Query3(string Institution)
        {
            using (Context context = new Context())
            {
                var result3 = from univer in context.Universities
                              join rating in context.Ratings
                              on univer equals rating.University
                              where univer.Institution == Institution
                              select new ResultForQuery3
                              {
                                  Year = rating.Year,
                                  WorldRank = rating.WorldRank,
                                  Institution = univer.Institution,
                                  Location = univer.Location,
                                  NationalRank = rating.NationalRank,
                                  QualityOfEducation = rating.QualityOfEducation,
                                  AlumniEmployment = rating.AlumniEducation,
                                  Publications = rating.Publications,
                                  Influence = rating.Influence,
                                  Citations = rating.Citations,
                                  BroadImpact = rating.BroadImpact,
                                  Patents = rating.Patents,
                                  Score = rating.Score
                              };
                List<ResultForQuery3> resultlist = new List<ResultForQuery3>();
                foreach (var item in result3)
                {
                    resultlist.Add(item);
                }
                return (resultlist);
            }
        }

        //Minimal, maximal and average score of each university over the last
        //five years in descending order of the average score.

        public List<ResultForQuery4> Query4()
        {
            using (Context context = new Context())
            {
                List<ResultForQuery4> resultlist = new List<ResultForQuery4>();
                foreach (var university in context.Universities)
                {
                    string Institution = university.Institution;
                    var result4 = (from univer in context.Universities
                                   join rating in context.Ratings
                                   on univer equals rating.University
                                   where (univer.Institution == Institution)
                                   select new ResultForQuery1
                                   {
                                       WorldRank = rating.WorldRank,
                                       Institution = univer.Institution,
                                       Location = univer.Location,
                                       NationalRank = rating.NationalRank,
                                       QualityOfEducation = rating.QualityOfEducation,
                                       AlumniEmployment = rating.AlumniEducation,
                                       Publications = rating.Publications,
                                       Influence = rating.Influence,
                                       Citations = rating.Citations,
                                       BroadImpact = rating.BroadImpact,
                                       Patents = rating.Patents,
                                       Score = rating.Score
                                   });
                    ResultForQuery4 result = new ResultForQuery4();
                    result.Max = 0;
                    result.Min = 101;
                    result.Average = 0;
                    int count = 0;
                    foreach (var item in result4)
                    {
                        result.Institution = item.Institution;
                        result.Location = item.Location;
                        if (item.Score > result.Max)
                            result.Max = item.Score;
                        if (item.Score < result.Min)
                            result.Min = item.Score;
                        count += 1;
                        result.Average += item.Score;
                    }
                    result.Average = result.Average / count;
                    resultlist.Add(result);
                }
                return (resultlist);
            }
        }
    }
}
