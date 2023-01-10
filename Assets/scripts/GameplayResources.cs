using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "Scriptable Objects/GameplayResources", fileName = "GameplayResources")]
public class GameplayResources : ScriptableObject
{
    public static GameplayResources Instance
    {
        get
        {
            if (instance != null)
            {
                return instance;
            }
            else
            {
                instance = Resources.Load("GameplayResources") as GameplayResources;
                return instance;
            }
        }
    }
    static GameplayResources instance;

    [Header("Level 1")]
    public List<IceCreamColor> IceCreamColor;

    [Header("Level 2")]
    public List<nguaLv2> gameLv2;

    public List<item_noel> item_Noels;

}
[Serializable]
public struct IceCreamColor
{
    public Sprite Body;
    public Sprite Top1;
    public Sprite Top2;
    public Sprite Topping;
    public Sprite ToppingParticle1;
    public Sprite ToppingParticle2;

    public Vector3 dropPosition;
   
}

[Serializable]
public struct nguaLv2
{
    public Sprite Ngua;
    public Sprite hinhNho;
    public Sprite wolfoo;
    public Sprite bong;
    public Sprite cot;
   

    public Vector3 dropPosition;
}



[Serializable]

public struct item_noel
{
    public List<Sprite> listSprite;
  
}
