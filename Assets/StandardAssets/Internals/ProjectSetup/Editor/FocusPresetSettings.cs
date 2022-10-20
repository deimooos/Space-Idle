#if UNITY_EDITOR
using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

namespace StandardAssets.Editor
{
    public class FocusPresetSettings
    {
        //[MenuItem("StandardAssets/Project Setup/Set Preset Settings")]
        public static void FocusPresets()
        {
            EditorUtility.FocusProjectWindow();
            string path = "Assets/StandardAssets/Internals/PresetSettings";
            UnityEngine.Object obj = AssetDatabase.LoadAssetAtPath(path, typeof(UnityEngine.Object));
            Selection.activeObject = obj;
            EditorGUIUtility.PingObject(obj);
            Debug.Log("SA: Focus Presets");
        }

        public enum SettingsWindow { player, quality, time}
        public static void FocusPlayerSettings(SettingsWindow settings)
        {
            EditorUtility.FocusProjectWindow();
            string guid = default;
            UnityEngine.Object obj = new Object();
            switch (settings)
            {
                case SettingsWindow.player:
                    SettingsService.OpenProjectSettings("Project/Player");
                    guid = AssetDatabase.FindAssets("Player Settings", new[] { "Assets/StandardAssets" })[0];
                    obj = AssetDatabase.LoadAssetAtPath(AssetDatabase.GUIDToAssetPath(guid), typeof(UnityEngine.Object));
                    Selection.activeObject = obj;
                    EditorGUIUtility.PingObject(obj);
                    break;
                case SettingsWindow.time:
                    SettingsService.OpenProjectSettings("Project/Time");
                    guid = AssetDatabase.FindAssets("Time Manager", new[] { "Assets/StandardAssets" })[0];
                    obj = AssetDatabase.LoadAssetAtPath(AssetDatabase.GUIDToAssetPath(guid), typeof(UnityEngine.Object));
                    Selection.activeObject = obj;
                    EditorGUIUtility.PingObject(obj);
                    break;
                case SettingsWindow.quality:
                    SettingsService.OpenProjectSettings("Project/Quality");
                    guid = AssetDatabase.FindAssets("Quality Settings", new[] { "Assets/StandardAssets" })[0];
                    obj = AssetDatabase.LoadAssetAtPath(AssetDatabase.GUIDToAssetPath(guid), typeof(UnityEngine.Object));
                    Selection.activeObject = obj;
                    EditorGUIUtility.PingObject(obj);
                    break;
                default:
                    break;
            }
        }
    }
}
#endif
