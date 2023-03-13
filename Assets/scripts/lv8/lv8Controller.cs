using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;

public class lv8Controller : MonoBehaviour
{
    private static lv8Controller _instance;
    public static lv8Controller Instance { get { return _instance; } }

    private void Awake()
    {
        _instance= this;
    }

    [SerializeField] List<Sprite> _gameObjs;
    [SerializeField] List<Image> _instanceObj;
    [SerializeField] List<Image> _boxSelected;

    [SerializeField] private GameObject stepone;
    [SerializeField] private GameObject steptwo;

    int idSelect;
    int _hoiCham;
    int _ranTrue;
    private void Start()
    {
        ranItem();
    }

    public void ranItem()
    {
        List<Sprite> _addSprite = new List<Sprite>();
        for (int i = 1; i < _gameObjs.Count; i++)
        {
            _addSprite.Add(_gameObjs[i]);
        }

        int _ran_1 = Random.Range(0, _addSprite.Count);
        _instanceObj[0].sprite = _addSprite[_ran_1];
        _instanceObj[2].sprite = _addSprite[_ran_1];
        _addSprite.RemoveAt(_ran_1);

        int _ran_2 = Random.Range(0, _addSprite.Count);
        _instanceObj[1].sprite = _addSprite[_ran_2];
        _instanceObj[3].sprite = _addSprite[_ran_2];
    
        _hoiCham = Random.Range(0, _instanceObj.Count - 1);
       

        Debug.Log("count hoi cham ? : " + _hoiCham);
        Debug.Log("sprite hoi cham ? : " + _instanceObj[_hoiCham].sprite.name);
       
        _ranTrue = Random.Range(0,1);
        _ranTrue = idSelect;

        _boxSelected[_ranTrue].sprite = _instanceObj[_hoiCham].sprite;

        Debug.Log("id bx1 :  " + _boxSelected[_ranTrue].sprite.name);
        Debug.Log("id bx1 :  " + _boxSelected[_ranTrue]);
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
            _instanceObj[_hoiCham].sprite = _boxSelected[idSelect].sprite;

            EmotionChar.Instance.StartCoroutine(EmotionChar.Instance.Completed());
   
            stepone.SetActive(false);
            steptwo.SetActive(true);
        }
        else
        {
            EmotionChar.Instance.StartCoroutine(EmotionChar.Instance.EmoFail());
        }
        Debug.Log(_instanceObj[_hoiCham].sprite.name);
        Debug.Log(_instanceObj[idSelect].sprite.name);
        Debug.Log(idSelect);
        Debug.Log(id);
    }

}
