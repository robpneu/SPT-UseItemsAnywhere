using BepInEx;
using BepInEx.Configuration;
using DrakiaXYZ.VersionChecker;
using System;
using static UseItemsFromAnywhere.UseItemsFromAnywhere;

namespace UseItemsFromAnywhere
{
    [BepInPlugin("com.dirtbikercj.useFromAnywhere", "Use items from any place in your inventory", "1.0.5")]
    public class Plugin : BaseUnityPlugin
    {
        public const int TarkovVersion = 29197;

        public static Plugin instance;

        internal void Awake()
        {
            if (!VersionChecker.CheckEftVersion(Logger, Info, Config))
            {
                throw new Exception("Invalid EFT Version");
            }

            instance = this;
            DontDestroyOnLoad(this);

            new IsAtBindablePlace().Enable();
            new IsAtReachablePlace().Enable();
        }
    }
}