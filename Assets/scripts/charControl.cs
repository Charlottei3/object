using DG.Tweening;
using SCN.ActionLib;
using SCN.Animation;
using SCN.Common;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.EventSystems;

public class charControl : MonoBehaviour
{
    AnimationSpineController spineControl;
    [SerializeField] AnimationSpineController.SpineAnim anim;
    [SerializeField] AnimationSpineController.SpineAnim animOnPle;
    [SerializeField] AnimationSpineController.SpineAnim animIdle;

    [SerializeField] private DragObject character;
    [SerializeField] private GameObject movePos;
    [SerializeField] private GameObject movObj;
 

    public Vector3 dropPosition;
    Vector3 oldPosition;
    void Start()
    {
        spineControl = GetComponent<AnimationSpineController>();
        spineControl.InitValue();
      

        character.Init();
        Master.AddEventTriggerListener(gameObject.GetComponent<EventTrigger>(), EventTriggerType.PointerUp, onDrop);

        transform.DOMove(movePos.transform.position, .7f).OnComplete(() =>
        {
            oldPosition = transform.position;
        });
    }

    private void onDrop(BaseEventData arg0)
    {
        if (Vector2.Distance(movObj.transform.position, transform.position) < 3)
        {
            transform.DOMove(movObj.transform.position, 0.5f);

            lv2GameController.Instance.AddCount();
          
        }
        else
        {
            transform.DOMove(oldPosition, 0.5f);
        }
    }
}
