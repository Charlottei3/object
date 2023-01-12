using DG.Tweening;
using SCN.ActionLib;
using SCN.Common;
using SCN.UIExtend;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.Pool;
using UnityEngine.UI;

namespace CN.UIExtend
{
    public class ScrollInfinityManager : MonoBehaviour
    {

        [SerializeField] List<GameObject> item_noel;
        [SerializeField] Transform parent;
     
        [SerializeField] public GameObject obj_ins;

        public float countSecond;

        private static ScrollInfinityManager _instance;
        public static ScrollInfinityManager Instance { get { return _instance; } }


        public class ItemPool
        {
            public List<GameObject> die_item;
            public List<GameObject> life_item;

           
        }
            


        private void Awake()
        {
            _instance = this;

        }

        private void Start()
        {
            
            StartCoroutine(nameof(ranItemMove));
           
        }

        public void StopCoroutineItemMove()
        {
            StopCoroutine(nameof(ranItemMove));
        }
 
        IEnumerator ranItemMove()
        {
            yield return new WaitForSeconds(countSecond);
            while (true)
            {
                int ran_it = Random.Range(0, item_noel.Count - 1);

                Debug.Log(item_noel.Count);
                GameObject obj_mov = item_noel[ran_it];
                //obj_mov.SetActive(true);
                Instantiate(obj_mov, obj_ins.transform.position, Quaternion.identity, parent);
         
                yield return new WaitForSeconds(countSecond);
                /*if (item_noel[ran_it] == null)
                {
                    StopCoroutine(ranItemMove());
                }*/
            }
        }
 
        public void xoaItem(int index)
        {
            GameObject del = item_noel.Find(i => i.GetComponent<DragItemNoel>().index == index);    
            if(del != null )
            {
                item_noel.Remove(del);
            }

            if(item_noel.Count == 0)
            {
                StopAllCoroutines();
            }
        }
    }
}

