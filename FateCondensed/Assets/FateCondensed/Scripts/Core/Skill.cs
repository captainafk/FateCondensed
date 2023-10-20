using UnityEngine;

namespace FateCondensed
{
    [CreateAssetMenu(fileName = "New Skill", menuName = "FateCondensed/Skill")]
    public class Skill : ScriptableObject
    {
        public string SkillName;
        [TextArea(4, 10)]
        public string Description;
    }
}