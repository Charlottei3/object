using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace SCN.Common
{
    [CreateAssetMenu(fileName = "Load scene settings", menuName = "SCN/Scriptable Objects/LoadScene")]
    public class LoadSceneSettings : ScriptableObject
    {
        [Header("Custom")]
        [SerializeField] string layer;
        [SerializeField] int orderInLayer;

        [SerializeField] AnimLoadSceneBase loadSceneAnimDefault;

        public string Layer => layer;
        public int OrderInLayer => orderInLayer;
        public AnimLoadSceneBase LoadSceneAnimDefault => loadSceneAnimDefault;
    }
}