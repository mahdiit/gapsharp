using System;
using Newtonsoft.Json;

namespace GapSharp.DtoModel
{
    public class FileMessageTags
    {
        [JsonProperty("genre", NullValueHandling = NullValueHandling.Ignore)]
        public string Genre { get; set; }

        [JsonProperty("album", NullValueHandling = NullValueHandling.Ignore)]
        public string Album { get; set; }

        [JsonProperty("artist", NullValueHandling = NullValueHandling.Ignore)]
        public string Artist { get; set; }

        [JsonProperty("title", NullValueHandling = NullValueHandling.Ignore)]
        public string Title { get; set; }

        [JsonProperty("cover", NullValueHandling = NullValueHandling.Ignore)]
        public Uri Cover { get; set; }

        [JsonProperty("filename", NullValueHandling = NullValueHandling.Ignore)]
        public string Filename { get; set; }
    }
}