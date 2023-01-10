using SCN.Common;
using SCN.UIExtend;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;
using DG.Tweening;
using CN.UIExtend;

namespace SCN.UIExtend
{
    public class ScrollHorizontalItem : ScrollItemBase
    {
        public static System.Action<ScrollHorizontalItem> OnPoiterUpAfterDrag;


        public static System.Action<ScrollHorizontalItem> OnItemDrag;

        [SerializeField] Image image;

        bool isDrag;

        protected override void Setup(int order)
        {
           
            
            Master.AddEventTriggerListener(EventTrigger, EventTriggerType.PointerUp, onPoiterUp);
            Master.AddEventTriggerListener(EventTrigger, EventTriggerType.PointerDown, onPoiterDown);

            DOVirtual.DelayedCall(0.5f, () =>
            {
               /* var img = transform.GetChild(0);
                var listSp = ScrollInfinityManager.Instance.Sprite;
                var ranSp = listSp[Random.Range(0, listSp.Count)];
                img.GetComponent<Image>().sprite = ranSp;

                img.GetComponent<Image>().preserveAspect = true;
                img.GetComponent<Image>().SetNativeSize();*/
            });

        }

        protected override void OnStartDragOut()
        {
            image.transform.DOKill();
            DOTweenManager.Instance.TweenScaleTime(image.transform, Vector3.one * 1.5f, 0.3f)
                .SetEase(Ease.OutBack);

            isDrag = true;
        }

        protected override void OnDragOut()
        {
            //OnItemDragging?.Invoke(this);
        }

        void onPoiterDown(BaseEventData data)
        {
            image.transform.DOKill();
            DOTweenManager.Instance.TweenScaleTime(image.transform, Vector3.one * 1.2f, 0.3f)
                .SetEase(Ease.OutBack);
        }

        void onPoiterUp(BaseEventData data)
        {
            if (isDrag)
            {
                isDrag = false;
                //OnPointerUpAfterDrag?.Invoke(this);
            }

            image.transform.DOKill();
            image.transform.localScale = Vector3.one;
        }

        void OnPointerClick(BaseEventData data)
        {
            image.DOKill();
            DOTweenManager.Instance.TweenChangeAlphaImage(image, 1, 0.5f, 0.15f)
                .OnComplete(() =>
                {
                    DOTweenManager.Instance.TweenChangeAlphaImage(image, 1, 0.15f);
                });
        }
    }

}
 