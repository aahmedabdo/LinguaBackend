using ligunaApplication.Interface;
using ligunaApplication.Models;
using Microsoft.Extensions.Options;
using MongoDB.Driver;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ligunaApplication.Data
{
    public class RateDBContext : IRate
    {
        private readonly IMongoDatabase _db;
        public RateDBContext(IOptions<Settings> options)
        {
            var client = new MongoClient(options.Value.ConnectionString);
            _db = client.GetDatabase(options.Value.DataBase);
        }
        public IMongoCollection<RateEntity> RateCollection =>
           _db.GetCollection<RateEntity>("RateTable");

        public void Create(RateEntity rateEntity)
        {
            RateCollection.InsertOne(rateEntity);
        }

        public void Delete(string _Id)
        {
            RateCollection.DeleteOne(Rate => Rate._Id == _Id);
        }

        public IEnumerable<RateEntity> GetAllRates()
        {
            return RateCollection.Find(a => true).ToList();
        }

        public RateEntity GetOneRateDetails(string _Id)
        {
            return RateCollection.Find(a => a._Id == _Id).FirstOrDefault();
        }

        public void Update(string _Id, RateEntity rateEntity)
        {
            RateCollection.ReplaceOne(Rate => Rate._Id == _Id, rateEntity);
        }

        public dataview GetCount()
        {
            dataview dv = new dataview();
            dv.ExcellentCount = ToInt32(RateCollection.Find(a => a.RateCount == 5).Count().ToString());
            dv.VerryGoodCount = ToInt32(RateCollection.Find(a => a.RateCount == 4).Count().ToString());
            dv.GoodCount = ToInt32(RateCollection.Find(a => a.RateCount == 3).Count().ToString());
            dv.AcceptedCount = ToInt32(RateCollection.Find(a => a.RateCount == 2).Count().ToString());
            dv.BadCount = ToInt32(RateCollection.Find(a => a.RateCount == 1).Count().ToString());
            return dv;
        }

        public static int ToInt32(string value)
        {
            if (value == null)
            {
                return 0;
            }
            else
            {
                return Int32.Parse(value); ;
            }
        }
    }

    public class dataview
    {
        public int? ExcellentCount { get; set; }
        public int? VerryGoodCount { get; set; }
        public int? GoodCount { get; set; }
        public int? AcceptedCount { get; set; }
        public int? BadCount { get; set; }

    }
}
