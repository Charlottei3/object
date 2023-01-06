using DG.Tweening;
using System.Collections;
using System.Collections.Generic;
using System.Security.Cryptography;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;

public class lv4Controller : MonoBehaviour
{
    private static lv4Controller _instance;
    public static lv4Controller Instance { get { return _instance; } }

    public GameObject _moveTrain;
   
    public int Count;
   

    [SerializeField] GameObject[] chodevao;
    [SerializeField] public GameObject pos;
    [SerializeField] GameObject[] wf;

    [SerializeField] List<GameObject> ranxTrain = new List<GameObject>();
    

    [SerializeField] List<Image> _imgTrains = new List<Image>();

    [SerializeField] List<GameObject> icon = new List<GameObject>();//position
    [SerializeField] GameObject[] _ranIcon;//gamObj

    [SerializeField] GameObject objImg;

    private void Awake()
    {
        _instance= this;
    }
    void Start()
    {
        ranItem();
        ranTrain();
        ranIcon();
    }
 
    public void AddCount()
    {
        Count++;
        if (Count == 3)
        {
            pos .transform.DOMove(_moveTrain.transform.position, 1);

            for (int i = 0; i < chodevao.Length; i++)
            {
                UIBox b = chodevao[i].GetComponent<UIBox>();
                b.isOpen = !b.isOpen;

            }
        }

        if (Count == 6)
        {
            objImg.SetActive(true);
        }
    }
   public void ranItem()
    {
        _imgTrains[1].sprite = _imgTrains[2].sprite;
    }
    public void _replace()
    {
        _imgTrains[1].sprite = _imgTrains[0].sprite;
    }

    public void ranTrain()
    {

        List<GameObject> tempData = new List<GameObject>();
        tempData.AddRange(ranxTrain);

        for (int i = 0; i < chodevao.Length; i++)
        {
            int _ranIt = Random.Range(0, tempData.Count- 1);
            GameObject cd = chodevao[i];
            GameObject ranPos = tempData[_ranIt];
            cd.transform.position= ranPos.transform.position;
            tempData.RemoveAt(_ranIt);
            if(ranxTrain.IndexOf(ranPos) < 3)
            {
                cd.GetComponent<UIBox>().isOpen = true;
            }
            else
            {
                cd.GetComponent<UIBox>().isOpen = false;
            }

        }

    }

    public void ranIcon()
    {

        List<GameObject> tempIm = new List<GameObject>();
        tempIm.AddRange(icon);

        for (int i = 0; i < _ranIcon.Length; i++)
        {
            int _ranIm = Random.Range(0, tempIm.Count);
            GameObject cd = _ranIcon[i];
            GameObject ranPosIm = tempIm[_ranIm];
            cd.transform.position = ranPosIm.transform.position;
            tempIm.RemoveAt(_ranIm);
          

        }

    }
}
