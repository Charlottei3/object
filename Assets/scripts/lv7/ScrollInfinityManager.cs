using SCN.ActionLib;
using SCN.UIExtend;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;

namespace CN.UIExtend
{
    public class ScrollInfinityManager : MonoBehaviour
    {
        [SerializeField] Canvas canvas;
        [SerializeField] HorizontalScrollInfinity horScrollInfinity;

        [SerializeField] RectTransform[] itemYl;
        [SerializeField] RectTransform[] itemRed;

        [SerializeField] List<Sprite> spriteRed;
        [SerializeField] List<Sprite> spriteYellow;
        public static ScrollInfinityManager _instance;
        public static ScrollInfinityManager Instance { get { return _instance; } }

        private void Awake()
        {
            _instance = this;
         

           
            ScrollHorizontalItem.OnPoiterUpAfterDrag = item => 
            {
                
            };
        }

        public void RandomSprite()
        {
           
        }
    }
}

