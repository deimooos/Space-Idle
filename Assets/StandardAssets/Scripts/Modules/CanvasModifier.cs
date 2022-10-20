using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

namespace StandardAssets
{
    public class CanvasModifier : MonoBehaviour
    {
        private void Init()
        {
            GetComponent<Canvas>().worldCamera = Camera.main;
            GetComponent<Canvas>().renderMode = RenderMode.ScreenSpaceOverlay;
            SetCanvasScaling();
        }

        private void OnValidate()
        {
            Init();
        }

        private void Awake()
        {
            Init();
        }

        private void SetCanvasScaling()
        {
            if (!GetComponent<CanvasScaler>())
            {
                return;
            }

            CanvasScaler canvasScaler = GetComponent<CanvasScaler>();

            canvasScaler.uiScaleMode = CanvasScaler.ScaleMode.ScaleWithScreenSize;
            canvasScaler.screenMatchMode = CanvasScaler.ScreenMatchMode.MatchWidthOrHeight;
            canvasScaler.referenceResolution = new Vector2(720f, 1280f);

            if (canvasScaler)
            {
                if (Camera.main)
                {
                    bool b = Mathf.Floor(Camera.main.aspect * 10f) / 10 <= Mathf.Floor((9 / 16f) * 10f) / 10f;
                    canvasScaler.matchWidthOrHeight = b ? 0 : 1;
                }
            }
        }
    }
}
