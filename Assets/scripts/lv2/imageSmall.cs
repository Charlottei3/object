using DG.Tweening;
using SCN.ActionLib;
using SCN.Common;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class imageSmall : MonoBehaviour
{
    [SerializeField] DragObject dragObjects;
    [SerializeField] private GameObject movePos;

    public Vector3 dropPosition;
    Vector3 oldPosition;
    void Start()
    {
        dragObjects.Init();

        transform.DOMove(movePos.transform.position, 1f);

        Master.AddEventTriggerListener(gameObject.GetComponent<EventTrigger>(), EventTriggerType.PointerUp, OnDrop);

        transform.DOMove(movePos.transform.position, .7f).OnComplete(() =>
        {
            oldPosition = transform.position;
        });
    }

    private void OnDrop(BaseEventData arg0)
    {
        if (Vector2.Distance(dropPosition, transform.position) < 2)
        {

            GetComponent<Image>().raycastTarget = false;
            transform.DOMove(dropPosition, .001f);

            transform.DOScale(new Vector3(.4f,.4f,.4f),.3f);

            lv2GameController.Instance.AddCount();

        }
        else
        {
            transform.DOMove(oldPosition, 1f);
        }
    }
}
