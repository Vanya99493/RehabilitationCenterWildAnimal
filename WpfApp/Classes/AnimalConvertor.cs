using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WpfApp.Classes
{
    public class AnimalConvertor
    {
        public Animal ConvertToObject(AnimalDTO obj)
        {
            switch (obj.Kind)
            {
                case "Coldblooded":
                    return new ColdBlooded(obj.Name, obj.TypeOfFood, obj.Habitat, obj.TypeOfTherapy);
                case "Insect":
                    return new Insect(obj.Name, obj.TypeOfFood, obj.Habitat, obj.TypeOfTherapy);
                default:
                    return new Mammal(obj.Name, obj.TypeOfFood, obj.Habitat, obj.TypeOfTherapy);
            }
        }

        public AnimalDTO ConvertToDTO(Animal obj) => new AnimalDTO() {
                Name = obj.Name,
                Kind = obj.Kind,
                Habitat = obj.Habitat,
                TypeOfFood = obj.TypeOfFood,
                TypeOfTherapy = obj.TypeOfTherapy
            };
    }
}
