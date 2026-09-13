using RoR2;
using UnityEngine;

namespace HenryMod.Modules.Characters {
    public abstract class CharacterBase<T> where T : CharacterBase<T>, new() {
        public abstract string assetBundleName { get; }

        public abstract string bodyName { get; }

        public virtual ItemDisplaysBase itemDisplays { get; }

        public static T instance { get; private set; }

        public virtual AssetBundle assetBundle { get; protected set; }

        public virtual GameObject bodyPrefab { get; protected set; }

        public virtual CharacterBody prefabCharacterBody { get; protected set; }

        public virtual GameObject characterModelObject { get; protected set; }

        public virtual CharacterModel prefabCharacterModel { get; protected set; }

        public virtual void Init() {
            instance = this as T;
            assetBundle = Asset.LoadAssetBundle(assetBundleName);

            InitCharacter();
        }

        public virtual void InitCharacter() {
            InitCharacterBodyPrefab();

            InitItemDisplays();
        }

        protected virtual void InitCharacterBodyPrefab() {
            bodyPrefab = Prefabs.LoadCharacterBody(assetBundle, bodyName);

            prefabCharacterBody = bodyPrefab.GetComponent<CharacterBody>();

            characterModelObject = bodyPrefab.GetComponent<ModelLocator>().modelTransform.gameObject;

            prefabCharacterModel = characterModelObject.GetComponent<CharacterModel>();
        }

        public virtual void InitItemDisplays() {
            ItemDisplayRuleSet itemDisplayRuleSet = ScriptableObject.CreateInstance<ItemDisplayRuleSet>();
            itemDisplayRuleSet.name = "idrs" + bodyName;

            prefabCharacterModel.itemDisplayRuleSet = itemDisplayRuleSet;

            if (itemDisplays != null) {
                ItemDisplays.queuedDisplays++;
                RoR2.ContentManagement.ContentManager.onContentPacksAssigned += SetItemDisplays;
            }
        }

        public void SetItemDisplays(HG.ReadOnlyArray<RoR2.ContentManagement.ReadOnlyContentPack> obj) {
            itemDisplays.SetItemDisplays(prefabCharacterModel.itemDisplayRuleSet);
        }
    }
}
