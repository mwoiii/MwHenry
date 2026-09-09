using RoR2;
using UnityEngine;

namespace HenryMod.Survivors.Henry {
    public static class HenryBuffs {

        public static BuffDef armorBuff;

        public static void Init(AssetBundle assetBundle) {
            armorBuff = Modules.Content.CreateAndAddBuff("HenryArmorBuff",
                LegacyResourcesAPI.Load<BuffDef>("BuffDefs/HiddenInvincibility").iconSprite,
                Color.white,
                false,
                false);
        }
    }
}
