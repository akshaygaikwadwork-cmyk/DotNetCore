namespace Services
{
    public class CitiesService
    {
        private List<string>  _cities;

        public CitiesService()
        {
            _cities = new List<string>()
            {
                "India",
                "Japan",
                "China",
                "America",
                "South Africa"
            };
        }

        public List<string> GetCities()
        {
            return _cities;
        }

    }
}
