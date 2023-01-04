using DG.Tweening;
using SCN.ActionLib;
using SCN.Animation;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using SCN.Common;
using UnityEngine.EventSystems;
using System;

public class moveLv4 : MonoBehaviour
{
    AnimationSpineController spineControl;
    [SerializeField] AnimationSpineController.SpineAnim anim;
    [SerializeField] AnimationSpineController.SpineAnim animOnPle;
    [SerializeField] AnimationSpineController.SpineAnim animIdle;
    [SerializeField] UIBox box;

    [SerializeField] private DragObject character;

    public GameObject movePosition;
    Vector3 olPoisition;
    public Vector3 dropPosition;
    // Start is called before the first frame update
    void Start()
    {
        spineControl = GetComponent<AnimationSpineController>();
        spineControl.InitValue();

        
        character.Init();
        OnMove();   
        StartCoroutine(moveSpin());

        Master.AddEventTriggerListener(gameObject.GetComponent<EventTrigger>(), EventTriggerType.PointerUp, OnDrop);
    }

    private void OnDrop(BaseEventData arg0)
    {
        if (!box.isOpen)
        {
            transform.DOJump(movePosition.transform.position, 2f, 2, 1);
            return;
        }

        if (Vector2.Distance(box.transform.position, transform.position) < 2)
        {
            transform.DOJump(box.transform.position, 2f, 1, 0.5f).OnComplete(()=>
            {
                lv4Controller.Instance.AddCount();

            });
            transform.SetParent(lv4Controller.Instance.pos.transform);
        }
        else

        transform.DOJump(movePosition.transform.position, 2f,2,1);

    }

    public void OnMove()
    {
        transform.DOJump(movePosition.transform.position, 2f, 2, 1).OnComplete(() =>
        {
            olPoisition = transform.position;
        });
    }

    private IEnumerator moveSpin()
    {

        spineControl.PlayAnimation(anim, true);
        transform.DOMove(movePosition.transform.position, 1f).OnComplete(() =>
        {
            spineControl.PlayAnimation(animOnPle, true);
            olPoisition = transform.position;
        });

        yield return new WaitForSeconds(2);
        spineControl.PlayAnimation(animIdle, true);

    }

}
