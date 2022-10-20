using System;
using UnityEditor;
using UnityEditor.PackageManager.Requests;
using UnityEditor.PackageManager;
using UnityEngine;

namespace StandardAssets.Editor
{
    static partial class AddPackagesMenu
    {
        static AddRequest Request;

        //[MenuItem("StandardAssets/Add Package/Shader Graph")]
        static void AddShaderGraph()
        {
            Request = Client.Add("com.unity.shadergraph");

            EditorApplication.update += Progress;
        }



        //[MenuItem("StandardAssets/Add Package/TextMeshPro")]
        static void AddTMP()
        {
            Request = Client.Add("com.unity.textmeshpro");

            EditorApplication.update += Progress;
        }

        [MenuItem("StandardAssets/Add Package/Unity Recorder")]
        static void AddRecorder()
        {
            Request = Client.Add("com.unity.recorder");

            EditorApplication.update += Progress;
        }

        //[MenuItem("StandardAssets/Add Package/URP")]
        static void AddURP()
        {
            Request = Client.Add("com.unity.render-pipelines.universal");

            EditorApplication.update += Progress;
        }

        //[MenuItem("StandardAssets/Add Package/LWRP")]
        static void AddLWRP()
        {
            Request = Client.Add("com.unity.render-pipelines.lightweight");

            EditorApplication.update += Progress;
        }
        [MenuItem("StandardAssets/Add Package/Post Processing")]
        static void AddPP()
        {
            Request = Client.Add("com.unity.postprocessing");

            EditorApplication.update += Progress;
        }

        static void Progress()
        {
            if (Request.IsCompleted)
            {
                if (Request.Status == StatusCode.Success)
                {
                    Debug.Log("Installed: " + Request.Result.packageId);
                }
                else if (Request.Status >= StatusCode.Failure)
                {
                    Debug.Log(Request.Error.message);
                }

                EditorApplication.update -= Progress;
            }
        }
    }
}