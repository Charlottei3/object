using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class nxStepNew : MonoBehaviour
{
    private static nxStepNew _instance;

    public static nxStepNew Instance { get { return _instance; } }
    private void Awake()
    {
      _instance = this;
    }

    [SerializeField] private GameObject stepone;

    [SerializeField] private GameObject steptwo;
}
