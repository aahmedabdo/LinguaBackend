using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ligunaApplication.Data;
using ligunaApplication.Models;
using MongoDB.Driver;
namespace ligunaApplication.Interface
{
   public interface IRate
    {
        IMongoCollection<RateEntity> RateCollection { get; }
        IEnumerable<RateEntity> GetAllRates();
        RateEntity GetOneRateDetails(String Name);
        void Create(RateEntity rateEntity);
        void Update(string _Id,RateEntity rateEntity);
        void Delete(string _Id);
        dataview GetCount();
    }
}
