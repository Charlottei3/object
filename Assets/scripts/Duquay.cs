using System.Collections;
using System.Collections.Generic;
using Unity.Mathematics;
using UnityEngine;

public class Duquay : MonoBehaviour
{
    void Start()
    {
        StartCoroutine(nameof(Move));
    }

    IEnumerator Move()
    {
        while (true)
        {
            transform.rotation= Quaternion.identity;
            yield return null;
        }

    }
}
