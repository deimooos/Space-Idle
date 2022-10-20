using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEditor;
using UnityEngine.Events;

namespace StandardAssets
{
    public class LoadScript : MonoBehaviour
    {
        public static LoadScript loadScript;

        private void Awake()
        {
            loadScript = this;
            LoadScript.AddLoadOperation(true, "Init");
        }

        public void Start()
        {
            CheckLoadType();
        }

        private void CheckLoadType()
        {
            var loadingType = SA.Settings.loadSettings.loadingType;

            switch (loadingType)
            {
                case SettingsData.LoadSettings.LoadingType.directly:
                    Directly();
                    break;
                case SettingsData.LoadSettings.LoadingType.async:
                    Async();
                    break;
                default:
                    Directly();
                    break;
            }

            void Directly()
            {
                new GameObject().AddComponent<DirectlyLoad>();
            }

            void Async()
            {
                new GameObject().AddComponent<AsyncLoad>();
            }
        }

        private static float loadProgress;
        public static float GetLoadProgress()
        {
            return loadProgress;
        }


        public class DirectlyLoad : MonoBehaviour
        {
            public void Awake()
            {
                Debug.Log("SA: Loading direct");
                LoadScript.loadScript.loadEnd += Load;
                loadProgress = 1f;
            }

            private void Start()
            {
                FadeScript.StartFade(false, delegate { /*LoadFillBar.loadFillBar.StartLoad();*/ });
            }

            public void Load()
            {
                FadeScript.StartFade(true, delegate { SA.LoadScene(1); EventScript.LoadSceneFinished(); });
            }
        }

        public class AsyncLoad : MonoBehaviour
        {
            public void Awake()
            {
                Debug.Log("SA: Loading async");
                LoadScript.loadScript.loadEnd += Load;
            }

            private void Start()
            {
                FadeScript.StartFade(false, delegate
                {
                    StartCoroutine(LoadYourAsyncScene());
                    asyncLoad.allowSceneActivation = false;
                    /*LoadFillBar.loadFillBar.StartLoad();*/
                });

            }

            public void Load()
            {
                FadeScript.StartFade(true, delegate { asyncLoad.allowSceneActivation = true; EventScript.LoadSceneFinished(); });
            }

            private void LateUpdate()
            {
                if (asyncLoad != null)
                {
                    loadProgress = asyncLoad.progress / 0.9f;
                }
            }

            private AsyncOperation asyncLoad;
            IEnumerator LoadYourAsyncScene()
            {
                asyncLoad = SceneManager.LoadSceneAsync(1);
                while (!asyncLoad.isDone)
                {
                    yield return null;
                }
            }
        }

        private UnityAction loadEnd;
        private static int _loadOperation;
        public static void AddLoadOperation(bool add = false, string debug = null)
        {
            _loadOperation += add ? 1 : -1;
            LoadScript.loadScript.CheckLoadOperations();

            if (debug != null)
            {
                //Debug.Log("LOADOP: " + add + "_" + debug);
            }
        }


        public void CheckLoadOperations()
        {
            if (_loadOperation <= 0)
            {
                if (loadScript.loadEnd != null)
                {
                    loadScript.loadEnd.Invoke();
                }
            }
        }
    }
}