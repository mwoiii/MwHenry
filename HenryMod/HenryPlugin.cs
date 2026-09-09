using BepInEx;
using BepInEx.Configuration;
using HenryMod.Survivors.Henry;
using R2API.Utils;
using System.Security;
using System.Security.Permissions;

[module: UnverifiableCode]
[assembly: SecurityPermission(SecurityAction.RequestMinimum, SkipVerification = true)]

namespace HenryMod {
    [NetworkCompatibility(CompatibilityLevel.EveryoneMustHaveMod, VersionStrictness.EveryoneNeedSameModVersion)]
    [BepInPlugin(MODUID, MODNAME, MODVERSION)]
    public class HenryPlugin : BaseUnityPlugin {
        public const string MODUID = "com.miyowi.HenryMod";
        public const string MODNAME = "HenryMod";
        public const string MODVERSION = "1.0.0";

        public const string DEVELOPER_PREFIX = "MIYOWI";

        public static HenryPlugin instance;

        public static ConfigFile config;

        void Awake() {
            instance = this;
            config = Config;
            Log.Init(Logger);

            Modules.Language.Init();

            new HenrySurvivor().Init();
            new HenrySurvivorTK().Init();

            //Options.Init();

            new Modules.ContentPacks().Init();
        }
    }
}
