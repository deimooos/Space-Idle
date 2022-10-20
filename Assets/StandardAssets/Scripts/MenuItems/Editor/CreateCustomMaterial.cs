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
    public class CreateCustomMaterial : MonoBehaviour
    {
        [MenuItem("Assets/Create/Hybrid Material", false, -1)]
        private static void CreateNewAsset()
        {
            //Shader s = Shader.Find("Transparent/Diffuse"); ;
            //Material a = new Material(s);
            //ProjectWindowUtil.CreateAsset(a, "");
            //ProjectWindowUtil.CreateAssetWithContent(
            //  "Default Name.mat",
            //string.Empty);
            Material material;

            if (Shader.Find("Toony Colors Pro 2/Hybrid Shader"))
            {
                material = new Material(Shader.Find("Toony Colors Pro 2/Hybrid Shader"));
            }
            else
            {
                Debug.LogError("SA: New Hybrid Material couldn't be created because 'Hybrid Shader' is missing.");
                return; 
            }
            //AssetDatabase.CreateAsset(material, string.Empty);

            string path = AssetDatabase.GetAssetPath(Selection.activeObject);
            if (path == "")
            {
                path = "Assets";
            }
            else if (Path.GetExtension(path) != "")
            {
                path = path.Replace(Path.GetFileName(AssetDatabase.GetAssetPath(Selection.activeObject)), "");
            }
            ProjectWindowUtil.CreateAsset(material, AssetDatabase.GenerateUniqueAssetPath(path + "/New Material.mat"));
        }
    }
}
