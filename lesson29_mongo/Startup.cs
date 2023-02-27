using lesson29_mongo.DAL.DataBaseMarkers;
using MongoDB.Bson;
using MongoDB.Driver;

namespace lesson29_mongo
{
    public static class Startup
    {
        public static void AddMongoClient(IServiceCollection services, IConfiguration configuration)
        {
            var connectionString = configuration.GetConnectionString("DefaultMongo");
            if (connectionString == null)
            {
                Console.WriteLine("You must set ConnectionString:DefaultMongo");
                Environment.Exit(0);
            }

            services.AddScoped<ICatsMongoDatabase>((IServiceProvider services) =>
            {
                var client = new MongoClient(connectionString);
                return (ICatsMongoDatabase) client.GetDatabase("Cats");
            });

            var client = new MongoClient(connectionString);
            var collection = client.GetDatabase("Cats").GetCollection<BsonDocument>("Neighbourhood");
            var filter = Builders<BsonDocument>.Filter.Eq("CatColor", "Black");
            var document = collection.Find(filter).First();
            var catname = document.GetValue("CatName").AsString;
        }
    }
}
