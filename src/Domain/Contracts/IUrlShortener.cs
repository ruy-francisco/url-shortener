using System.Threading.Tasks;

namespace Domain.Contracts
{
    public interface IUrlShortener
    {
        Task<string> Shorten(string url);
        Task<string> GetOriginalUrl(string shortenedUrl);
    }
}