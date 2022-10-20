using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using System.Runtime.Serialization.Formatters.Binary;
using System.IO;
using System.Reflection;

namespace StandardAssets
{
    public class Initialize : MonoBehaviour
    {
        void Awake()
        {
            Init();
        }

        void Init()
        {
            if (SA.Init) { enabled = false; gameObject.SetActive(false); Destroy(gameObject); return; }

            if (SceneManager.GetActiveScene().buildIndex != 0)
            {
                SA.LoadScene(0);
                return;
            }

            SA.Init = this;
            DontDestroyOnLoad(this.gameObject);

            StartOperations();
        }

        /// <summary>
        /// Is the main method for StandardAssets, loads all operations at the beginning
        /// </summary>
        void StartOperations()
        {
            SA.LoadAll();

            // Add here your operation
            AddOperation(typeof(LoadScript));
            AddOperation(typeof(EventScript));
            AddOperation(typeof(Development));
            AddOperation(typeof(OtherSettings));
            SA.SetFrameRate();
            //

            SDKScript.Init();
            SA.CheckPrivacyPolicyAccepted();

            // Waits for all operations adding their AddLoadOperation
            StartCoroutine(SA.Timer(0.25f, delegate { LoadScript.AddLoadOperation(false, "Init"); }));

            void AddOperation(Type type)
            {
                gameObject.AddComponent(type);
            }
        }
    }

    public partial class SA
    {
        public static Initialize Init;

        public static SettingsData Settings;
        public static SDKData SDKData;
        public static SaveData SaveData;
        public static TextStyleData TextStyleData;

        #region Scene Loading
        /// <summary>
        /// Loads scene with sent index
        /// </summary>
        /// <param name="sceneIndex">Loads scene with index </param>
        public static void LoadScene(int sceneIndex)
        {
            SceneManager.LoadScene(sceneIndex);
        }
        /// <summary>
        /// Loads the next scene from the current active scene build index
        /// If not next scene exists, reloads current scene
        /// </summary>
        public static void LoadScene()
        {
            if (SceneManager.sceneCountInBuildSettings > SceneManager.GetActiveScene().buildIndex + 1)
            {
                SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
            }
            else
            {
                SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
            }
        }

        public static void ReloadScene(int sceneIndex = 1)
        {
            FadeScript.StartFade(true, delegate { EventScript.NextScene(); SA.LoadScene(sceneIndex); });
        }
        #endregion

        #region Load & Save Settings & Data
        public static void LoadAll()
        {
            LoadSettings();
            LoadSaveData();

            void LoadSaveData()
            {
                // Loads Save Data
                if (SA.Settings.loadSettings.loadSaveData == true)
                {
                    SA.SaveData = SA.SaveData == null ? new SaveData() : SA.SaveData;
                    SA.LoadData();
                }
                else
                {
                    SA.SaveData = new SaveData();
                }
            }
        }

        [ObsoleteAttribute("Don't calculate camera position with SA.CameraScale(). Instead just add FOVScaler into your Camera as a component.", false)]
        public static float CameraScale()
        {
            Debug.LogError("SA: Don't calculate camera position with SA.CameraScale(). Instead just add FOVScaler into your Camera.");
            return 1f;
        }

        private static void LoadData()
        {
            if (File.Exists(savePath))
            {
                BinaryFormatter binaryFormatter = new BinaryFormatter();
                FileStream fileStream = new FileStream(savePath, FileMode.Open);

                SA.SaveData = binaryFormatter.Deserialize(fileStream) as SaveData;
                fileStream.Close();
            }
            else
            {
                SA.SaveData = new SaveData();
            }
        }

