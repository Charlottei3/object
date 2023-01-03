using Assets.scripts;
//using Assets.scripts.lv2;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class lv2GameController : MonoBehaviour

{

    private static lv2GameController _lv2instance;

    public static lv2GameController Instance { get { return _lv2instance; } }

    [SerializeField] List<Steplv2> steps;
    int index;

    public int Countlv2;

    List<nguaLv2> itemNgua = new List<nguaLv2>();
    List<nguaLv2> chooseItem = new List<nguaLv2>();

    private void Awake()
    {
        _lv2instance= this;
    }

    void Start()
    {
        Steplv2 step = steps[index];

        for (int i = 0; i < GameplayResources.Instance.gameLv2.Count; i++)
        {
            itemNgua.Add(GameplayResources.Instance.gameLv2[i]);
        }

        for (int i = 0; i < 3; i++)
        {
            int random = Random.Range(0, itemNgua.Count);
            nguaLv2 ranitem = itemNgua[random];


            ranitem.dropPosition = steps[index].objects[i].transform.position;
          
         
            chooseItem.Add(ranitem);

            step.objects[i].GetComponent<Image>().sprite = ranitem.Ngua;
            step.objects[i + 3].GetComponent<Image>().sprite = ranitem.cot;


            itemNgua.RemoveAt(random);
            

        }

        if (index == 0)
        {
            List<nguaLv2> nguaItemData = new List<nguaLv2>();
            for (int i = 0; i < chooseItem.Count; i++)
            {
                nguaItemData.Add(chooseItem[i]);
            }

            for (int i = 6; i < 9; i++)
            {
                Image image = step.objects[i].GetComponent<Image>();
                int ranItemData = Random.Range(0, nguaItemData.Count - 1);
                nguaLv2 itemData = nguaItemData[ranItemData];
                image.sprite = itemData.Ngua;

                image.GetComponent<mouseItem>().dropPosition = itemData.dropPosition;

                nguaItemData.Remove(itemData);

            }
        }


    }

    public void AddCount()
    {
        Countlv2++;
        Debug.Log(Countlv2);
        if(Countlv2 == 3)
        {
            continuedStep();
            Countlv2 = 0;
        }
    }
    public void continuedStep()
    {
        index++;

        if(index == 1)
        {

            Steplv2 step = steps[index];
            Debug.Log(index);
            List<nguaLv2> ngauItemData = new List<nguaLv2>();


            for (int i = 0; i < chooseItem.Count; i++)
            {
                nguaLv2 i_Ngua = chooseItem[i];
                i_Ngua.dropPosition = steps[index].objects[i + 3].transform.position;

                ngauItemData.Add(i_Ngua);

            }

            for (int i = 0; i < 3; i++)
            {
                step.objects[i].SetActive(true);
                Image imgDiamond = step.objects[i].GetComponent<Image>();
                int ranDia = Random.Range(0, ngauItemData.Count - 1);
                nguaLv2 i_dia = ngauItemData[ranDia];
                imgDiamond.sprite = i_dia.hinhNho;

                imgDiamond.GetComponent<mouseItem>().dropPosition = i_dia.dropPosition;

                ngauItemData.Remove(i_dia);
            }
        }

        if (index == 2)
        {
            
            Steplv2 step = steps[index];
            List<nguaLv2> ngauItemData = new List<nguaLv2>();

            for (int i = 0; i < chooseItem.Count; i++)
            {
                nguaLv2 i_woofol = chooseItem[i];
                i_woofol.dropPosition = steps[index].objects[i + 3].transform.position;


                ngauItemData.Add(i_woofol);

                Debug.Log(i_woofol.wolfoo.name);
            }

            for (int i = 0; i < 3; i++)
            {
                step.objects[i].SetActive(true);
                Image i_woolfol = step.objects[i].GetComponent<Image>();
                int ran_woofol = Random.Range(0, ngauItemData.Count - 1);
                nguaLv2 _wool = ngauItemData[ran_woofol];
                i_woolfol.sprite = _wool.wolfoo;

                i_woolfol.GetComponent<mouseItem>().dropPosition = _wool.dropPosition;
                Debug.Log(_wool.dropPosition);
                ngauItemData.Remove(_wool);
            }
        }

        if (index == 3)
        {
            Steplv2 step = steps[index];
            List<nguaLv2> bogItemData = new List<nguaLv2>();

            for (int i = 0; i < chooseItem.Count; i++)
            {
                nguaLv2 i_ballon = chooseItem[i];
                i_ballon.dropPosition = steps[index].objects[i + 3].transform.position;

                bogItemData.Add(i_ballon);
                Debug.Log(chooseItem[i].bong.name);
            }
           
            for (int i = 0; i < 3; i++)
            {
                step.objects[i].SetActive(true);
                step.objects[i + 6].SetActive(true);
                
                Image ballon = step.objects[i].GetComponent<Image>();
                int ran_ballon = Random.Range(0, bogItemData.Count - 1);
                nguaLv2 _ballon = bogItemData[ran_ballon];
                ballon.sprite = _ballon.bong;

                ballon.GetComponent<mouseItem>().dropPosition = _ballon.dropPosition;
                //step.objects[i + 3].SetActive(false);
                bogItemData.Remove(_ballon);
               
            }

        }

    }

   
}
