namespace PetStore.Core
{
    public class Pet
    {
        public int Id { get; set; }

        public string Name { get; set; }

        public PetStatus Status { get; set; }

        public string PetType { get; set; }
    }
}
