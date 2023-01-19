using DG.Tweening;
using SCN.Animation;
using System.Collections;
using System.Collections.Generic;
using Unity.Mathematics;
using UnityEngine;

public class MenuEditor : MonoBehaviour
{
    [SerializeField] List<GameObject> scal_Gobj;
    [SerializeField] private GameObject[] obj;
   
    
  
    // Start is called before the first frame update
    void Start()
    {
        _ScalGamObj();

        var squence = DOTween.Sequence();

        foreach (var Obj in obj)
        {
           
        }
        
    }
    
    public void _ScalGamObj()
    {
        for (int i = 0; i < scal_Gobj.Count; i++)
        {
            scal_Gobj[i].transform.DOScaleX(1.1f, .5f).SetLoops(-1,LoopType.Yoyo).SetEase(Ease.Linear);
            scal_Gobj[i].transform.DOScaleY(1.3f, .5f).SetLoops(-1,LoopType.Yoyo).SetEase(Ease.Linear);
        }

    }

}