        public static void LoadSettings()
        {
            // Loads Settings Scriptable from Resources
            SA.Settings = Resources.Load("SettingsData") as SettingsData;
            if (!SA.Settings)
            {
                SA.Settings = ScriptableObject.CreateInstance(nameof(SettingsData)) as SettingsData;
                //Debug.Log("SA: " + "Settings couldn't be found in Resources folder. Create new Settings there.");
            }

            // Loads SDK Scriptable from Resources
            SA.SDKData = Resources.Load("SDKData") as SDKData;
            if (!SA.SDKData)
            {
                SA.SDKData = ScriptableObject.CreateInstance(nameof(SDKData)) as SDKData;
                //Debug.Log("SA: " + "SDK Data couldn't be found in Resources folder. Create new SDK Data there.");
            }

            SA.TextStyleData = Resources.Load("TextStyleData") as TextStyleData;
            if (!SA.TextStyleData)
            {
                SA.TextStyleData = ScriptableObject.CreateInstance(nameof(TextStyleData)) as TextStyleData;
                //Debug.Log("SA: " + "TextStyleData couldn't be found in Resources folder. Create new TextStyleData there.");
            }
        }

        static readonly string savePath = Application.persistentDataPath + "/save.data";
        public static void Save()
        {
            if (SA.Settings.loadSettings.loadSaveData == false)
            {
                return;
            }

            BinaryFormatter binaryFormatter = new BinaryFormatter();
            FileStream fileStream = new FileStream(savePath, FileMode.Create);

            binaryFormatter.Serialize(fileStream, SA.SaveData != null ? SA.SaveData : new SaveData());
            fileStream.Close();
        }

        static partial void CheckPrivacyPolicy();
        public static void CheckPrivacyPolicyAccepted()
        {
            CheckPrivacyPolicy();
        }
        #endregion

        #region Game Behaviour (Start, End etc.)
        private static bool _isGame;
        public static bool IsGame
        {
            get
            {
                return _isGame;
            }
            set
            {
                if (value == true)
                {
                    Debug.Log("SA: IsGame set true");
                }
                else if (value == false)
                {
                    Debug.Log("SA: IsGame set false");
                }

                _isGame = value;
            }
        }

        public static void StartGame(bool openPanel = true)
        {
            if (SA.IsGame == true)
            {
                Debug.Log("SA: Game already started");
                return;
            }

            SA.IsGame = true;
            EventScript.LevelStart();

            if (openPanel == true)
            {
                Manager.manager.GamePanel();
            }
        }

        public static void EndGame(bool win, bool openPanel = true)
        {
            SA.IsGame = false;

            if (win)
            {
                SA.SaveData.level++;
                Save();

                if (openPanel == true)
                {
                    Manager.manager.WinPanel();
                }
            }
            else
            {
                if (openPanel == true)
                {
                    Manager.manager.LosePanel();
                }
            }
            EventScript.LevelEnd(win, SA.SaveData.level);
        }
        #endregion

        public enum HapticTypes { Selection, Success, Warning, Failure, LightImpact, MediumImpact, HeavyImpact, RigidImpact, SoftImpact, None }
        static partial void Haptic(HapticTypes haptic);
        public static void PlayHaptic(HapticTypes haptic)
        {
            Haptic(haptic);
        }

        public static string GetHierachyPath(Transform current)
        {
            if (current.parent == null)
            {
                return current.name;
            }
            return GetHierachyPath(current.parent) + "/" + current.name;
        }

        public static IEnumerator Timer(float time, UnityEngine.Events.UnityAction action = null)
        {
            yield return new WaitForSecondsRealtime(time);
            if (action != null)
            {
                action.Invoke();
            }
        }

        public static Color HSVToRGB(float h, float s, float v, float alpha = 1f)
        {
            Color color = Color.HSVToRGB(h, s, v);
            color.a = alpha;
            return color;
        }

        public static void SetFrameRate()
        {
            QualitySettings.vSyncCount = 0;
            Application.targetFrameRate = 60;
        }

        /// <summary>
        /// Get color in HSV code (Use H: 0-360, S: 0-100, V: 0-100, A: 0-100)
        /// </summary>
        /// <param name="h"0-360</param>
        /// <param name="s">0-100</param>
        /// <param name="v">0-100</param>
        /// <param name="alpha">0-100f</param>
        /// <returns></returns>
        public static Color HSVToRGB360(float h, float s, float v, float alpha = 100f)
        {
            Color color = Color.HSVToRGB(h / 360f, s / 100f, v / 100f);
            color.a = alpha / 100f;
            return color;
        }
    }

    public partial class SDKScript
    {
        static partial void InitSDKs();

        public static void Init()
        {
            InitSDKs();
        }
    }
}
