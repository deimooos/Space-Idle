using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

namespace StandardAssets
{
    public class LoadFillBar : MonoBehaviour
    {
        public static LoadFillBar loadFillBar;

        private void Awake()
        {
            loadFillBar = this;
            if(fillImage == null)
            {
                Debug.LogError("SA: Set fillImage in Load Scene.");
                enabled = false;
                return;
            }
            fillImage.fillAmount = 0;
        }


        private SettingsData.LoadSettings.LoadingType loadType;
        public void Start()
        {
            LoadScript.AddLoadOperation(true, "Fill Bar");
            StartCoroutine(SA.Timer(0.1f, delegate { Now(); }));
        }

        public void Now()
        {
            if (SA.Settings.loadSettings.loadingStyle == SettingsData.LoadSettings.LoadingStyle.black)
            {
                FillFinished();
            }
            else
            {
                Debug.Log("StartLoad()");
                loadType = SA.Settings.loadSettings.loadingType;
                startFill = true;
            }
        }

        public Image fillImage;

        private bool startFill;
        private float time = 0;

        private void LateUpdate()
        {
            if (startFill)
            {
                DirectlyFill();
                AsyncFill();

                void AsyncFill()
                {
                    if (loadType == SettingsData.LoadSettings.LoadingType.async && LoadScript.GetLoadProgress() == 1f)
                    {
                        time += Time.unscaledDeltaTime;
                        fillImage.fillAmount = Mathf.Lerp(0f, LoadScript.GetLoadProgress(), time * time * time / 2f);
                        if (fillImage.fillAmount == 1f)
                        {
                            Debug.Log("LoadBarFinished()");
                            FillFinished();
                        }
                    }
                }

                void DirectlyFill()
                {
                    if (loadType == SettingsData.LoadSettings.LoadingType.directly)
                    {
                        time += Time.unscaledDeltaTime;
                        fillImage.fillAmount = Mathf.Lerp(0f, LoadScript.GetLoadProgress(), time * time * time / 2f);
                        if (fillImage.fillAmount == 1f)
                        {
                            Debug.Log("LoadBarFinished()");
                            FillFinished();
                        }
                    }
                }
            }
        }

        private bool onetime;
        private void FillFinished()
        {
            if (onetime == false)
            {
                LoadScript.AddLoadOperation(false, "Fill Bar");
                enabled = false;
            }
        }
    }
}
