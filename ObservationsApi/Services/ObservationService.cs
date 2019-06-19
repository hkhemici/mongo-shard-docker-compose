using ObservationsApi.Models;
using MongoDB.Driver;
using System.Collections.Generic;
using System.Linq;

namespace ObservationsApi.Services
{
    public class ObservationService
    {
        private readonly IMongoCollection<Observation> _observations;

        public ObservationService(IObservationsDatabaseSettings settings)
        {
            var client = new MongoClient(settings.ConnectionString);
            var database = client.GetDatabase(settings.DatabaseName);

            _observations = database.GetCollection<Observation>(settings.ObservationsCollectionName);
        }

        public List<Observation> Get() =>
            _observations.Find(observation => true).ToList();

        public Observation Get(string id) =>
            _observations.Find<Observation>(observation => observation.Id == id).FirstOrDefault();

        public Observation Create(Observation observation)
        {
            _observations.InsertOne(observation);
            return observation;
        }

        public void Update(string id, Observation observationIn) =>
            _observations.ReplaceOne(observation => observation.Id == id, observationIn);

        public void Remove(Observation observationIn) =>
            _observations.DeleteOne(observation => observation.Id == observationIn.Id);

        public void Remove(string id) =>
            _observations.DeleteOne(observation => observation.Id == id);
    }
}