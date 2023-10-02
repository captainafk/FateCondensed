using UnityEngine;

namespace FateCondensed
{
    [CreateAssetMenu(fileName = "New Skill", menuName = "FateCondensed/Skill")]
    public class Skill : ScriptableObject
    {
        public string SkillName;
        public string Description;
    }
}