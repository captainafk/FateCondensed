using System.Collections.Generic;

namespace FateCondensed
{
    public class CharacterBuilder
    {
        private readonly Character _character;

        public CharacterBuilder(string name)
        {
            _character = new Character
            {
                Name = name,
                Aspects = new List<Aspect>(),
                Stunts = new List<Stunt>(),
                ModifierBySkill = new Dictionary<Skill, int>(20),
                Consequences = new List<Aspect>()
            };
        }

        public CharacterBuilder AddAspect(Aspect aspect)
        {
            _character.Aspects.Add(aspect);
            return this;
        }

        public CharacterBuilder AddStunt(Stunt stunt)
        {
            _character.Stunts.Add(stunt);
            return this;
        }
        
        public CharacterBuilder InitializeSkills(List<Skill> initialSkills)
        {
            foreach (var skill in initialSkills)
            {
                _character.ModifierBySkill[skill] = 0;  // Initialize with default value
            }
            return this;
        }

        public CharacterBuilder ModifySkill(Skill skill, int modifier)
        {
            if (_character.ModifierBySkill.ContainsKey(skill))
            {
                _character.ModifierBySkill[skill] = modifier;
            }
            return this;
        }
        
        public CharacterBuilder SetPhysicalStress(int points)
        {
            _character.PhysicalStress = points;
            return this;
        }

        public CharacterBuilder SetMentalStress(int points)
        {
            _character.MentalStress = points;
            return this;
        }

        public Character Build()
        {
            // Perform any final validation here if needed
            return _character;
        }
    }
}
