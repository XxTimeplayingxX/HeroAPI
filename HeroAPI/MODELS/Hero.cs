using HeroAPI.MODELS;

namespace HeroAPI.MODELS
{
    public class Hero
    {
        public int ID { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public string HeroType { get; set; }
        public string DamageType { get; set; }
        //Como puedo agregar enum aquí?
    }
}
