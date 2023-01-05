using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class lv5Controller : MonoBehaviour
{
    private static lv5Controller _instance;
    public static lv5Controller Instance { get { return _instance; } }

    [SerializeField] List<Step> _steps;

    [SerializeField] List<GameObject> posItem;

    int index;
    int Count;

    private void Awake()
    {
        _instance= this;
    }
    void Start()
    {
        ranIcon();
    }

    public void AddCount()
    {
        Count++;
        if (Count == 2)
        {
            nextStep();
            Count = 0;
        }
        
    }
    public void nextStep()
    {
        index++;
        int ranI = Random.Range(0, _steps.Count - 1);
        _steps[index] = _steps[ranI];


        for (int j = 0; j < _steps[ranI].objects.Length; j++)
        {
            _steps[ranI].objects[j].SetActive(true);

        }
        _steps.RemoveAt(ranI);
        index= 0;

        Debug.Log(ranI + " " + Count);
        Debug.Log(_steps[ranI].objects[index].name);
        Debug.Log(_steps[index]);

    }

    public void ranIcon()
    {

        List<GameObject> tempIm = new List<GameObject>();
        tempIm.AddRange(posItem);
        Step step= _steps[index];

        for (int i = 2; i < step.objects.Length; i++)
        {
            int _ranIm = Random.Range(0, tempIm.Count);
            GameObject cd = step.objects[i];
            GameObject ranPosIm = tempIm[_ranIm];
            cd.transform.position = ranPosIm.transform.position;
            tempIm.RemoveAt(_ranIm);

        }

    }

}