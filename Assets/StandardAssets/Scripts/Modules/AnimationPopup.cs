using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace StandardAssets
{
    public class AnimationPopup : MonoBehaviour
    {
        private Transform tr;
        private void Awake()
        {
            tr = transform;
            currentScale = transform.localScale;
        }

        private void OnEnable()
        {
            startAnimation = true;
            animationUp = true;
            ResetScale();
        }

        private void ResetScale()
        {
            tr.localScale = Vector3.zero;
        }

        private Vector3 currentScale;

        private bool startAnimation;
        private bool animationUp;
        private void LateUpdate()
        {
            PopupAnimation();
            //PopupUpAnimation();
        }


        private void PopupAnimation()
        {
            if (startAnimation)
            {
                if (animationUp)
                {
                    tr.localScale = Vector3.Lerp(tr.localScale, 1.1f * currentScale, Time.unscaledDeltaTime * 7.5f);
                    tr.localScale = Vector3.MoveTowards(tr.localScale, 1.1f * currentScale, Time.unscaledDeltaTime * 7.5f);

                    if (tr.localScale == 1.1f * currentScale)
                    {
                        animationUp = false;
                    }
                }
                else
                {
                    tr.localScale = Vector3.Lerp(tr.localScale, currentScale, Time.unscaledDeltaTime * 7.5f);
                    tr.localScale = Vector3.MoveTowards(tr.localScale, currentScale, Time.unscaledDeltaTime * 7.5f);

                    if (tr.localScale == currentScale)
                    {
                        animationUp = true;
                        startAnimation = false;
                    }
                }
            }
        }

        private void PopupUpAnimation()
        {
            if (startAnimation)
            {
                if (animationUp)
                {
                    tr.localScale = Vector3.Lerp(tr.localScale, currentScale, Time.unscaledDeltaTime * 7.5f);
                    tr.localScale = Vector3.MoveTowards(tr.localScale, currentScale, Time.unscaledDeltaTime * 7.5f);

                    if (tr.localScale == currentScale)
                    {
                        animationUp = true;
                        startAnimation = false;
                    }
                }
            }
        }
    }
}
