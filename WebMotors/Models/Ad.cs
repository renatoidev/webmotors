namespace WebMotors.Models
{
    public class Ad
    {
        public Ad() { }

        public Ad(string make, string model, string version, int year, int km, string note)
        {
            Make = make;
            Model = model;
            Version = version;
            Year = year;
            Km = km;
            Note = note;
        }

        public int Id { get; set; }
        public string Make { get; set; }
        public string Model { get; set; }
        public string Version { get; set; }
        public int Year { get; set; }
        public int Km { get; set; }
        public string Note { get; set; }
    }
}
