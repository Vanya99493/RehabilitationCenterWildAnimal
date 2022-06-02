using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WpfApp.Data;

namespace WpfApp.Classes
{
    class ColdBlooded : Animal
    {
        private string _name;
        private TypeOfFood _typeOfFood;
        private TypeOfHabitat _habitat;
        private TypeOfTherapy _typeOfTherapy;

        public override string Name { get => _name; protected set => _name = value != null ? value != "" ? value : "noname" : "noname"; }
        public override TypeOfFood TypeOfFood { get => _typeOfFood; protected set => _typeOfFood = value; }
        public override TypeOfHabitat Habitat { get => _habitat; protected set => _habitat = value; }
        public override TypeOfTherapy TypeOfTherapy { get => _typeOfTherapy; set => _typeOfTherapy = value; }

        public ColdBlooded(string name, TypeOfFood typeOfFood, TypeOfHabitat habitat, TypeOfTherapy typeOfTherapy)
        {
            Name = name;
            TypeOfFood = typeOfFood;
            Habitat = habitat;
            TypeOfTherapy = typeOfTherapy;
        }

        public override string Heal()
        {
            base.Heal();
            return "The torso, head and if there are limbs have been examined and the damaged parts of the body have been examined and healed, and the animal is placed in an appropriate environment with the required temperature";
        }

        public override object Clone() => new ColdBlooded(Name, TypeOfFood, Habitat, TypeOfTherapy);
    }
}