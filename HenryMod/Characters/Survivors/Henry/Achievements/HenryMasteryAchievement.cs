using HenryMod.Modules.Achievements;
using RoR2;

namespace HenryMod.Survivors.Henry.Achievements {
    [RegisterAchievement(identifier, unlockableIdentifier, null, 10, null)]
    public class HenryMasteryAchievement : BaseMasteryAchievement {
        public const string identifier = HenrySurvivor.HENRY_PREFIX + "masteryAchievement";
        public const string unlockableIdentifier = HenrySurvivor.HENRY_PREFIX + "masteryUnlockable";

        public override string RequiredCharacterBody => HenrySurvivor.instance.bodyName;

        public override float RequiredDifficultyCoefficient => 3;
    }
}