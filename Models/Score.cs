﻿// <auto-generated />
//
// To parse this JSON data, add NuGet 'Newtonsoft.Json' then do:
//
//    using CodeBeautify;
//
//    var welcome9 = Welcome9.FromJson(jsonString);

namespace CodeBeautify
{
    using System;
    using System.Globalization;
    using Newtonsoft.Json;
    using Newtonsoft.Json.Converters;

    public partial class Welcome9
    {
        [JsonProperty("date")]
        public DateTimeOffset Date { get; set; }

        [JsonProperty("scores")]
        public Score[] Scores { get; set; }
    }

    public partial class Score
    {
        [JsonProperty("startTime")]
        public string StartTime { get; set; }

        [JsonProperty("shortName")]
        public string ShortName { get; set; }

        [JsonProperty("status")]
        public Status Status { get; set; }

        [JsonProperty("teams")]
        public Teams Teams { get; set; }
    }

    public partial class Status
    {
        [JsonProperty("inning")]
        public long Inning { get; set; }

        [JsonProperty("state")]
        public State State { get; set; }

        [JsonProperty("detail")]
        public Detail Detail { get; set; }

        [JsonProperty("shortDetail")]
        public ShortDetail ShortDetail { get; set; }

        [JsonProperty("completed")]
        public bool Completed { get; set; }
    }

    public partial class Teams
    {
        [JsonProperty("awayTeam")]
        public Team AwayTeam { get; set; }

        [JsonProperty("homeTeam")]
        public Team HomeTeam { get; set; }
    }

    public partial class Team
    {
        [JsonProperty("alternateColor")]
        public string AlternateColor { get; set; }

        [JsonProperty("venue")]
        public Venue Venue { get; set; }

        [JsonProperty("color")]
        public string Color { get; set; }

        [JsonProperty("displayName")]
        public string DisplayName { get; set; }

        [JsonProperty("abbreviation")]
        public string Abbreviation { get; set; }

        [JsonProperty("isActive")]
        public bool IsActive { get; set; }

        [JsonProperty("shortDisplayName")]
        public string ShortDisplayName { get; set; }

        [JsonProperty("name")]
        public string Name { get; set; }

        [JsonProperty("logo")]
        public Uri Logo { get; set; }

        [JsonProperty("location")]
        public string Location { get; set; }

        [JsonProperty("score")]
        [JsonConverter(typeof(ParseStringConverter))]
        public long Score { get; set; }
    }

    public partial class Venue
    {
        [JsonProperty("id")]
        [JsonConverter(typeof(ParseStringConverter))]
        public long Id { get; set; }
    }

    public enum Detail { Final, FinalOt, MonNovember2NdAt815PmEst };

    public enum ShortDetail { Final, FinalOt, The112815PmEst };

    public enum State { Post, Pre };

    public partial class Welcome9
    {
        public static Welcome9 FromJson(string json) => JsonConvert.DeserializeObject<Welcome9>(json, CodeBeautify.Converter.Settings);
    }

    public static class Serialize
    {
        public static string ToJson(this Welcome9 self) => JsonConvert.SerializeObject(self, CodeBeautify.Converter.Settings);
    }

    internal static class Converter
    {
        public static readonly JsonSerializerSettings Settings = new JsonSerializerSettings
        {
            MetadataPropertyHandling = MetadataPropertyHandling.Ignore,
            DateParseHandling = DateParseHandling.None,
            Converters =
            {
                DetailConverter.Singleton,
                ShortDetailConverter.Singleton,
                StateConverter.Singleton,
                new IsoDateTimeConverter { DateTimeStyles = DateTimeStyles.AssumeUniversal }
            },
        };
    }

    internal class DetailConverter : JsonConverter
    {
        public override bool CanConvert(Type t) => t == typeof(Detail) || t == typeof(Detail?);

        public override object ReadJson(JsonReader reader, Type t, object existingValue, JsonSerializer serializer)
        {
            if (reader.TokenType == JsonToken.Null) return null;
            var value = serializer.Deserialize<string>(reader);
            switch (value)
            {
                case "Final":
                    return Detail.Final;
                case "Final/OT":
                    return Detail.FinalOt;
                case "Mon, November 2nd at 8:15 PM EST":
                    return Detail.MonNovember2NdAt815PmEst;
            }
            throw new Exception("Cannot unmarshal type Detail");
        }

