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

    public List<GameObject> duQuay;
    public List<GameObject> _randuQuay;


    // Start is called before the first frame update

    void Start()
    {

        for (int i = 0; i < duQuay.Count; i++)
        {
            int randq = Random.Range(0, duQuay.Count);
            
            GameObject a = _randuQuay[randq];

            duQuay.Remove(a);

            for (int J = 0; J < _randuQuay.Count; J++)
            {
                a.transform.position = _randuQuay[i].transform.position;
            }
          
        }

    }


}
