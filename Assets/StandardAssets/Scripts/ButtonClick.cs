using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.Events;

namespace StandardAssets
{
    [DisallowMultipleComponent]
    /// <summary>
    /// Jeder Button benötigt diesen Script, damit er als "Button" funktioniert
    /// </summary>
    public class ButtonClick : MonoBehaviour, IPointerDownHandler, IPointerUpHandler, IPointerClickHandler
    {
        [Tooltip("After one time click, it will not be usable again")]
        public bool singleClick;

        [Tooltip("Function will call with hold instead of click")]
        public bool callOnHold;
        public UnityEvent onClick;

        public void OnPointerClick(PointerEventData eventData)
        {
            if (callOnHold == true)
            {
                return;
            }
            CallFunction();
        }

        public void OnPointerDown(PointerEventData eventData)
        {
            if (!firstDown)
            {
                currentScale = transform.localScale;
                firstDown = true;
            }
            startAnimate = true;
            animateUp = false;

            if (callOnHold == false)
            {
                return;
            }
            CallFunction();
        }

        public void OnPointerUp(PointerEventData eventData)
        {
            animateUp = true;
        }

        private bool _clickedOnce;
        /// <summary>
        /// Ruft die Methode auf, die dem Button zugewiesen wurde
        /// </summary>
        private void CallFunction()
        {
            if (singleClick)
            {
                if (!_clickedOnce)
                {
                    _clickedOnce = true;
                    onClick.Invoke();
                    SA.PlayHaptic(SA.HapticTypes.LightImpact);
                }
            }
            else
            {
                onClick.Invoke();
                SA.PlayHaptic(SA.HapticTypes.LightImpact);
            }
        }



        /////////////////////////////////////// Replace with animation later
        
        private void LateUpdate()
        {
            if (!startAnimate)
            {
                return;
            }
            if (!animateUp)
            {
                tr.localScale = Vector3.MoveTowards(tr.localScale, currentScale * 0.875f, Time.unscaledDeltaTime * 3);
            }
            else
            {
                tr.localScale = Vector3.MoveTowards(tr.localScale, currentScale, Time.unscaledDeltaTime * 3);
                if (tr.localScale == currentScale)
                {
                    animateUp = false;
                    startAnimate = false;
                }
            }
        }

        private bool startAnimate;
        private bool animateUp;
        private Transform tr;
        private Vector3 currentScale;
        private void Start()
        {
            tr = transform;
        }
        private bool firstDown;
        private void OnEnable()
        {
            firstDown = false;
        }
    }
}

