namespace ObiletJourney.Business.Interfaces
{
    public interface IObiletAPIService
    {
        Task<string> PostAsync<T>(string Uri, T data);
    }
}
