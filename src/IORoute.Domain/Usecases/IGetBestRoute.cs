namespace IORoute.Domain.Usecases
{
    public interface IGetBestRoute
    {
        Task<string> GetRoute(string origin, string destination);
    }
}
