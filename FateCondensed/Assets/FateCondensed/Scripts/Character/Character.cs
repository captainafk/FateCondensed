using System.Collections.Generic;

namespace FateCondensed
{
    public class Character
    {
        public string Name { get; set; }
        public List<Aspect> Aspects { get; set; }
        public List<Stunt> Stunts { get; set; }
        public Dictionary<Skill, int> ModifierBySkill { get; set; }
        public int PhysicalStress { get; set; }
        public int MentalStress { get; set; }
        public List<Aspect> Consequences { get; set; }
        public int FatePoints { get; set; }

        public void InvokeAspect(Aspect aspect)
        {
            ModifierBySkill[aspect.RelatedSkill] += Aspect.ModifierBonus;
            FatePoints--;
        }

        public void EndAspect(Aspect aspect)
        {
            ModifierBySkill[aspect.RelatedSkill] -= Aspect.ModifierBonus;
        }
    }
}
