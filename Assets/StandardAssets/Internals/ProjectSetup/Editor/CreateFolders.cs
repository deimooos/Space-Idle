#if UNITY_EDITOR
using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

namespace StandardAssets.Editor
{
    public class CreateFolders
    {
        //[MenuItem("StandardAssets/Project Setup/Create Default Folders")]
        public static void CreateDefaultFolders()
        {
            CreateFolder("Resources");
            CreateFolder("Materials");
            CreateFolder("Prefabs");
            CreateFolder("Levels","/Resources");
            CreateFolder("Scripts");
            CreateFolder("Models");
            CreateFolder("Models");
            CreateFolder("Animation");
            Debug.Log("SA: Default folders created");
        }

        public static void CreateFolder(string folderName, string path = "")
        {
            string parentFolder = "Assets";
            if (!AssetDatabase.IsValidFolder(parentFolder + "/" + folderName))
            {
                AssetDatabase.CreateFolder(parentFolder + path, folderName);
            }
        }
    }
}
#endif
