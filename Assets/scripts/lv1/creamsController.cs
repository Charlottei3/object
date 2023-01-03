using Assets.scripts;
using DG.Tweening;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class creamsController : MonoBehaviour
{
    private static creamsController _instance;
    public static creamsController Instance { get { return _instance; } }

    [SerializeField] List<Step> steps;

    private void Awake()
    {
        _instance= this;
    }

    int index;

    public int Count;

    List<IceCreamColor> tempIceCreams = new List<IceCreamColor>();
    List<IceCreamColor> choosenIceCreams = new List<IceCreamColor>();

    void Start()
    {
        Step step = steps[index];


        for (int i = 1; i < GameplayResources.Instance.IceCreamColor.Count; i++)
        {
            tempIceCreams.Add(GameplayResources.Instance.IceCreamColor[i]);
        }
         for (int i = 3; i < 6; i++)//body
         {
            int random = Random.Range(0, tempIceCreams.Count);
             IceCreamColor iceCream = tempIceCreams[random];

             iceCream.dropPosition = step.objects[i + 3].transform.position;//net position
             choosenIceCreams.Add(iceCream);

             step.objects[i].GetComponent<Image>().sprite = iceCream.Body;

             tempIceCreams.RemoveAt(random);

            Debug.Log("REMOVE: " + iceCream.Body.name);
            string lists = "";
            for (int x = 0; x < tempIceCreams.Count; x++)
            {
                lists += tempIceCreams[x].Body.name + ", ";
            }
            Debug.Log("CON LAI: " + lists);

        }

        if (index == 0)
        {

            List<IceCreamColor> IceCreamColorData = new List<IceCreamColor>();

            for (int i = 0; i < choosenIceCreams.Count; i++)
            {
                IceCreamColorData.Add(choosenIceCreams[i]);
            }

            for (int i = 0; i < 3; i++)//ice1
            {
                Image img = step.objects[i].GetComponent<Image>();
                int random = Random.Range(0, IceCreamColorData.Count - 1);
                IceCreamColor iceCreamColor = IceCreamColorData[random];
                img.sprite = iceCreamColor.Top1;

                img.GetComponent<Item>().dropPosition = iceCreamColor.dropPosition;

                IceCreamColorData.Remove(iceCreamColor);
               
            }
        }
      
    }

    public void AddCount()
    {
        Count++;
        if (Count == 3)
        {
            nextStep();
            Count = 0;
        }
    }
    public void nextStep()
    {
        index++;

       
        if (index == 1)
        {
            Step step = steps[index];
            List<IceCreamColor> IceCreamColorData = new List<IceCreamColor>();
            for (int i = 0; i < choosenIceCreams.Count; i++)
            {
                IceCreamColor iceCreamColor = choosenIceCreams[i];

                iceCreamColor.dropPosition = steps[index].objects[i + 3].transform.position;//ice2 position
                IceCreamColorData.Add(iceCreamColor);
                
                Debug.Log("UPDATE POSITION: " + iceCreamColor.dropPosition);
            }
          

            for (int i = 0; i < 3; i++)
            {
                step.objects[i].SetActive(true);
                Image img2 = step.objects[i].GetComponent<Image>();
                int random = Random.Range(0, IceCreamColorData.Count - 1);
                IceCreamColor iceCreamColor = IceCreamColorData[random];

                img2.sprite = iceCreamColor.Top2;
               
                img2.GetComponent<Item>().dropPosition = iceCreamColor.dropPosition;
                Debug.Log("UPDATE POSITION 2: " + iceCreamColor.dropPosition);

                IceCreamColorData.Remove(iceCreamColor);

               
            }

        }

        if (index == 2)
        {
            Step step = steps[index];
            List<IceCreamColor> IceCreamColorData = new List<IceCreamColor>();
            for (int i = 0; i < choosenIceCreams.Count; i++)
            {
                IceCreamColor iceCreamColor = choosenIceCreams[i];

                iceCreamColor.dropPosition = steps[index].objects[i + 3].transform.position;//position

                //step.objects[i].transform.DOScale(Vector3.zero, 1);

                IceCreamColorData.Add(iceCreamColor);
             
            }

            for (int i = 0; i < 3; i++)
            {
                step.objects[i].SetActive(true);
                Image img3 = step.objects[i].GetComponent<Image>();
                int random = Random.Range(0, IceCreamColorData.Count - 1);
                IceCreamColor iceCreamColor = IceCreamColorData[random];
                img3.sprite = iceCreamColor.Topping;
                
                img3.GetComponent<Item>().dropPosition = iceCreamColor.dropPosition;
               
                IceCreamColorData.Remove(iceCreamColor);

            }

          
        }
    }
}
