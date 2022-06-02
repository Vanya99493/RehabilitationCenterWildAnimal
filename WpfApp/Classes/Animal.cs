using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using WpfApp.Data;

namespace WpfApp.Classes
{
    public abstract class Animal : ICloneable, IComparable<Animal>
    {
        public string Kind { get => GetType().ToString().Split('.')[GetType().ToString().Split('.').Length - 1]; }
        public abstract string Name { get; protected set; }
        public abstract TypeOfFood TypeOfFood { get; protected set; }
        public abstract TypeOfHabitat Habitat { get; protected set; }
        public abstract TypeOfTherapy TypeOfTherapy { get; set; }

        public virtual string Heal()
        {
            TypeOfTherapy = TypeOfTherapy.None;
            return null;
        }

        public abstract object Clone();

        public int CompareTo(Animal obj)
        {
            if (Kind == obj.Kind && Name == obj.Name && Habitat == obj.Habitat && TypeOfFood == obj.TypeOfFood)
                return TypeOfTherapy.CompareTo(obj.TypeOfTherapy);
            else if(Kind == obj.Kind && Name == obj.Name && Habitat == obj.Habitat)
                return TypeOfFood.CompareTo(obj.TypeOfFood);
            else if(Kind == obj.Kind && Name == obj.Name)
                return Habitat.CompareTo(obj.Habitat);
            else if (Kind == obj.Kind)
                return Name.CompareTo(obj.Name);
            else
                return Kind.CompareTo(obj.Kind);
        }
        public string ToShortString() => $"Kind: {Kind} | Name: {Name}";
        public string ToLongString() => $"Kind: {Kind} | Name: {Name} | Therapy: {TypeOfTherapy}";
    }
}