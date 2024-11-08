namespace Employee_Test.countryDto
{
    public class CreateCountryRequest
    {
        public string CountryName { get; set; } 
        public List<CountryTranslationRequest> Translations { get; set; }
    }
}
