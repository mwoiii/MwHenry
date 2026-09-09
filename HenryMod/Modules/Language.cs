using R2API;
using System;
using System.Collections.Generic;
using System.IO;

namespace HenryMod.Modules {
    internal static class Language {
        public static string TokensOutput = "";

        public static bool usingLanguageFolder = false;

        public static bool printingEnabled = false;

        public static void Init() {
            if (usingLanguageFolder) {
                RoR2.Language.collectLanguageRootFolders += Language_collectLanguageRootFolders;
            }
        }

        private static void Language_collectLanguageRootFolders(List<string> obj) {
            string path = Path.Combine(Path.GetDirectoryName(HenryPlugin.instance.Info.Location), "Language");
            if (Directory.Exists(path)) {
                obj.Add(path);
            }
        }

        public static void Add(string token, string text) {
            if (!usingLanguageFolder) {
                LanguageAPI.Add(token, text);
            }

            if (!printingEnabled) return;

            TokensOutput += $"\n    \"{token}\" : \"{text.Replace(Environment.NewLine, "\\n").Replace("\n", "\\n")}\",";
        }

        public static void PrintOutput(string fileName = "") {
            if (!printingEnabled) {
                return;
            }

            string strings = $"{{\n    strings:\n    {{{TokensOutput}\n    }}\n}}";

            Log.Message($"{fileName}: \n{strings}");

            if (!string.IsNullOrEmpty(fileName)) {
                string path = Path.Combine(Directory.GetParent(HenryPlugin.instance.Info.Location).FullName, "Language", "en", fileName);
                File.WriteAllText(path, strings);
            }

            TokensOutput = "";
        }
    }
}