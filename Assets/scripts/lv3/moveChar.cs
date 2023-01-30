using DG.Tweening;
using SCN.Animation;
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UIElements;
using SCN.Common;
using SCN.ActionLib;

public class moveChar : DragObject
{
        AnimationSpineController spineControl;
        [SerializeField] AnimationSpineController.SpineAnim anim;
        [SerializeField] AnimationSpineController.SpineAnim animOnPle;
        [SerializeField] AnimationSpineController.SpineAnim animIdle;
        [SerializeField] UIBox box;

         [SerializeField] private GameObject _charScale;
        public TypeBox type;

        public float move;

        Vector3 olPoisition;
        public Vector3 dropPosition;
        public GameObject movePosition;
        // Start is called before the first frame update
      
        void Start()
        {
            Init();

            spineControl = GetComponent<AnimationSpineController>();
            spineControl.InitValue();
            //_charScale.transform.DOScale(Vector3.zero, 0);
            transform.DOMove(movePosition.transform.position, move).OnComplete(() =>
            {

                olPoisition = transform.position;
            });

            Master.AddEventTriggerListener(gameObject.GetComponent<EventTrigger>(), EventTriggerType.PointerUp, OnDrop );
            StartCoroutine(moveSpin());
        }

        void OnDrop(BaseEventData data)
        {
        Debug.Log(transform.name);
       Debug.Log(type);

        if (Vector2.Distance(box.transform.position, transform.position) < 2)
        {
            Debug.Log(transform.gameObject);
            /* if (type == TypeBox.red || type == TypeBox.pink || type == TypeBox.blue)
             {
                 transform.DOMove(box.gameObject[0].transform.position, 0.5f);
             }
             else
             {
                 transform.DOMove(box.gameObject[1].transform.position, 0.5f);
             }*/
            transform.DOMove(box.transform.position, .1f);
            transform.DOScale(Vector3.zero, .2f).OnComplete(() =>
           {
               _charScale.transform.DOScale(Vector3.one, .15f);
               StartCoroutine(SpineAnimv4.Instance.ScaleOn());
           });
        }
        else
        {
            transform.DOMove(movePosition.transform.position, 1);
        }

    }
        IEnumerator moveSpin()
        {
            spineControl.PlayAnimation(anim, true);
            transform.DOMove(movePosition.transform.position, move).OnComplete(() =>
            {
                spineControl.PlayAnimation(animOnPle, true);
                olPoisition = transform.position;
            });
            yield return new WaitForSeconds(2 * move);
            spineControl.PlayAnimation(animIdle, true);
        
        }
}
