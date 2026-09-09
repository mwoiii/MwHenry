using BepInEx.Configuration;
using RiskOfOptions;
using RiskOfOptions.OptionConfigs;
using RiskOfOptions.Options;

namespace HenryMod {

    public class Options {

        private static bool? _rooEnabled;

        public static bool rooEnabled {
            get {
                if (_rooEnabled == null) {
                    _rooEnabled = BepInEx.Bootstrap.Chainloader.PluginInfos.ContainsKey("com.rune580.riskofoptions");
                }
                return (bool)_rooEnabled;
            }
        }

        public static ConfigEntry<bool> exampleConfig { get; set; }

        public static void Init() {
            exampleConfig = HenryPlugin.config.Bind("Example Category", "Example Name", true, "Example description");

            if (rooEnabled) {
                RoOInit();
            }
        }

        private static void RoOInit() {
            ModSettingsManager.AddOption(new CheckBoxOption(exampleConfig, new CheckBoxConfig()));

            ModSettingsManager.SetModDescription("Config options relating to the Henry survivor mod.");
            //ModSettingsManager.SetModIcon(HenryAssets.assetBundle.LoadAsset<Sprite>("texHenryIcon"));
        }
    }
}