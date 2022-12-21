namespace DogAPIproject
{
    public class Dog
    {


        public string Breed { get; set; }

        public string CountryOfOrigin { get; set; }

        public Dog(string breed, string countryOfOrigin)
        {
            Breed= breed;
            CountryOfOrigin= countryOfOrigin;   
        }


    }
}
