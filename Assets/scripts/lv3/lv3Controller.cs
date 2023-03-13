using DG.Tweening;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting.Antlr3.Runtime.Misc;
using Unity.VisualScripting.FullSerializer;
using UnityEngine;
using UnityEngine.UI;

public class lv3Controller : MonoBehaviour
{
    private static lv3Controller _instance;
    public static lv3Controller Instance { get { return _instance; } }

    private void Awake()
    {
        _instance= this;
    }
    public List<GameObject> duQuay;//gameObj
    public List<GameObject> _randuQuay;//position

    [SerializeField] GameObject Duquay;
    public int index;

    public void Count()
    {
        index++;
        if(index == 6)
            Duquay.transform.DORotate(new Vector3(0, 0, 360), 5, RotateMode.FastBeyond360).SetLoops(-1, LoopType.Restart).SetEase(Ease.Linear);
    }
    void Start()
    {
        List<GameObject> tempIm = new List<GameObject>();
        tempIm.AddRange(_randuQuay);
        for (int i = 0; i < duQuay.Count; i++)
        {
            int _ranDQ = Random.Range(0, tempIm.Count);
            GameObject cd = duQuay[i];
            GameObject ranPos = tempIm[_ranDQ];
            cd.transform.position = ranPos.transform.position;
            tempIm.RemoveAt(_ranDQ);
        }
    }
}
