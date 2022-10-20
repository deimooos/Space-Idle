using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

namespace StandardAssets
{
    public partial class ImageFadeIn : MonoBehaviour
    {
        private Color _startColor;
        private Color _imageColor;

        private void Awake()
        {
            _image = GetComponent<Image>();
            _imageColor = _image.color;
            _startColor = Color.clear;
        }

        private Image _image;
        void OnEnable()
        {
            _image.color = _startColor;
            _animate = true;
        }

        private void OnDisable()
        {
            _image.color = _startColor;
            _time = 0;
        }

        private bool _animate;
        private float _time;
        void LateUpdate()
        {
            if (_animate)
            {
                _time += Time.unscaledDeltaTime;
                _image.color = Color.Lerp(_startColor, _imageColor, _time / SA.Settings.otherSettings.imageFadeInTime);
                if (_time > SA.Settings.otherSettings.imageFadeInTime)
                {
                    _animate = false;
                }
            }
        }
    }
}
