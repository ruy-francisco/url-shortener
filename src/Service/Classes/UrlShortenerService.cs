using System;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Domain.Contracts;

namespace Service.Classes
{
    public class UrlShortenerService : IUrlShortener
    {
        private static readonly string Alphabet = "abcdefghijklmnopqrstuvwxyz0123456789";
        private static readonly int Base = Alphabet.Length;
        private static readonly string Prefix = "http://ru.y/";

        private readonly IUrlRepository _repository;

        public UrlShortenerService(IUrlRepository repository) => _repository = repository;

        public async Task<string> Shorten(string fullUrl) {
            try
            {
                if (string.IsNullOrEmpty(fullUrl))
                    throw new ArgumentException("You must to pass an url as parameter.", "fullUrl");

                var urlId = await _repository.GetId(fullUrl);
                
                if (urlId == 0)
                    urlId = await _repository.Save(fullUrl);

                return GeneratesShortenedUrl(urlId);
            }
            catch (Exception)
            {                
                throw;
            }
        }

        public async Task<string> GetOriginalUrl(string shortenedUrl) {
            try
            {
                if (string.IsNullOrEmpty(shortenedUrl))
                    throw new ArgumentException("You must to pass an url as parameter.", "shortenedUrl");

                var urlId = GetUrlId(shortenedUrl);
                
                return await _repository.GetOriginalUrl(urlId);
            }
            catch (System.Exception)
            {
                
                throw;
            }
        }

        private string GeneratesShortenedUrl(int id) {
            StringBuilder result = new StringBuilder();

            while (id > 0)
            {
                result.Append(Alphabet[id % Base]);
                id = id / Base;
            }

            return Prefix + string.Join(string.Empty, result.ToString().Reverse());
        }

        private int GetUrlId(string shortenedUrl){
            var id = 0;

            foreach (var character in shortenedUrl)
                id = (id * Base) + Alphabet.IndexOf(character);

            return id;
        }
    }
}