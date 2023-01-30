using SCN.ActionLib;
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class testManager : MonoBehaviour
{
    // Start is called before the first frame update
    public static Action<Transform> ItemPointerUp;
    [SerializeField] private RectTransform _target;
    [SerializeField] private Canvas _canvas;
    
    private void OnEnable()
    {
        ItemPointerUp += ItemPointerUp_Callback;
    }
    private void OnDisable()
    {
        ItemPointerUp -= ItemPointerUp_Callback;
    }
    private void ItemPointerUp_Callback(Transform obj)
    {
        var tg = new RectDetection(_target, _canvas.transform.localScale.x);
        /*if (tg.CheckIn(obj))
        {

        }*/
    }


}
