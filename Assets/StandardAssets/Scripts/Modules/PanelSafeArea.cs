using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace StandardAssets
{
    public class PanelSafeArea : MonoBehaviour
    {
        RectTransform Panel;
        Rect LastSafeArea = new Rect(0, 0, 0, 0);

        private void OnValidate()
        {
            Init();
        }

        void Awake()
        {
            Init();
        }

        private void Start()
        {
            Init();
        }

        void Init()
        {
            Panel = GetComponent<RectTransform>();
            Panel.offsetMin = Vector2.zero;
            Panel.offsetMax = Vector2.zero;
            Refresh();
        }

        private void Update()
        {
            if (Application.isPlaying)
            {
                enabled = false;
            }
            Init();
        }

        void Refresh()
        {
            Rect safeArea = GetSafeArea();

            if (safeArea != LastSafeArea)
            {
                ApplySafeArea(safeArea);
            }
        }

        Rect GetSafeArea()
        {
            return Screen.safeArea;
        }

        void ApplySafeArea(Rect r)
        {
            LastSafeArea = r;

            // Convert safe area rectangle from absolute pixels to normalised anchor coordinates
            Vector2 anchorMin = r.position;
            Vector2 anchorMax = r.position + r.size;
            anchorMin.x /= Screen.width;
            anchorMin.y /= Screen.height;
            anchorMax.x /= Screen.width;
            anchorMax.y /= Screen.height;
            Panel.anchorMin = anchorMin;
            Panel.anchorMax = anchorMax;

            //Debug.LogFormat("New safe area applied to {0}: x={1}, y={2}, w={3}, h={4} on full extents w={5}, h={6}",
            //name, r.x, r.y, r.width, r.height, Screen.width, Screen.height);
        }
    }
}