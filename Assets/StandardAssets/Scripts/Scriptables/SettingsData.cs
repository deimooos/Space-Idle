using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace StandardAssets
{
    [ExecuteAlways]
    [CreateAssetMenu(fileName = "SettingsData", menuName = "StandardAssets/SettingsData", order = 1)]
    public partial class SettingsData : ScriptableObject
    {
        private void OnValidate()
        {
            SA.Settings = Resources.Load("StandardAssets/Settings") as SettingsData;
        }

        private void Update()
        {
#if UNITY_EDITOR
            SA.Settings = Resources.Load("StandardAssets/Settings") as SettingsData;
#endif
        }

        public LoadSettings loadSettings = new LoadSettings();
        public OtherSettings otherSettings = new OtherSettings();

        [System.Serializable]
        public class LoadSettings
        {
            public bool loadSaveData = true;

            public enum LoadingType { directly, async }
            [Tooltip("Use 'directly' if our scenes don't need load much at the beginning. " +
                "Use 'async' if we load many things for the whole game session.")]
            public LoadingType loadingType = LoadingType.directly;

            public enum LoadingStyle { black, loadingScreen }
            public LoadingStyle loadingStyle = LoadingStyle.loadingScreen;
        }

        [System.Serializable]
        public class OtherSettings
        {
            public bool haptics = true;

            public float fadeTime = 0.375f;
            public float timeDistance = 0.5f;

            public float imageFadeInTime = 0.25f;
        }
    }
}
