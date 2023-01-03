using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;

public class IconSquare : MonoBehaviour
{
    public getIDCricle icon;

    private void Start()
    {
     
    }

    public void _Replace()
    {
        if (icon == getIDCricle.cricle || icon == getIDCricle.square || icon == getIDCricle.triangle)
        {
            lv4Controller.Instance._replace();
        }
    }
}
