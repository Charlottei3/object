using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ver2ControlLv8: MonoBehaviour
{
    private static ver2ControlLv8 _instance;
    public static ver2ControlLv8 Instance { get { return _instance; } }
    private void Awake()
    {
        _instance= this;
    }

    [SerializeField] List<Sprite> _gameObjs;
    [SerializeField] List<Image> _instanceObj;
    [SerializeField] List<Image> _boxSelected;

   

    private void Start()
    {
        
    }

    public void ranItem()
    {
        List<Sprite> _addSprite= new List<Sprite>();
        for (int i = 1; i < _gameObjs.Count; i++)
        {
            _addSprite.Add(_gameObjs[i]);
        }

        int _ran_1 = Random.Range(0, _addSprite.Count);
        _addSprite.RemoveAt(_ran_1);
        int _ran_2 = Random.Range(0, _addSprite.Count);
        _addSprite.RemoveAt(_ran_2);
        int _ran_3 = Random.Range(0, _addSprite.Count);

        
        for (int i = 0; i < _instanceObj.Count; i++)
        {
            
        }
    }
   
}
