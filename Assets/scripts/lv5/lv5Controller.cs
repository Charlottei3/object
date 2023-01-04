using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class lv5Controller : MonoBehaviour
{
    private static lv5Controller _instance;
    public static lv5Controller Instance { get { return _instance; } }

    [SerializeField] List<Step> _steps;

    int index;
    public int Count;
    private void Awake()
    {
        _instance= this;
    }
    void Start()
    {
        
    }

    public void AddCount()
    {
        Count++;
        if (Count == 2)
        {
            Count = 0;
        }
        
    }
    public void nextStep()
    {
        Step step = _steps[index];

        if (index == 1)
        {
            for (int i = 0; i < 2; i++)
            {
                step.objects[i].SetActive(true);
            }
        }
    }
  
}
