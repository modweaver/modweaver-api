using HarmonyLib;
using modweaver.api.Internal;
using modweaver.core;

namespace modweaver.api
{
    [ModMainClass]
    public class ModweaverAPI : Mod
    {
        public override void Init()
        {
            InternalUtils.Logger = Logger;
            InternalUtils.init();
            // your manifest is the mw.mod.toml file
            // use Metadata to access the values you provided in the manifest. Manifest is also available, and provides the other data such as your dependencies and incompats
            Logger.Info("Loading {0} v{1} by {2}!", Metadata.title, Metadata.version,
                string.Join(", ", Metadata.authors));

            Logger.Debug("Setting up patcher...");
            Harmony harmony = new Harmony(Metadata.id); 
            Logger.Debug("Patching...");
            harmony.PatchAll();
        }

        public override void Ready()
        {
            Logger.Info("Loaded {0}!", Metadata.title);
        }

        public override void OnGUI(ModsMenuPopup ui)
        {
            // you can add data to your mods page here
            // we recommend if you are going to add ui here, put
            // ui.CreateDivider() first
            // you'll see why :3
        }
    }
    
    // no more laser cubes! this stops laser cubes from firing their beams. you can do whatever you want with this.
    //[HarmonyPatch(typeof(LaserCube), nameof(LaserCube.ActivateBeams))]
    //public static class NoMoreLaserCubes
    //{
    //    public static bool Prefix()
    //    {
    //        return false; // this stops the original code from running!
    //    }
    //}
}