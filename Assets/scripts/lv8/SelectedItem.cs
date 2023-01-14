using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SelectedItem : MonoBehaviour
{
    private static SelectedItem _instance;
    public static SelectedItem Instance { get { return _instance; } }
    private void Awake()
    {
        _instance= this;
    }

    [SerializeField] public int id;

    // Start is called before the first frame update
    void Start()
    {
        
    }
    public void selectIe()
    {
        lv8Controller.Instance.selectedItem(id);
    }
}
