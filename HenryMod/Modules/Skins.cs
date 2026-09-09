using RoR2;
using System;
using UnityEngine;

namespace HenryMod.Modules {
    internal static class Skins {
        internal static SkinDef CreateSkinDef(string skinName, Sprite skinIcon, CharacterModel.RendererInfo[] defaultRendererInfos, GameObject root, UnlockableDef unlockableDef = null) {
            SkinDefInfo skinDefInfo = new SkinDefInfo {
                BaseSkins = Array.Empty<SkinDef>(),
                GameObjectActivations = new SkinDefParams.GameObjectActivation[0],
                Icon = skinIcon,
                MeshReplacements = new SkinDefParams.MeshReplacement[0],
                MinionSkinReplacements = new SkinDefParams.MinionSkinReplacement[0],
                Name = skinName,
                NameToken = skinName,
                ProjectileGhostReplacements = new SkinDefParams.ProjectileGhostReplacement[0],
                RendererInfos = new CharacterModel.RendererInfo[defaultRendererInfos.Length],
                RootObject = root,
                UnlockableDef = unlockableDef
            };

            SkinDef skinDef = ScriptableObject.CreateInstance<RoR2.SkinDef>();
            skinDef.skinDefParams = ScriptableObject.CreateInstance<RoR2.SkinDefParams>();
            skinDef.baseSkins = skinDefInfo.BaseSkins;
            skinDef.icon = skinDefInfo.Icon;
            skinDef.unlockableDef = skinDefInfo.UnlockableDef;
            skinDef.rootObject = skinDefInfo.RootObject;
            defaultRendererInfos.CopyTo(skinDefInfo.RendererInfos, 0);
            skinDef.skinDefParams.rendererInfos = skinDefInfo.RendererInfos;
            skinDef.skinDefParams.gameObjectActivations = skinDefInfo.GameObjectActivations;
            skinDef.skinDefParams.meshReplacements = skinDefInfo.MeshReplacements;
            skinDef.skinDefParams.projectileGhostReplacements = skinDefInfo.ProjectileGhostReplacements;
            skinDef.skinDefParams.minionSkinReplacements = skinDefInfo.MinionSkinReplacements;
            skinDef.nameToken = skinDefInfo.NameToken;
            skinDef.name = skinDefInfo.Name;

            return skinDef;
        }
        internal struct SkinDefInfo {
            internal SkinDef[] BaseSkins;
            internal Sprite Icon;
            internal string NameToken;
            internal UnlockableDef UnlockableDef;
            internal GameObject RootObject;
            internal CharacterModel.RendererInfo[] RendererInfos;
            internal SkinDefParams.MeshReplacement[] MeshReplacements;
            internal SkinDefParams.GameObjectActivation[] GameObjectActivations;
            internal SkinDefParams.ProjectileGhostReplacement[] ProjectileGhostReplacements;
            internal SkinDefParams.MinionSkinReplacement[] MinionSkinReplacements;
            internal string Name;
        }
    }
}