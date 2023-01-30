using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using SCN.Common;

public class ItemTest : MonoBehaviour
{
    [SerializeField] private EventTrigger _eventrigger;

    private void Start()
    {
        Master.AddEventTriggerListener(_eventrigger, EventTriggerType.PointerUp, OnPointerUp123);

    }

    void OnPointerUp123(BaseEventData data)
    {
        Debug.Log("item");
    }
}
