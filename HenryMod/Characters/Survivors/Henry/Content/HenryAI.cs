using HenryMod.Modules;
using UnityEngine;

namespace HenryMod.Survivors.Henry {
    public static class HenryAI {
        public static void Init(GameObject masterPrefab) {
            Prefabs.AddMaster(masterPrefab);
        }
    }
}
