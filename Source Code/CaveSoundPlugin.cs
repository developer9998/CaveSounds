using BepInEx;
using System;
using System.IO;
using System.Reflection;
using UnityEngine;
using Utilla;

namespace CaveSounds
{
    /// <summary>
    /// This is your mod's main class.
    /// </summary>

    [BepInDependency("org.legoandmars.gorillatag.utilla", "1.5.0")]
    [BepInPlugin("com.developer9998.gorillatag.cavesounds", "CaveSounds", "1.0.0")]
    public class CaveSoundPlugin : BaseUnityPlugin
    {
        GameObject soundObject;
        public void Awake()
        {
            Events.GameInitialized += OnGameInitialized;
        }

        void OnGameInitialized(object sender, EventArgs e)
        {
            /* Code here runs after the game initializes (i.e. GorillaLocomotion.Player.Instance != null) */
            Stream manifestResourceStream = Assembly.GetExecutingAssembly().GetManifestResourceStream("CaveSounds.cavesounds");
            AssetBundle assetBundle = AssetBundle.LoadFromStream(manifestResourceStream);
            soundObject = Instantiate(assetBundle.LoadAsset<GameObject>("Sounds"));

            soundObject.AddComponent<CaveSoundManager>();
        }
    }
}
