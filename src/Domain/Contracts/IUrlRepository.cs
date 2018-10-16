namespace Domain.Contracts
{
    public interface IUrlRepository {
        int Save (string url);
        int GetId (string url);
    }   
}