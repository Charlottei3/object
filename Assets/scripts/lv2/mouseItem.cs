using DG.Tweening;
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

namespace Assets.scripts { 
    public class mouseItem : MonoBehaviour
    {
        public GameObject movePositon;
        public Vector3 dropPosition;

        Vector3 oldPosition;

        // Start is called before the first frame update
        private void Start()
        {
            EventTrigger trigger = GetComponent<EventTrigger>();

            EventTrigger.Entry entry = new EventTrigger.Entry();
            entry.eventID = EventTriggerType.Drag;
            entry.callback.AddListener((data) => { OnDragDelegate((PointerEventData)data); });
            trigger.triggers.Add(entry);


            EventTrigger.Entry entry1 = new EventTrigger.Entry();
            entry1.eventID = EventTriggerType.Drop;
            entry1.callback.AddListener((data) => { OnDropDelegate((PointerEventData)data); });
            trigger.triggers.Add(entry1);


            transform.DOMove(movePositon.transform.position, 1f).OnComplete(() =>
            {
                oldPosition = transform.position;
            });

        }

        private void OnDropDelegate(PointerEventData data)
        {
            if (Vector2.Distance(dropPosition, transform.position) < 2)
            {
                Debug.Log(dropPosition);
                transform.DOMove(dropPosition, 1);

                GetComponent<Image>().raycastTarget = false;

                lv2GameController.Instance.AddCount();

            }
            else
            {
                transform.DOMove(oldPosition, 1);
            }
        }

        public void OnDragDelegate(PointerEventData data)
        {
            Ray ray = Camera.main.ScreenPointToRay(data.position);
            //Calculate the distance between the Camera and the GameObject, and go this distance along the ray
            Vector3 rayPoint = ray.GetPoint(Vector3.Distance(transform.position, Camera.main.transform.position));
            //Move the GameObject when you drag it
            transform.position = rayPoint;
        }
    }
}
