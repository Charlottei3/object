using DG.Tweening;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

namespace Assets.scripts
{
    public class Item : MonoBehaviour
    {

        public GameObject movePositon;
        public Vector3 dropPosition;
        Vector3 oldPosition;

        private void Start()
        {


            EventTrigger trigger = GetComponent<EventTrigger>();
            //Create a new entry for the Event Trigger
            EventTrigger.Entry entry = new EventTrigger.Entry();
            //Add a Drag type event to the Event Trigger
            entry.eventID = EventTriggerType.Drag;
            //call the OnDragDelegate function when the Event System detects dragging
            entry.callback.AddListener((data) => { OnDragDelegate((PointerEventData)data); });
            //Add the trigger entry
            trigger.triggers.Add(entry);


            //Create a new entry for the Event Trigger
            EventTrigger.Entry entry1 = new EventTrigger.Entry();
            //Add a Drag type event to the Event Trigger
            entry1.eventID = EventTriggerType.PointerUp;
            //call the OnDragDelegate function when the Event System detects dragging
            entry1.callback.AddListener((data) => { OnDropDelegate((PointerEventData)data); });
            //Add the trigger entry
            trigger.triggers.Add(entry1);

            transform.DOMove(movePositon.transform.position, .7f).OnComplete(() =>
            {
                oldPosition = transform.position;
            });
        }

        private void OnDropDelegate(PointerEventData data)
        {

            if (Vector2.Distance(dropPosition, transform.position) < 3)
            {
                Debug.Log(dropPosition);
               
                transform.DOScale(Vector3.zero, .1f).OnComplete(() =>
                {
                    transform.DOMove(dropPosition, .01f);
                    transform.DOScale(Vector3.one, .2f);
                });
                
                GetComponent<Image>().raycastTarget = false;
                creamsController.Instance.AddCount();

                SCN.Tutorial.TutorialManager.Instance.Stop();
            }
            else
            {
                transform.DOMove(oldPosition, .5f);
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