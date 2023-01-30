using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using SCN.Common;
using SCN.ActionLib;
using DG.Tweening;
using UnityEngine.EventSystems;
using System;
using UnityEngine.UI;

public class lv5Move : MonoBehaviour
{
    [SerializeField] DragObject dragObjects;
    [SerializeField] private GameObject movePos;
    [SerializeField] private GameObject movObj;

    void Start()
    {
        dragObjects.Init();

        transform.DOMove(movePos.transform.position, 1f);

        Master.AddEventTriggerListener(gameObject.GetComponent<EventTrigger>(), EventTriggerType.PointerUp, OnDrop);

        //movObj = CharBallon.Instance.
    }

    private void OnDrop(BaseEventData arg0)
    {
        if (Vector2.Distance(movObj.transform.position, transform.position) < 2)
        {
            transform.DOMove(movObj.transform.position, 0.5f);
            transform.DORotate(movObj.transform.eulerAngles, 1);
            GetComponent<Image>().raycastTarget = false;

            lv5Controller.Instance.AddCount();
            movObj.SetActive(false);

            CharBallon.Instance.SetBallon();
        }
        else
        {
            transform.DOMove(movePos.transform.position, 1f);
        }
    }
}
