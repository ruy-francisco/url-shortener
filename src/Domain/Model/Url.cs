using System;

namespace Domain.Model
{
    public class Url
    {
        public int Id { get; private set; }
        public string Value { get; private set; }

        public Url(int id, string value) {
            Id = id;
            Value = value;
        }

        public string ShortIt() {
            throw new NotImplementedException();
        }
    }
}