using System;
using System.ComponentModel.DataAnnotations;
using Microsoft.Rest.Serialization;
using Newtonsoft.Json;
using PetStore.Core;

namespace PetStore.CodeFirst.Models
{
    public class PetViewModel
    {
        public int Id { get; set; }

        [Required]
        public string Name { get; set; }

        public PetStatus Status { get; set; }

        [DataType(DataType.Date)]
        [JsonConverter(typeof(DateJsonConverter))]
        public DateTime DateOfBirth { get; set; }

        public DateTime RegistrationTimestamp { get; set; }

        public string PetType { get; set; }
    }
}
