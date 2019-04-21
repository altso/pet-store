using System;
using System.Collections.Generic;
using System.Linq;
using PetStore.Core;

namespace PetStore.DataAccess
{
    public class PetGenerator
    {
        private static readonly PetStatus[] Statuses = (PetStatus[])Enum.GetValues(typeof(PetStatus));

        private static readonly string[] Types = { "Cat", "Dog" };

        private static readonly string[] Names =
        {
            // ReSharper disable StringLiteralTypo
            "Charlie",
            "Cooper",
            "Max",
            "Oliver",
            "Buddy",
            "Rocky",
            "Teddy",
            "Milo",
            "Tucker",
            "Bentley",
            "Bella",
            "Lucy",
            "Luna",
            "Daisy",
            "Lola",
            "Sadie",
            "Molly",
            "Stella",
            "Chloe",
            "Maggie",
            "Oliver",
            "Max",
            "Milo",
            "Simba",
            "Leo",
            "Charlie",
            "Jack",
            "Loki",
            "Smokey",
            "Jasper",
            "Luna",
            "Bella",
            "Lucy",
            "Chloe",
            "Lily",
            "Mia",
            "Sophie",
            "Lola",
            "Nala",
            "Daisy",
            "Neil Catrick Harris",
            "Sir Leonardo ScraggleBottoms III",
            "Sir Snuggles of Fluffington",
            "Judas Stardust",
            "Peppurrcorn VonPuskins",
            "Professor McGonagall",
            "Sugar Britches",
            "Emoji",
            "Sassafrass",
            "Mooncake",
            // ReSharper restore StringLiteralTypo
        };

        public static IEnumerable<Pet> GeneratePets()
        {
            var random = new Random(0);
            return Names
                .OrderBy(_ => random.Next())
                .Select((name, i) => new Pet
                {
                    Id = i + 1,
                    Name = name,
                    PetType = Types[random.Next(Types.Length)],
                    DateOfBirth = new DateTime(2015, 1, 1).AddDays(random.Next(1000)),
                    RegistrationTimestamp = DateTime.Now,
                    Status = Statuses[random.Next(Statuses.Length)]
                });
        }
    }
}