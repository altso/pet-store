using System;
using System.Threading.Tasks;
using Microsoft.Extensions.DependencyInjection;

namespace PetStore.Console
{
    class Program
    {
        public static async Task Main(string[] args)
        {
            var services = new ServiceCollection();
            services.AddHttpClient<PetClient>().ConfigureHttpClient(client =>
            {
                client.BaseAddress = new Uri("https://localhost:5001");
            });

            ServiceProvider provider = services.BuildServiceProvider();
            var petClient = provider.GetRequiredService<PetClient>();

            var pets = await petClient.GetPetsAsync();
            foreach (PetViewModel pet in pets)
            {
                System.Console.WriteLine(
                    $"{pet.Name.PadRight(40)}{pet.PetType.PadRight(10)}{$"{pet.DateOfBirth:d}".PadRight(12)}{pet.Status}");
            }
        }
    }
}
