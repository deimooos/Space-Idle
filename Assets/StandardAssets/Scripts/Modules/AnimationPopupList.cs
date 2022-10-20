using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace StandardAssets
{
    public class AnimationPopupList : MonoBehaviour
    {
        [Tooltip("TRUE: animates only the list. FALSE: use for example for Win Panel (Call AnimationPopupList.RemoveLastBreakPoint())")]
        public bool onlyAnimationList = true;

        public Parent parentList = new Parent();
        public static List<AnimationPopupList> breakPoints = new List<AnimationPopupList>();

        private void OnEnable()
        {
            if (onlyAnimationList)
            {
                ActivateElementOld();
            }
            else
            {
                ActivateElement();
            }
        }

        private void OnDisable()
        {
            if (onlyAnimationList)
            {
                DisableAllChildrenOld();
                currentIndex = 0;
            }
            else
            {
                DisableAllChildren();
            }
        }

        private void DisableAllChildren()
        {
            for (int i = 0; i < parentList.childList.Count; i++)
            {
                foreach (var v in parentList.childList[i].child)
                {
                    if (parentList.childList[i].activated == false)
                    {
                        v.SetActive(false);
                    }
                }
            }
        }

        private void DisableAllChildrenOld()
        {
            for (int i = 0; i < parentList.childList.Count; i++)
            {
                foreach (var v in parentList.childList[i].child)
                {
                    v.SetActive(false);
                }
            }
        }

        private void ActivateElementOld()
        {
            if (parentList.childList.Count <= currentIndex)
            {
                return;
            }

            if (parentList.childList != null)
            {
                if (parentList.childList[currentIndex] != null)
                {
                    if (parentList.childList[currentIndex].child != null)
                    {
                        foreach (var c in parentList.childList[currentIndex].child)
                        {
                            if (c != null)
                            {
                                c.SetActive(true);
                            }
                            else
                            {
                                Debug.LogWarning("SA: AnimationPopupList - Null GameObject");
                            }
                        }
                    }
                }
            }

            currentIndex++;
            StartCoroutine(
            SA.Timer(0.125f, delegate
            {
                ActivateElement();
            }));
        }

        private int currentIndex = 0;
        private void ActivateElement()
        {
            if (parentList.childList.Count <= currentIndex)
            {
                return;
            }
            Debug.Log("cure" + currentIndex);

            bool isBreakPoint = false;
            if (parentList.childList != null)
            {
                if (parentList.childList[currentIndex] != null)
                {
                    if (parentList.childList[currentIndex].child != null)
                    {
                        isBreakPoint = parentList.childList[currentIndex].isBreakPoint;
                        //m
                        parentList.childList[currentIndex].activated = true;
                        foreach (var c in parentList.childList[currentIndex].child)
                        {
                            if (c != null)
                            {
                                c.SetActive(true);
                            }
                            else
                            {
                                Debug.LogWarning("SA: AnimationPopupList - Null GameObject");
                            }
                        }
                    }
                }
            }

            if (isBreakPoint)
            {
                AddBreakPoint();
                Debug.Log("ret");
                return;
            }
            else
            {
                currentIndex++;
                StartCoroutine(
                SA.Timer(0.125f, delegate
                {
                    ActivateElement();
                }));
            }
        }

        public void RemoveBreakPoint()
        {
            if (gameObject.activeInHierarchy)
            {
                ActivateElement();
            }
        }

        public void AddBreakPoint()
        {
            breakPoints.Add(this);
        }

        public static void RemoveLastBreakPoint()
        {
            if (breakPoints.Count > 0)
            {
                breakPoints[breakPoints.Count - 1].currentIndex++;
                breakPoints[breakPoints.Count - 1].RemoveBreakPoint();
                breakPoints.RemoveAt(breakPoints.Count - 1);
            }
        }

        [System.Serializable]
        public class ChildList
        {
            public List<GameObject> child = new List<GameObject>();
            [ConditionalHide(nameof(onlyAnimationList),true,true)]
            public bool isBreakPoint;
            [HideInInspector]
            public bool activated = false;
        }

        [System.Serializable]
        public class Parent
        {
            public List<ChildList> childList = new List<ChildList>();
        }
    }
}
