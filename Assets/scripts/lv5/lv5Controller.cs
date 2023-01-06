using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class lv5Controller : MonoBehaviour
{
    private static lv5Controller _instance;
    public static lv5Controller Instance { get { return _instance; } }

    [SerializeField] List<Step> _steps;

    [SerializeField] List<GameObject> posItem;//pos
    [SerializeField] GameObject[] rabalon;//gamobj

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
        Debug.Log(Count);
        if (Count == 2)
        {
            nextStep();
            Count = 0;
           
        }
       

    }
    public void nextStep()
    {
        int ranI = Random.Range(0, _steps.Count - 1);
        index++;
        if (index == 4)
            return;
        Step step = _steps[ranI];
        Debug.Log("random steo: "+ ranI);
        
        for (int j = 0; j <step.objects.Length; j++)
        {
            step.objects[j].SetActive(true);

        }
        _steps.RemoveAt(ranI);

        Debug.Log(" index: "+index);

    }
 

    public void ranIcon()
    {

        List<GameObject> tempIm = new List<GameObject>();
        tempIm.AddRange(posItem);

        for (int i = 0; i < rabalon.Length; i++)
        {
            GameObject cd = rabalon[i];

            int _ranIm = Random.Range(0, tempIm.Count);
            GameObject ranPosIm = tempIm[_ranIm];
            cd.transform.position = ranPosIm.transform.position;
            tempIm.RemoveAt(_ranIm);

        }

    }

}