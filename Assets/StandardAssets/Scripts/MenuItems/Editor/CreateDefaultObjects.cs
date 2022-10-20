using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;
using System.Linq;
using System;
using UnityEditor.PackageManager.Requests;
using UnityEditor.PackageManager;
using System.Reflection;
using UnityEngine.UI;
using System.IO;

namespace StandardAssets.Editor
{
    public class CreateDefaultObjects : MonoBehaviour
    {
        [MenuItem("GameObject/SA/Panel", false, -1)]
        static void CreatePanel(MenuCommand menuCommand)
        {
            GameObject go = new GameObject("Panel");
            var rt = go.AddComponent<RectTransform>();
            go.AddComponent<PanelSafeArea>();

            rt.anchorMin = new Vector2(0, 0);
            rt.anchorMax = new Vector2(1, 1);
            rt.pivot = new Vector2(0.5f, 0.5f);
            // Ensure it gets reparented if this was a context click (otherwise does nothing)
            GameObjectUtility.SetParentAndAlign(go, menuCommand.context as GameObject);
            // Register the creation in the undo system
            Undo.RegisterCreatedObjectUndo(go, "Create " + go.name);
            Selection.activeObject = go;
        }

        [MenuItem("GameObject/SA/Canvas", false, -1)]
        static void CreateCanvas(MenuCommand menuCommand)
        {
            GameObject go = new GameObject("Canvas");
            var c = go.AddComponent<Canvas>();
            go.AddComponent<CanvasScaler>();
            go.AddComponent<GraphicRaycaster>();
            go.AddComponent<CanvasModifier>();

            // Ensure it gets reparented if this was a context click (otherwise does nothing)
            GameObjectUtility.SetParentAndAlign(go, menuCommand.context as GameObject);
            // Register the creation in the undo system
            Undo.RegisterCreatedObjectUndo(go, "Create " + go.name);
            Selection.activeObject = go;
        }
        
        [MenuItem("GameObject/SA/StandardAssets", false, -1)]
        static void CreateStandardAssets(MenuCommand menuCommand)
        {
            GameObject go = new GameObject("StandardAssets");
            go.AddComponent<Initialize>();

            // Ensure it gets reparented if this was a context click (otherwise does nothing)
            GameObjectUtility.SetParentAndAlign(go, menuCommand.context as GameObject);
            // Register the creation in the undo system
            Undo.RegisterCreatedObjectUndo(go, "Create " + go.name);
            Selection.activeObject = go;
        }
    }
}
