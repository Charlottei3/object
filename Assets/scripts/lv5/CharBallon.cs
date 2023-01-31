using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharBallon : MonoBehaviour
{
    private static CharBallon _instance;
    public static CharBallon Instance { get { return _instance; } }
    private void Awake()
    {
        _instance = this; 
    }
    [SerializeField] List<GameObject> ballon;
    [SerializeField] List<GameObject> _movPosBall;

    int index;
    int Count;
    void Start()
    {
        
    }
    public void InCount()
    {
        Count++;
        if (Count == 1)
        {
            SetBallon();
            Count= 0;
        }
    }
    public void SetBallon()
    {
        index++;
        ballon[index].SetActive(true);

    }
}
