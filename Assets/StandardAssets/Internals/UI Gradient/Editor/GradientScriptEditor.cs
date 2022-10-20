using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using StandardAssets;
using UnityEditor;

[CustomEditor(typeof(UIGradientScript))]
public class GradientScriptEditor : Editor
{
    public override void OnInspectorGUI()
    {
        UIGradientScript myScript = (UIGradientScript)target;
        GUILayout.Space(16);

        if (GUILayout.Button("Refresh"))
        {
            myScript.Refresh();
        }
        DrawDefaultInspector();
    }
}
