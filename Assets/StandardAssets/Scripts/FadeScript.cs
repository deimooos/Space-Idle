using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

namespace StandardAssets
{
    public partial class FadeScript : MonoBehaviour
    {
        public static FadeScript fadeScript;

        private void Awake()
        {
            fadeScript = this;
            image = GetComponent<Image>();
            StartFade(false, null);
        }

        private UnityAction action;
        /// <summary>
        /// true if we want to go out of the scene, false if we start in the scene
        /// </summary>
        public static void StartFade(bool fadeToBlack, UnityAction action)
        {
            fadeScript.Init(fadeToBlack);
            fadeScript.action = action;
        }


        //////////////// Animation /////////////////////

        private Color colorFrom;
        private Color colorTo;
        private Image image;
        private void Init(bool fadeToBlack)
        {
            fadeScript.colorFrom = fadeToBlack ? Color.clear : Color.black;
            fadeScript.colorTo = fadeToBlack ? Color.black : Color.clear;

            fadeScript.image.color = fadeScript.colorFrom;

            fadeScript.time = 0;
            animate = true;

            fadeScript.image.raycastTarget = true;
        }


        // Animation /////////////////////////


        private bool animate;
        private void LateUpdate()
        {
            if (animate)
            {
                CountTime();
            }
        }

        private float time;
        private void CountTime()
        {
            time += Time.unscaledDeltaTime;
            Animate();
            if (time >= SA.Settings.otherSettings.fadeTime)
            {
                Finish();
            }
        }

        private void Animate()
        {
            image.color = Color.Lerp(colorFrom, colorTo, time / SA.Settings.otherSettings.fadeTime);
        }

        private void Finish()
        {
            time = 0;
            animate = false;
            fadeScript.image.raycastTarget = false;
            if (action != null)
            {
                action.Invoke();
            }
        }
    }
}
