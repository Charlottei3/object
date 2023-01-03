using DG.Tweening;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class lv4Controller : MonoBehaviour
{
    private static lv4Controller _instance;
    public static lv4Controller Instance { get { return _instance; } }

    public GameObject _moveTrain;
    public GameObject trainAll;

    public getIDCricle type;
   
    public int Count;
   

    [SerializeField] GameObject[] chodevao;
    [SerializeField] GameObject[] wf;

   
    

    [SerializeField] List<Image> _imgTrains = new List<Image>();
  
    [SerializeField] GameObject objImg;

    private void Awake()
    {
        _instance= this;
    }
    void Start()
    {
        ranItem();
    }
 
    public void AddCount()
    {
        Count++;
        if (Count == 3)
        {
            trainAll.transform.DOMove(_moveTrain.transform.position, 1);

            for (int i = 0; i < chodevao.Length; i++)
            {
                if (i >= 3)
                {
                    chodevao[i].GetComponent<UIBox>().isOpen = true;
                }
                else
                {
                    chodevao[i].GetComponent<UIBox>().isOpen = false;
                }
                for (int j = 0; j <3; j++)
                {
                    wf[j].transform.SetParent(chodevao[i].transform);
                }

            }
        }

        if (Count == 6)
        {
            objImg.SetActive(true);
        }
    }
   public void ranItem()
    {
        _imgTrains[5].sprite = _imgTrains[6].sprite;
    }
    public void _replace()
    {
        for (int i = 0; i < _imgTrains.Count-1; i++)
        {
            _imgTrains[5].type = _imgTrains[i].type;
        }
    }
}
