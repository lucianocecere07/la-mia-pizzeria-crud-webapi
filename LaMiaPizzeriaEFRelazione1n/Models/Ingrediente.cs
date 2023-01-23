using System.Text.Json.Serialization;

namespace LaMiaPizzeriaEFRelazione1n.Models
{
    public class Ingrediente
    {
        public int Id { get; set; }
        public string Name { get; set; }

        [JsonIgnore]
        public List<Pizza>? Pizza { get; set; }

        public Ingrediente() 
        {
        
        }
    }
}
