using DG.Tweening;
using SCN.ActionLib;
using SCN.Animation;
using SCN.Common;
using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class lv6move : MonoBehaviour
{

    [SerializeField] DragObject dragObjects;
    [SerializeField] private GameObject movePos;
    [SerializeField] private GameObject movObj;

    void Start()
    {

        dragObjects.Init();

        transform.DOMove(movePos.transform.position, 1f);

        Master.AddEventTriggerListener(gameObject.GetComponent<EventTrigger>(), EventTriggerType.PointerUp, onDrop);
    }

    private void onDrop(BaseEventData arg0)
    {
        if (Vector2.Distance(movObj.transform.position, transform.position) < 3)
        {
            transform.DOMove(movObj.transform.position, 0.3f);
            transform.DOScale(Vector3.zero, 0.3f);
            GetComponent<Image>().raycastTarget = false;

            lv5Controller.Instance.countLv6();
            movObj.SetActive(true);
        }
        else
        {
            transform.DOMove(movePos.transform.position, 1f);
        }
    }
}
