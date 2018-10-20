using System.Threading.Tasks;

namespace Domain.Contracts
{
    public interface IUrlRepository {
        Task<int> Save (string url);
        Task<int> GetId (string url);
        Task<string> GetOriginalUrl(int id);
    }   
}