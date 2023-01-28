using DG.Tweening;
using SCN.ActionLib;
using SCN.Common;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class ballon : MonoBehaviour
{
    [SerializeField] DragObject dragObjects;
   
    //[SerializeField] private GameObject movObj;

    

    public Vector3 dropPosition;
    Vector3 oldPosition;
    void Start()
    {
        dragObjects.Init();

        Master.AddEventTriggerListener(gameObject.GetComponent<EventTrigger>(), EventTriggerType.PointerUp, OnDrop);

        transform.DOMoveY(-5f, .7f).OnComplete(() =>
        {
            oldPosition = transform.position;
        });
    }
    private void OnDrop(BaseEventData arg0)
    {
        if (Vector2.Distance(charControl.Instance.bongPos.transform.position, transform.position) < 2)
        {
            //GetComponent<Image>().raycastTarget = false;
            transform.DOMove(charControl.Instance.bongPos.transform.position, .001f);
            transform.DORotate(charControl.Instance.bongPos.transform.eulerAngles, .3f);
            
            transform.DOScale(new Vector3(.6f, .6f, .6f), .5f);
            charControl.Instance.bongPos.SetActive(false);
        }
        else
        {
            transform.DOMove(oldPosition, .5f);
        }
    }
}
