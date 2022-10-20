using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace StandardAssets
{
    [ExecuteAlways]
    public class FOVScaler : MonoBehaviour
    {
        float fixedHorizontalFOV = 35.98339f;

        void Awake()
        {
            Refresh();
        }

        void OnEnable()
        {
            Refresh();
        }

        private void OnValidate()
        {
            Refresh();
        }

        void Refresh()
        {
            GetComponent<Camera>().fieldOfView =
                2 * Mathf.Atan(Mathf.Tan(fixedHorizontalFOV * Mathf.Deg2Rad * 0.5f) / GetComponent<Camera>().aspect) * Mathf.Rad2Deg;
        }

        void Update()
        {
#if UNITY_EDITOR
            Refresh();
#endif
        }
    }
}
