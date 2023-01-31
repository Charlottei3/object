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
    private static charControl _instance;
    public static charControl Instance { get { return _instance; } }

    private void Awake()
    {
        _instance = this; 
    }

    AnimationSpineController spineControl;
    [SerializeField] AnimationSpineController.SpineAnim anim;
    [SerializeField] AnimationSpineController.SpineAnim animOnPle;
    [SerializeField] AnimationSpineController.SpineAnim animIdle;

    [SerializeField] private DragObject character;
    [SerializeField] private GameObject bong;
    [SerializeField] public GameObject bongPos;
 

    public Vector3 dropPosition;
    Vector3 oldPosition;
    void Start()
    {
        spineControl = GetComponent<AnimationSpineController>();
        spineControl.InitValue();

        character.Init();
        Master.AddEventTriggerListener(gameObject.GetComponent<EventTrigger>(), EventTriggerType.PointerUp, onDrop);

        transform.DOMoveY(-6f, .7f).OnComplete(() =>
        {
            oldPosition = transform.position;
        });
    }

    private void onDrop(BaseEventData arg0)
    {
        if (Vector2.Distance(dropPosition, transform.position) < 3)
        {
            transform.DOMove(dropPosition, .5f).OnComplete(() =>
            {
                bong.SetActive(true);
            });

            Debug.Log(dropPosition);
            lv2GameController.Instance.AddCount();
        }
        else
        {
            transform.DOMove(oldPosition, .2f);
        }
    }
}
