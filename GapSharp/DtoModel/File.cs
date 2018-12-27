using System;
using System.Collections.Generic;
using Newtonsoft.Json;

namespace GapSharp.DtoModel
{
    public class FileMessage
    {
        [JsonProperty("height", NullValueHandling = NullValueHandling.Ignore)]
        public long? Height { get; set; }

        [JsonProperty("screenshots", NullValueHandling = NullValueHandling.Ignore)]
        public Dictionary<string, Uri> Screenshots { get; set; }

        [JsonProperty("filesize", NullValueHandling = NullValueHandling.Ignore)]
        public long? Filesize { get; set; }

        [JsonProperty("width", NullValueHandling = NullValueHandling.Ignore)]
        public long? Width { get; set; }

        [JsonProperty("filename", NullValueHandling = NullValueHandling.Ignore)]
        public string Filename { get; set; }

        [JsonProperty("type", NullValueHandling = NullValueHandling.Ignore)]
        public string Type { get; set; }

        [JsonProperty("path", NullValueHandling = NullValueHandling.Ignore)]
        public Uri Path { get; set; }

        [JsonProperty("tags", NullValueHandling = NullValueHandling.Ignore)]
        public FileMessageTags Tags { get; set; }

        [JsonProperty("duration", NullValueHandling = NullValueHandling.Ignore)]
        public double? Duration { get; set; }

        [JsonProperty("desc", NullValueHandling = NullValueHandling.Ignore)]
        public string Desc { get; set; }

        [JsonProperty("wavebytes", NullValueHandling = NullValueHandling.Ignore)]
        public string WaveBytes { get; set; }
    }
}