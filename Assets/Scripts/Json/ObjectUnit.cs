using Newtonsoft.Json;


namespace Json
{
    public struct SerializableObjectUnit
    {
        [JsonProperty(PropertyName = "unit")]
        public SerializableObjectInfo Unit { get; set; }
    }
}