using HenryMod.Modules.Characters;
using RoR2;

namespace HenryMod.Survivors.Henry {
    public class HenrySurvivor : SurvivorBase<HenrySurvivor> {
        public override string assetBundleName => "mwmwhenryassetbundle";

        public override string bodyName => "HenryBody";

        public override string masterName => "HenryMonsterMaster";

        public override string displayPrefabName => "HenryDisplay";

        public const string HENRY_PREFIX = HenryPlugin.DEVELOPER_PREFIX + "_HENRY_";

        public override string survivorTokenPrefix => HENRY_PREFIX;

        public override UnlockableDef characterUnlockableDef => HenryUnlockables.characterUnlockableDef;

        public override ItemDisplaysBase itemDisplays => new HenryItemDisplays();

        public override string survivorDefName => "Henry";

        public override void Init() {
            base.Init();
        }

        public override void InitCharacter() {
            HenryUnlockables.Init();

            base.InitCharacter();

            HenryStates.Init();
            HenryTokens.Init();

            HenryAssets.Init(assetBundle);
            HenryBuffs.Init(assetBundle);

            AdditionalBodySetup();
        }

        private void AdditionalBodySetup() {
        }
    }
}