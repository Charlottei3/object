using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using SCN.Common;
using SCN.ActionLib;
using DG.Tweening;
using UnityEngine.EventSystems;
using System;

public class lv5Move : MonoBehaviour
{
    [SerializeField] DragObject dragObjects;
    [SerializeField] private GameObject movePos;
    void Start()
    {
        dragObjects.Init();

        transform.DOMove(movePos.transform.position, 1f);

        Master.AddEventTriggerListener(gameObject.GetComponent<EventTrigger>(), EventTriggerType.PointerUp, OnDrop);
    }

    private void OnDrop(BaseEventData arg0)
    {
        transform.DOMove(movePos.transform.position, 1f);
    }
}
