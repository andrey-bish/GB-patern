using Newtonsoft.Json;
using System.IO;

namespace Json
{
    class JsonSerializator
    {
        public SerializableObjectUnit[] Deserialize(string path)
        {
            return JsonConvert.DeserializeObject<SerializableObjectUnit[]>(File.ReadAllText(path));
        }
    }
}
