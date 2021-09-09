using System;
using Newtonsoft.Json;

namespace Json
{
    [Serializable]
    public struct SerializableObjectInfo
    {
        [JsonProperty(PropertyName = "type")]
        public string Type { get; set; }

        [JsonProperty(PropertyName = "health")]
        public float Health { get; set; }
    }
}