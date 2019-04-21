using System;
using System.ComponentModel.DataAnnotations;
using Microsoft.Rest.Serialization;
using Newtonsoft.Json;
using Newtonsoft.Json.Converters;

namespace PetStore.Core
{
    public class Pet
    {
        public int Id { get; set; }

        public string Name { get; set; }

        [JsonConverter(typeof(StringEnumConverter))]
        public PetStatus Status { get; set; }

        [DataType(DataType.Date)]
        [JsonConverter(typeof(DateJsonConverter))]
        public DateTime DateOfBirth { get; set; }

        public DateTime RegistrationTimestamp { get; set; }

        public string PetType { get; set; }
    }
}
