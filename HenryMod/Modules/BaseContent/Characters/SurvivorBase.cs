using RoR2;
using RoR2.Skills;
using RoR2BepInExPack.GameAssetPaths.Version_1_39_0;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AddressableAssets;

namespace HenryMod.Modules.Characters {
    public abstract class SurvivorBase<T> : CharacterBase<T> where T : SurvivorBase<T>, new() {
        public abstract string masterName { get; }

        public abstract string displayPrefabName { get; }

        public abstract string survivorDefName { get; }

        public abstract string survivorTokenPrefix { get; }

        public abstract UnlockableDef characterUnlockableDef { get; }

        public abstract GameObject displayPrefab { get; protected set; }

        public virtual GameObject crosshairPrefab => Addressables.LoadAssetAsync<GameObject>(RoR2_Base_UI.SimpleDotCrosshair_prefab).WaitForCompletion();

        public virtual GameObject podPrefab => Addressables.LoadAssetAsync<GameObject>(RoR2_Base_SurvivorPod.SurvivorPod_prefab).WaitForCompletion();

        public virtual GameObject footstepDustPrefab => Addressables.LoadAssetAsync<GameObject>(RoR2_Base_Common_VFX.GenericFootstepDust_prefab).WaitForCompletion();

        public virtual CharacterCameraParams cameraParams => Addressables.LoadAssetAsync<CharacterCameraParams>(RoR2_Base_Common.ccpStandard_asset).WaitForCompletion();

        public override void InitCharacter() {
            base.InitCharacter();

            Prefabs.SetupRagdoll(characterModelObject);

            if (prefabCharacterBody) {
                if (characterModelObject && characterModelObject.TryGetComponent(out FootstepHandler footstepHandler)) {
                    footstepHandler.footstepDustPrefab = footstepDustPrefab;
                } else {
                    Log.Error("No valid FootstepHandler component found!");
                }
                prefabCharacterBody.GetComponent<CameraTargetParams>().cameraParams = cameraParams;
                prefabCharacterBody._defaultCrosshairPrefab = crosshairPrefab;
                prefabCharacterBody.preferredPodPrefab = podPrefab;
            } else {
                Log.Error("No valid CharacterBody component found!");
            }

            InitDisplayPrefab();

            InitSurvivor();
        }

        protected virtual void InitDisplayPrefab() {
            displayPrefab = Prefabs.LoadDisplayPrefab(assetBundle, displayPrefabName);
        }

        protected virtual void InitSurvivor() {
            SurvivorDef survivorDef = assetBundle.LoadAsset<SurvivorDef>(survivorDefName);
            if (survivorDef != null) {
                Content.AddSurvivorDef(survivorDef);
            } else {
                Log.Error("SurvivorDef not found!");
            }
        }

        #region CharacterSelectSurvivorPreviewDisplayController
        protected virtual void AddCssPreviewSkill(int indexFromEditor, SkillFamily skillFamily, SkillDef skillDef) {
            CharacterSelectSurvivorPreviewDisplayController CSSPreviewDisplayConroller = displayPrefab.GetComponent<CharacterSelectSurvivorPreviewDisplayController>();
            if (!CSSPreviewDisplayConroller) {
                Log.Error("trying to add skillChangeResponse to null CharacterSelectSurvivorPreviewDisplayController.\nMake sure you created one on your Display prefab in editor");
                return;
            }

            CSSPreviewDisplayConroller.skillChangeResponses[indexFromEditor].triggerSkillFamily = skillFamily;
            CSSPreviewDisplayConroller.skillChangeResponses[indexFromEditor].triggerSkill = skillDef;
        }

        protected virtual void AddCssPreviewSkin(int indexFromEditor, SkinDef skinDef) {
            CharacterSelectSurvivorPreviewDisplayController CSSPreviewDisplayConroller = displayPrefab.GetComponent<CharacterSelectSurvivorPreviewDisplayController>();
            if (!CSSPreviewDisplayConroller) {
                Log.Error("trying to add skinChangeResponse to null CharacterSelectSurvivorPreviewDisplayController.\nMake sure you created one on your Display prefab in editor");
                return;
            }

            CSSPreviewDisplayConroller.skinChangeResponses[indexFromEditor].triggerSkin = skinDef;
        }

        protected virtual void FinalizeCSSPreviewDisplayController() {
            if (!displayPrefab)
                return;

            CharacterSelectSurvivorPreviewDisplayController CSSPreviewDisplayConroller = displayPrefab.GetComponent<CharacterSelectSurvivorPreviewDisplayController>();
            if (!CSSPreviewDisplayConroller)
                return;

            //set body prefab
            CSSPreviewDisplayConroller.bodyPrefab = bodyPrefab;

            //clear list of null entries
            List<CharacterSelectSurvivorPreviewDisplayController.SkillChangeResponse> newlist = new List<CharacterSelectSurvivorPreviewDisplayController.SkillChangeResponse>();

            for (int i = 0; i < CSSPreviewDisplayConroller.skillChangeResponses.Length; i++) {
                if (CSSPreviewDisplayConroller.skillChangeResponses[i].triggerSkillFamily != null) {
                    newlist.Add(CSSPreviewDisplayConroller.skillChangeResponses[i]);
                }
            }

            CSSPreviewDisplayConroller.skillChangeResponses = newlist.ToArray();
        }
        #endregion
    }
}
