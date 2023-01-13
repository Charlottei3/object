using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class lv8Controller : MonoBehaviour
{
    private static lv8Controller _instance;
    public static lv8Controller Instance { get { return _instance; } }

    private void Awake()
    {
        _instance= this;
    }

    [SerializeField] List<GameObject> _gameObjs;
    [SerializeField] List<GameObject> _instanceObj;
    [SerializeField] List<GameObject> _boxSelected;
    [SerializeField] Transform _parent;

    GameObject obj_click;
    GameObject _bxSelec1;
    GameObject _bxSelec2;
    GameObject hoiCham;

    // Start is called before the first frame update
    void Start()
    {
        ranItem();
    }
    List<GameObject> _addIe = new List<GameObject>();
    List<GameObject> _addInstanItem = new List<GameObject>();
    public void ranItem()
    {
        for (int i = 1; i < _gameObjs.Count; i++)
        {
            _addIe.Add(_gameObjs[i]);
        }

        int ran_1 = Random.Range(0, _addIe.Count);
        GameObject _ie_1 = _addIe[ran_1];
        _addIe.RemoveAt(ran_1);
        int ran_2 = Random.Range(0, _addIe.Count);
        GameObject _ie_2 = _addIe[ran_2];

        GameObject _iste_1 = Instantiate(_ie_1, _instanceObj[0].transform.position,Quaternion.identity,_parent);
        GameObject _iste_2 = Instantiate(_ie_2, _instanceObj[1].transform.position,Quaternion.identity,_parent);
        GameObject _iste_3 = Instantiate(_ie_1, _instanceObj[2].transform.position,Quaternion.identity,_parent);
        GameObject _iste_4 = Instantiate(_ie_2, _instanceObj[3].transform.position,Quaternion.identity,_parent);

        _addInstanItem.Add(_iste_1);
        _addInstanItem.Add(_iste_2);
        _addInstanItem.Add(_iste_3);
        _addInstanItem.Add(_iste_4);

        int rd_i = Random.Range(0, _addInstanItem.Count);
        obj_click = _addInstanItem[rd_i];
        obj_click.SetActive(false);
        hoiCham = Instantiate(_gameObjs[0],obj_click.transform.position,Quaternion.identity,_parent);

        _bxSelec1 = Instantiate(_ie_1, _boxSelected[0].transform.position, Quaternion.identity, _parent);
        _bxSelec2 = Instantiate(_ie_2, _boxSelected[1].transform.position, Quaternion.identity, _parent);

    }

    public void selectedItem()
    {
      if(_bxSelec1 || _bxSelec2)
        {
            obj_click.SetActive(true);
            hoiCham.SetActive(false);
        }
        Debug.Log("click");
    }
 
}
