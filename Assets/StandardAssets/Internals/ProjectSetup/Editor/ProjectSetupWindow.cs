using UnityEngine;
using UnityEditor;
using System.Collections;

namespace StandardAssets.Editor
{
    class ProjectSetupWindow : EditorWindow
    {
        [MenuItem("StandardAssets/Project Setup", false,1)]

        public static void ShowWindow()
        {
            EditorWindow.GetWindow(typeof(ProjectSetupWindow), true, "StandardAssets - Project Setup");
        }

        void OnGUI()
        {
            // Switch to Android or iOS
            GUILayout.Label("Project Setup", EditorStyles.boldLabel);
            EditorStyles.label.wordWrap = true;
            GUILayout.Label("This window will guide you through a clean project setup.", EditorStyles.label);
            GUILayout.Space(24);

            GUILayout.Label("1. Switch your target platform to Android or iOS", EditorStyles.label);
            GUILayout.BeginHorizontal();
            if (GUILayout.Button("Android"))
            {
                EditorUserBuildSettings.SwitchActiveBuildTarget(BuildTargetGroup.Android, BuildTarget.Android);
            }
            if (GUILayout.Button("iOS"))
            {
                EditorUserBuildSettings.SwitchActiveBuildTarget(BuildTargetGroup.iOS, BuildTarget.iOS);
            }
            GUILayout.EndHorizontal();
            GUILayout.Space(8);
            GUILayout.Label("2. Set the Load and Game scene in correct order into the Build Settings", EditorStyles.label);
            if (GUILayout.Button("Set Scenes"))
            {
                BuildSettingsSceneSetup.SetScenes();
            }
            GUILayout.Space(8);

            GUILayout.Label("3. Create default folders for this project", EditorStyles.label);
            if (GUILayout.Button("Create Default Folders"))
            {
                CreateFolders.CreateDefaultFolders();
            }
            GUILayout.Space(8);

            GUILayout.Label("4. Set Preset Settings", EditorStyles.label);
            if (GUILayout.Button("Open Preset Settings Folder"))
            {
                FocusPresetSettings.FocusPresets();
            }
            EditorGUI.indentLevel = 1;
            EditorGUILayout.BeginHorizontal();
            GUILayout.Label("Player Settings", EditorStyles.label);
            if (GUILayout.Button("Open"))
            {
                FocusPresetSettings.FocusPlayerSettings(FocusPresetSettings.SettingsWindow.player);
            }
            EditorGUILayout.EndHorizontal();
            EditorGUILayout.BeginHorizontal();
            GUILayout.Label("Quality Settings", EditorStyles.label);
            if (GUILayout.Button("Open"))
            {
                FocusPresetSettings.FocusPlayerSettings(FocusPresetSettings.SettingsWindow.quality);
            }
            EditorGUILayout.EndHorizontal();
            EditorGUILayout.BeginHorizontal();
            GUILayout.Label("Time Settings", EditorStyles.label);
            if (GUILayout.Button("Open"))
            {
                FocusPresetSettings.FocusPlayerSettings(FocusPresetSettings.SettingsWindow.time);
            }
            EditorGUILayout.EndHorizontal();
            //GUILayout.Label("3. Set all Preset Settings", EditorStyles.label);
            //string s = default;
            //s = EditorGUILayout.TextField("Project Name", s);
            //if (GUILayout.Button("Change Project Name"))
            //{
            //    FocusPresetSettings.FocusPresets();
            //}

            // The actual window code goes here
        }
    }
}