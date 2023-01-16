using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
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

    int idSelect;


    private void Start()
    {
     
        ranItem();
    }

    public void ranItem()
    {
        List<Sprite> _addSprite= new List<Sprite>();
        for (int i = 1; i < _gameObjs.Count; i++)
        {
            _addSprite.Add(_gameObjs[i]);
        }

        int _ran_1 = Random.Range(0, _addSprite.Count);
        _instanceObj[0].sprite = _addSprite[_ran_1];
        _instanceObj[3].sprite = _addSprite[_ran_1];
        _addSprite.RemoveAt(_ran_1);

        int _ran_2 = Random.Range(0, _addSprite.Count);
        _instanceObj[1].sprite = _addSprite[_ran_2];
        _instanceObj[4].sprite = _addSprite[_ran_2];
        _addSprite.RemoveAt(_ran_2);

        int _ran_3 = Random.Range(0, _addSprite.Count);
        _instanceObj[2].sprite = _addSprite[_ran_3];
        _instanceObj[5].sprite = _addSprite[_ran_3];


        int _hoiCham = Random.Range(0, _instanceObj.Count - 1);

        int _ranTrue = Random.Range(0, 1);
        _ranTrue = idSelect;

        _boxSelected[_ranTrue].sprite = _instanceObj[_hoiCham].sprite;
        Debug.Log("id bx1 :  " + _boxSelected[_ranTrue].name);
        Debug.Log("id bx1 image true:  " + _instanceObj[_hoiCham].sprite.name);

        _gameObjs.Remove(_instanceObj[_hoiCham].sprite);
        int _ran = Random.Range(1, _gameObjs.Count - 1);
        
        _boxSelected[_ranTrue == 0 ? 1 : 0].sprite = _instanceObj[_ran].sprite;

      
        Debug.Log("id bx2:  " + _boxSelected[_ranTrue == 0 ? 1 : 0]);
        Debug.Log("name image false: " + _instanceObj[_ran].sprite.name);

        _instanceObj[_hoiCham].sprite = _gameObjs[0];

    }

    public void selectedItem(int id)
    {
        if (id == idSelect)
        {
            _instanceObj[idSelect].sprite = _instanceObj[idSelect].sprite;
        }

        Debug.Log(idSelect);
        Debug.Log(id);
    }

}
