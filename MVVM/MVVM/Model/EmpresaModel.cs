using System;
using System.Collections.Generic;
using System.Text;

using System.Globalization;
using Newtonsoft.Json;
using Newtonsoft.Json.Converters;

namespace MVVM.Model
{
    public partial class EmpresaModel
    {
        [JsonProperty("id")]
        public string Id { get; set; }

        [JsonProperty("nombre")]
        public string Nombre { get; set; }

        [JsonProperty("direccion")]
        public string Direccion { get; set; }

        [JsonProperty("telefono")]
        public long Telefono { get; set; }

        [JsonProperty("nempleados")]
        public long Nempleados { get; set; }
    }

    public partial class EmpresaModel
    {
        public static EmpresaModel[] FromJson(string json) => JsonConvert.DeserializeObject<EmpresaModel[]>(json, MVVM.Model.Converter.Settings);
    }

    public static class Serialize
    {
        public static string ToJson(this EmpresaModel[] self) => JsonConvert.SerializeObject(self, MVVM.Model.Converter.Settings);
    }

    internal static class Converter
    {
        public static readonly JsonSerializerSettings Settings = new JsonSerializerSettings
        {
            MetadataPropertyHandling = MetadataPropertyHandling.Ignore,
            DateParseHandling = DateParseHandling.None,
            Converters =
            {
                new IsoDateTimeConverter { DateTimeStyles = DateTimeStyles.AssumeUniversal }
            },
        };
    }
}