        public override void WriteJson(JsonWriter writer, object untypedValue, JsonSerializer serializer)
        {
            if (untypedValue == null)
            {
                serializer.Serialize(writer, null);
                return;
            }
            var value = (Detail)untypedValue;
            switch (value)
            {
                case Detail.Final:
                    serializer.Serialize(writer, "Final");
                    return;
                case Detail.FinalOt:
                    serializer.Serialize(writer, "Final/OT");
                    return;
                case Detail.MonNovember2NdAt815PmEst:
                    serializer.Serialize(writer, "Mon, November 2nd at 8:15 PM EST");
                    return;
            }
            throw new Exception("Cannot marshal type Detail");
        }

        public static readonly DetailConverter Singleton = new DetailConverter();
    }

    internal class ShortDetailConverter : JsonConverter
    {
        public override bool CanConvert(Type t) => t == typeof(ShortDetail) || t == typeof(ShortDetail?);

        public override object ReadJson(JsonReader reader, Type t, object existingValue, JsonSerializer serializer)
        {
            if (reader.TokenType == JsonToken.Null) return null;
            var value = serializer.Deserialize<string>(reader);
            switch (value)
            {
                case "11/2 - 8:15 PM EST":
                    return ShortDetail.The112815PmEst;
                case "Final":
                    return ShortDetail.Final;
                case "Final/OT":
                    return ShortDetail.FinalOt;
            }
            throw new Exception("Cannot unmarshal type ShortDetail");
        }

        public override void WriteJson(JsonWriter writer, object untypedValue, JsonSerializer serializer)
        {
            if (untypedValue == null)
            {
                serializer.Serialize(writer, null);
                return;
            }
            var value = (ShortDetail)untypedValue;
            switch (value)
            {
                case ShortDetail.The112815PmEst:
                    serializer.Serialize(writer, "11/2 - 8:15 PM EST");
                    return;
                case ShortDetail.Final:
                    serializer.Serialize(writer, "Final");
                    return;
                case ShortDetail.FinalOt:
                    serializer.Serialize(writer, "Final/OT");
                    return;
            }
            throw new Exception("Cannot marshal type ShortDetail");
        }

        public static readonly ShortDetailConverter Singleton = new ShortDetailConverter();
    }

    internal class StateConverter : JsonConverter
    {
        public override bool CanConvert(Type t) => t == typeof(State) || t == typeof(State?);

        public override object ReadJson(JsonReader reader, Type t, object existingValue, JsonSerializer serializer)
        {
            if (reader.TokenType == JsonToken.Null) return null;
            var value = serializer.Deserialize<string>(reader);
            switch (value)
            {
                case "post":
                    return State.Post;
                case "pre":
                    return State.Pre;
            }
            throw new Exception("Cannot unmarshal type State");
        }

        public override void WriteJson(JsonWriter writer, object untypedValue, JsonSerializer serializer)
        {
            if (untypedValue == null)
            {
                serializer.Serialize(writer, null);
                return;
            }
            var value = (State)untypedValue;
            switch (value)
            {
                case State.Post:
                    serializer.Serialize(writer, "post");
                    return;
                case State.Pre:
                    serializer.Serialize(writer, "pre");
                    return;
            }
            throw new Exception("Cannot marshal type State");
        }

        public static readonly StateConverter Singleton = new StateConverter();
    }

    internal class ParseStringConverter : JsonConverter
    {
        public override bool CanConvert(Type t) => t == typeof(long) || t == typeof(long?);

        public override object ReadJson(JsonReader reader, Type t, object existingValue, JsonSerializer serializer)
        {
            if (reader.TokenType == JsonToken.Null) return null;
            var value = serializer.Deserialize<string>(reader);
            long l;
            if (Int64.TryParse(value, out l))
            {
                return l;
            }
            throw new Exception("Cannot unmarshal type long");
        }

        public override void WriteJson(JsonWriter writer, object untypedValue, JsonSerializer serializer)
        {
            if (untypedValue == null)
            {
                serializer.Serialize(writer, null);
                return;
            }
            var value = (long)untypedValue;
            serializer.Serialize(writer, value.ToString());
            return;
        }

        public static readonly ParseStringConverter Singleton = new ParseStringConverter();
    }
}
