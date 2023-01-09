using SCN.ActionLib;
using SCN.Animation;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using SCN.Common;
using UnityEngine.EventSystems;
using System;
using DG.Tweening;
using UnityEngine.UI;

public class moveCharacter : MonoBehaviour
{
    AnimationSpineController spineControl;
    [SerializeField] AnimationSpineController.SpineAnim anim;
    [SerializeField] AnimationSpineController.SpineAnim animOnPle;
    [SerializeField] AnimationSpineController.SpineAnim animIdle;

    [SerializeField] private DragObject character;
    [SerializeField] private GameObject movePos;
    [SerializeField] private GameObject movObj;
    void Start()
    {
        spineControl = GetComponent<AnimationSpineController>();
        spineControl.InitValue();

        StartCoroutine(moveSpin());

        character.Init();
        Master.AddEventTriggerListener(gameObject.GetComponent<EventTrigger>(), EventTriggerType.PointerUp, onDrop);
    }

    private void onDrop(BaseEventData arg0)
    {
        if (Vector2.Distance(movObj.transform.position, transform.position) < 3)
        {
            transform.DOMove(movObj.transform.position, 0.5f);
            
            lv5Controller.Instance.countLv6();

            transform.DOScale(Vector3.zero, 0.1f);
            movObj.transform.DOScale(Vector3.one, 0.2f);
           
        }
        else
        {
            transform.DOMove(movePos.transform.position, 0.5f);
        }
    }
    private IEnumerator moveSpin()
    {

        spineControl.PlayAnimation(anim, true);
        transform.DOMove(movePos.transform.position, 1f).OnComplete(() =>
        {
            spineControl.PlayAnimation(animOnPle, false);
        });

        yield return new WaitForSeconds(2f);
        spineControl.PlayAnimation(animIdle, true);

    }
}
