using SCN.ActionLib;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using SCN.Common;
using UnityEngine.EventSystems;

using DG.Tweening;
using UnityEngine.UI;
using Unity.VisualScripting;
using CN.UIExtend;
public class DragItemNoel : MonoBehaviour
{
    private static DragItemNoel _instance;
    public static DragItemNoel Instance { get { return _instance; } }
    private void Awake()
    {
        _instance= this;
    }

    [SerializeField] private DragObject item_noel;
    [SerializeField] private GameObject movePos;
    [SerializeField] public GameObject movObj;
    [SerializeField] public int index;
    public float speed;

    private void Start()
    {
        item_noel.Init();

        //transform.DOMove(movePos.transform.position, 5f);
        Master.AddEventTriggerListener(gameObject.GetComponent<EventTrigger>(), EventTriggerType.PointerUp, onDrop);
        Master.AddEventTriggerListener(gameObject.GetComponent<EventTrigger>(), EventTriggerType.Drag, onDrag);

        StartCoroutine(nameof(Move));

             
    }

 

    private void onDrop(BaseEventData arg0)
    {
        if (Vector2.Distance(movObj.transform.position, transform.position) < 5)
        {
            transform.DOMove(movObj.transform.position, 0.3f);

            transform.DORotate(movObj.transform.eulerAngles, 1);
            GetComponent<Image>().raycastTarget = false;
            transform.DOScale(new Vector3(0.7f,0.7f,0), 0.5f);
            movObj.SetActive(false);

            ScrollInfinityManager.Instance.xoaItem(index);
        }
        else
        {
           
            
            transform.DOJump(movePos.transform.position, 2f, 1, 0.4f).OnComplete(() =>
            {
                Destroy(gameObject);
            });
           
        }
    }

    private void onDrag(BaseEventData arg0)
    {
        StopAllCoroutines();
    }

    IEnumerator Move()
    {
        while(true) 
        {
            if(transform.position == movePos.transform.position)
            {
                StopAllCoroutines();
            }
            transform.position = Vector2.MoveTowards(transform.position, movePos.transform.position, speed * Time.deltaTime);

               
            yield return null;

            if (Vector2.Distance(movePos.transform.position, transform.position) < .001f)
            {
                Destroy(gameObject);
                //transform.DOMove(ScrollInfinityManager.Instance.obj_ins.transform.position, 0f);
            }
        }
    }

 
}
