namespace FateCondensed
{
    public class Stunt
    {
        public string Name { get; set; }
        public string Description { get; set; }
        public Skill RelatedSkill { get; set; }
        public const int ModifierBonus = 2;
    }
}