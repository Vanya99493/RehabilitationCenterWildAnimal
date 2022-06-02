using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;
using WpfApp.Data;

namespace WpfApp.Classes
{
    public class AnimalDTO
    {
        [JsonProperty("kind")]
        public string Kind { get; set; }

        [JsonProperty("name")]
        public string Name { get; set; }

        [JsonProperty("habitat")]
        public TypeOfHabitat Habitat { get; set; }

        [JsonProperty("type-of-food")]
        public TypeOfFood TypeOfFood { get; set; }

        [JsonProperty("type-of-therapy")]
        public TypeOfTherapy TypeOfTherapy { get; set; }
    }
}