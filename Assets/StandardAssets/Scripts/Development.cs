using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace StandardAssets
{
    public class Development : MonoBehaviour
    {
#if UNITY_EDITOR

        private void Start()
        {
            CheckCurrentRuntime();
        }

        void CheckCurrentRuntime()
        {
            if (UnityEditor.EditorUserBuildSettings.activeBuildTarget != UnityEditor.BuildTarget.Android &&
                UnityEditor.EditorUserBuildSettings.activeBuildTarget != UnityEditor.BuildTarget.iOS)
            {
                Debug.LogError("SA: " + "Please switch to Android or iOS");
            }
        }

        // Update is called once per frame
        void Update()
        {
            if (Input.GetKeyUp(KeyCode.F))
            {
                SA.StartGame();
            }
            else if (Input.GetKeyUp(KeyCode.G))
            {
                SA.EndGame(true);
            }
            else if (Input.GetKeyUp(KeyCode.H))
            {
                SA.EndGame(false);
            }
        }
#endif

    }
}
