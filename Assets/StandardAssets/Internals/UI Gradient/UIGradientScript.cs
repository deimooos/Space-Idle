using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System;

namespace StandardAssets
{
    public class UIGradientScript : MonoBehaviour
    {
        public static Dictionary<string, Sprite> gradientTextures = new Dictionary<string, Sprite>();

        private Image img;
        private Texture2D backgroundTexture = null;
        public Gradient gradient;

        public string uniqueID = null;
        [HideInInspector]
        public bool setGradient;

        public void Refresh()
        {
            Reset();
            Init();
        }

        public void Reset()
        {
            if (uniqueID != null && uniqueID.Length > 0)
            {
                if (gradientTextures[uniqueID])
                {
                    gradientTextures.Remove(uniqueID);
                    uniqueID = null;
                }
            }
        }

        private void Init()
        {
            if (uniqueID == null || uniqueID.Length <= 0)
            {
                uniqueID = GenerateRandom.GenerateRandomKey();
            }

            img = GetComponent<Image>();
            if(img == null)
            {
                Debug.LogError("SA: UIGradientScript: No image found");
                return;
            }

            foreach (var g in gradientTextures)
            {
                if (g.Key == uniqueID)
                {
                    img.sprite = g.Value;
                    return;
                }
            }

            SetColor();
            AddSpriteToDict();

            void AddSpriteToDict()
            {
                gradientTextures.Add(uniqueID, sprite);
            }
        }

        private int quality = 100;
        private Sprite sprite;
        private void SetColor()
        {
            Color[] d = new Color[quality];
            backgroundTexture = new Texture2D(1, quality);

            backgroundTexture.wrapMode = TextureWrapMode.Clamp;
            backgroundTexture.filterMode = FilterMode.Trilinear;
            for (int i = 0; i < quality; i++)
            {
                float pos = Mathf.Clamp((i * 1f) / quality, 0f, 1f);
                try
                {
                    d[i] = gradient.Evaluate(pos);
                }
                catch { }
            }

            backgroundTexture.SetPixels(d);
            backgroundTexture.Apply();
            
            sprite = Sprite.Create(backgroundTexture, new Rect(0.0f, 0.0f, backgroundTexture.width, backgroundTexture.height), new Vector2(0.5f, 0.5f), 100.0f);
            img.sprite = sprite;
        }

        public class GenerateRandom
        {
            private const string glyphs = "abcdefghijklmnopqrstuvwxyz0123456789";
            private const int keyLength = 24;

            private static char[] c
            {
                get
                {
                    char[] charArr = glyphs.ToCharArray();
                    return charArr;
                }
            }

            public static string GenerateRandomKey()
            {
                string key = null;

                for (int i = 0; i < keyLength; i++)
                {
                    key += c[UnityEngine.Random.Range(0, c.Length)];
                }
                key += DateTime.UtcNow.ToString("yyyy-MM-dd-HH-mm-ss");
                return key;
            }
        }
    }
}

