using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;
using UnityEditor.Presets;


namespace StandardAssets
{
    public class BuildSettingsSceneSetup
    {
        public static List<SceneAsset> m_SceneAssets = new List<SceneAsset>();
        
        //[MenuItem("StandardAssets/Project Setup/Set Scenes")]
        public static void SetScenes()
        {
            m_SceneAssets.Clear();

            string[] guids = AssetDatabase.FindAssets("Load t:Scene");
            SceneAsset load = AssetDatabase.LoadAssetAtPath(AssetDatabase.GUIDToAssetPath(guids[0]), typeof(SceneAsset)) as SceneAsset;

            guids = AssetDatabase.FindAssets("Game t:Scene");
            SceneAsset game = AssetDatabase.LoadAssetAtPath(AssetDatabase.GUIDToAssetPath(guids[0]), typeof(SceneAsset)) as SceneAsset;

            m_SceneAssets.Add(load);
            m_SceneAssets.Add(game);
            SetEditorBuildSettingsScenes();
            Debug.Log("SA: Set Scenes");
        }



        public static void SetEditorBuildSettingsScenes()
        {
            // Find valid Scene paths and make a list of EditorBuildSettingsScene
            List<EditorBuildSettingsScene> editorBuildSettingsScenes = new List<EditorBuildSettingsScene>();
            editorBuildSettingsScenes.Clear();
            foreach (var sceneAsset in m_SceneAssets)
            {
                string scenePath = AssetDatabase.GetAssetPath(sceneAsset);
                if (!string.IsNullOrEmpty(scenePath))
                    editorBuildSettingsScenes.Add(new EditorBuildSettingsScene(scenePath, true));
            }

            // Set the Build Settings window Scene list
            EditorBuildSettings.scenes = editorBuildSettingsScenes.ToArray();
        }

        // This method uses a Preset to copy the serialized values from the source to the target and return true if the copy succeed.
        public static bool CopyObjectSerialization(Object source, Object target)
        {
            Preset preset = new Preset(source);
            return preset.ApplyTo(target);
        }
    }
}
