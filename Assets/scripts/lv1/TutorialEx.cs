using SCN.Tutorial;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TutorialEx : MonoBehaviour
{
    [SerializeField] Transform[] pos;

    private void Start()
    {
        SCN.Tutorial.TutorialManager.Instance.StartPointer(
            pos[0].transform.position, pos[1].transform.position, Gesture.Hold);

        SCN.Tutorial.TutorialManager.Instance.StartPointer(
            pos[2].position, pos[3].position, Gesture.Hold);

        SCN.Tutorial.TutorialManager.Instance.StartPointer(
            pos[4].position, pos[5].position, Gesture.Hold);

        //SCN.Tutorial.TutorialManager.Instance.StartPointer(
        //pos[0], pos[1], Gesture.Hold);
    }
}

