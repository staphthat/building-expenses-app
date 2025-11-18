using System.Text.Json.Serialization;

namespace WebTemplate.Models
{
    public class Racun
    {
        [Key]
        public int ID { get; set; }
        public int Mesec { get; set; }
        public double CenaStruje { get; set; }
        public double CenaVode { get; set; }
        public double CenaKomunalija { get; set; }
        public bool Placen { get; set; }
        [JsonIgnore]
        public Stan? Stan { get; set; }

    }
}