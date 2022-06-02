using System.IO;
using Newtonsoft.Json;

namespace WpfApp
{
    class Serializator<T>
    {
        private readonly string _pathToFile;

        public Serializator(string path)
        {
            _pathToFile = path;
        }

        public void Serialize(T obj) => File.WriteAllText(_pathToFile, JsonConvert.SerializeObject(obj));
        public T Deserialize() => JsonConvert.DeserializeObject<T>(File.ReadAllText(_pathToFile));
    }
}
