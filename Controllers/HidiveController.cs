using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using MongoDB.Driver;
using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;
using Newtonsoft.Json;
// using MongoDB.Driver.Builders;

namespace hidive_homework.Controllers
{
    [Route("api/[controller]")]
    public class HiDiveController : Controller
    {

        [HttpGet]
        public async Task<string> Get()
        {
            var client = new MongoClient("mongodb://admin:admin@ds227865.mlab.com:27865/hidive");
            var database = client.GetDatabase("hidive");
            var collection = database.GetCollection<BsonDocument>("TitleRows");
            var result = await collection.Find(new BsonDocument()).Project(Builders<BsonDocument>.Projection.Exclude("_id")).ToListAsync();
            var obj = result.ToJson();
            return obj;

        }

[BsonIgnoreExtraElements]
public class TitleRow
{

 [BsonElement("Name")]
 public string Name { get; set; }
 [BsonElement("Titles")]
 public List<Title> Titles { get; set; }
}

public class Title
{
    public string Name { get; set; }
    public string ShortSynopsis { get; set; }
    public string MediumSynopsis { get; set; }
    public string LongSynopsis { get; set; }
    public string KeyArtUrl { get; set; }
    public string MasterArtUrl { get; set; }
    public string Rating { get; set; }
    public double StarRating { get; set; }
    public int? RunTime { get; set; }
    public List<object> Episodes { get; set; }
    public DateTime FirstPremiereDate { get; set; }
    public string ShowInfoTitle { get; set; }
    public int EpisodeCount { get; set; }
    public string SeasonName { get; set; }
}
  }
}