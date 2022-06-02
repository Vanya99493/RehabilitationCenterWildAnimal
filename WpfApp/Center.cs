using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using WpfApp.Classes;

namespace WpfApp
{
    public static class Center
    {
        private static List<Animal> _animals = new List<Animal>();

        public static List<Animal> Animals => _animals;

        public static void AddAnimal(Animal animal)
        {
            _animals.Add(animal);
        }
        public static void RemoveAnimal(int index)
        {
            _animals.RemoveAt(index);
        }
        public static string HealAnimalAndGetInfo(int animalIndex)
        {
            return _animals[animalIndex].Heal();
        }

        public static void DeserializeListOfAnimals()
        {
            Serializator<List<AnimalDTO>> serializator = new Serializator<List<AnimalDTO>>("Animals.json");
            List<AnimalDTO> animalsDTO = serializator.Deserialize();
            AnimalConvertor convertor = new AnimalConvertor();

            _animals.Clear();
            foreach (var item in animalsDTO)
            {
                _animals.Add(convertor.ConvertToObject(item));
            }
        }
        public static void SerializeListOfAnimals()
        {
            List<AnimalDTO> animalsDTO = new List<AnimalDTO>();
            AnimalConvertor convertor = new AnimalConvertor();

            foreach (var item in _animals)
            {
                animalsDTO.Add(convertor.ConvertToDTO(item));
            }

            new Serializator<List<AnimalDTO>>("Animals.json").Serialize(animalsDTO);
        }
    }
}