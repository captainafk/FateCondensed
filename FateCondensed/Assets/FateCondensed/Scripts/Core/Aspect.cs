namespace FateCondensed
{
    public class Aspect
    {
        public string Name { get; set; }
        public string Description { get; set; }
        public EAspectType Type { get; set; }
        public Skill RelatedSkill { get; set; }
        public const int ModifierBonus = 2;
    }

    public enum EAspectType
    {
        Free = 0,
        HighConcept = 10,
        Trouble = 20,
        Relationship = 30,
        Consequence = 40,
    }
}
