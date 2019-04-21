using System;

namespace PetStore.Core
{
    public class Pet
    {
        public int Id { get; set; }

        public string Name { get; set; }

        public PetStatus Status { get; set; }

        public DateTime DateOfBirth { get; set; }

        public DateTime RegistrationTimestamp { get; set; }

        public string PetType { get; set; }
    }
}
