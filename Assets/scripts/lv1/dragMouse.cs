using DG.Tweening;
using System.Collections;
using System.Collections.Generic;
using System.Security.Cryptography;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class dragMouse : MonoBehaviour
{
    public GameObject ice;
    public GameObject top;


    bool t1 = false;
    Vector3 oldPosition;
    private void Start()
    {
      
        //oldPosition = transform.position;

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


    }

    private void OnDropDelegate(PointerEventData data)
    {

        var vtvatkeo = ice.transform.position;
        var top2 = top.transform.position;

        //Debug.Log(Vector2.Distance(vtvatkeo, transform.position));

        if (Vector2.Distance(vtvatkeo, transform.position) < 3)
        {
            transform.DOMove(vtvatkeo, 1);
            GetComponent<Image>().raycastTarget = false;
            ice.SetActive(false);

            //top.SetActive(true);
            return ;

        }
      
        ice_top();

    }
    void ice_top()
    {
        var top2 = top.transform.position;
        if (Vector2.Distance(top2, transform.position) < 2)
        {
            transform.DOMove(top2, 1);
            GetComponent<Image>().raycastTarget = false;
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
