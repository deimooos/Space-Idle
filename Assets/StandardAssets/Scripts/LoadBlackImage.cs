using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using StandardAssets;
using UnityEngine.UI;

namespace StandardAssets
{
    [ExecuteInEditMode]
    public class LoadBlackImage : MonoBehaviour
    {
        // Start is called before the first frame update
        void OnValidate()
        {
            Init();
        }

        private void Awake()
        {
            Init();
        }

        private void Start()
        {
            Init();
        }

        void Init()
        {
            if (SA.Settings != null)
            {
                gameObject.GetComponent<Image>().enabled = (SA.Settings.loadSettings.loadingStyle == SettingsData.LoadSettings.LoadingStyle.black);
            }
        }

        private void Update()
        {
            if (Application.isPlaying)
            {
                enabled = false;
            }
            Init();
        }
    }
}
