namespace PetFinder.Core.Models.Dog
{
    public class DogViewModel
    {
        public int Id { get; set; }

        public string Name { get; set; } = string.Empty;

        public string ChipNumber { get; set; } = string.Empty;

        public int Age { get; set; }

        public string BreedName { get; set; } = string.Empty;

        public string Status { get; set; } = string.Empty;
    }
}
