using RoR2;
using RoR2BepInExPack.GameAssetPaths.Version_1_39_0;
using UnityEngine;
using UnityEngine.AddressableAssets;

namespace HenryMod.Modules {
    internal static class Prefabs {

        private static PhysicMaterial ragdollMaterial;

        public static GameObject CreateDisplayPrefab(AssetBundle assetBundle, string displayPrefabName, GameObject prefab) {
            GameObject display = assetBundle.LoadAsset<GameObject>(displayPrefabName);
            if (display == null) {
                Log.Error($"could not load display prefab {displayPrefabName}. Make sure this prefab exists in assetbundle {assetBundle.name}");
                return null;
            }

            CharacterModel characterModel = display.GetComponent<CharacterModel>();
            if (!characterModel) {
                characterModel = display.AddComponent<CharacterModel>();
            }
            characterModel.baseRendererInfos = prefab.GetComponentInChildren<CharacterModel>().baseRendererInfos;

            return display;
        }

        #region body setup
        public static GameObject LoadDisplayPrefab(AssetBundle assetBundle, string modelName) {
            GameObject model = assetBundle.LoadAsset<GameObject>(modelName);
            if (model == null) {
                Log.Error($"could not load display prefab {modelName}. Make sure this prefab exists in assetbundle {assetBundle.name}");
                return null;
            }
            return model;
        }

        public static GameObject LoadCharacterBody(AssetBundle assetBundle, string bodyName) {
            GameObject body = assetBundle.LoadAsset<GameObject>(bodyName);
            if (body == null) {
                Log.Error($"could not load body prefab {bodyName}. Make sure this prefab exists in assetbundle {assetBundle.name}");
                return null;
            }
            Content.AddCharacterBodyPrefab(body);
            return body;
        }
        #endregion


        #region ModelSetup
        public static void SetupRagdoll(GameObject model) {
            RagdollController ragdollController = model.GetComponent<RagdollController>();

            if (!ragdollController) return;

            if (ragdollMaterial == null) ragdollMaterial = Addressables.LoadAssetAsync<PhysicMaterial>(RoR2_Base_Common.physmatRagdoll_physicMaterial).WaitForCompletion();

            foreach (Transform boneTransform in ragdollController.bones) {
                if (boneTransform) {
                    boneTransform.gameObject.layer = LayerIndex.ragdoll.intVal;
                    Collider boneCollider = boneTransform.GetComponent<Collider>();
                    if (boneCollider) {
                        boneCollider.sharedMaterial = ragdollMaterial;
                    } else {
                        Log.Error($"Ragdoll bone {boneTransform.gameObject} doesn't have a collider. Ragdoll will break.");
                    }
                }
            }
        }
        #endregion

        #region master        
        public static void AddMaster(GameObject masterPrefab) {
            ContentPacks.masterPrefabs.Add(masterPrefab);
        }
        #endregion master
    }
}