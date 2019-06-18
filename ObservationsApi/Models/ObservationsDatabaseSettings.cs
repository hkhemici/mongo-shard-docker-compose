namespace ObservationsApi.Models
{
    public class ObservationsDatabaseSettings : IObservationsDatabaseSettings
    {
        public string ObservationsCollectionName { get; set; }
        public string ConnectionString { get; set; }
        public string DatabaseName { get; set; }
    }

    public interface IObservationsDatabaseSettings
    {
        string ObservationsCollectionName { get; set; }
        string ConnectionString { get; set; }
        string DatabaseName { get; set; }
    }
}