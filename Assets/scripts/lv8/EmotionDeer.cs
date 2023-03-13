using DG.Tweening;
using SCN.Animation;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EmotionDeer : MonoBehaviour
{
    private static EmotionDeer _instance;
    public static EmotionDeer Instance { get { return _instance; } }

    private void Awake()
    {
        _instance = this;   
    }

    AnimationSpineController spineControl;
    [SerializeField] AnimationSpineController.SpineAnim anibatDau;
    [SerializeField] AnimationSpineController.SpineAnim animOnPle;
    [SerializeField] AnimationSpineController.SpineAnim animIdle;
    [SerializeField] AnimationSpineController.SpineAnim animketThuc;

    [SerializeField] GameObject movPos;
    void Start()
    {
        spineControl = GetComponent<AnimationSpineController>();
        spineControl.InitValue();

        StartCoroutine(nameof(batDau));
    }

    public IEnumerator batDau()
    {
        spineControl.PlayAnimation(anibatDau, true);

        yield return new WaitForSeconds(2);

        spineControl.PlayAnimation(animIdle, true);
    }

    public IEnumerator Completed()
    {
        spineControl.PlayAnimation(animOnPle, true);

        transform.DOMove(movPos.transform.position,4).OnComplete(() =>
        {
            spineControl.PlayAnimation(animketThuc, true);

        });
        yield return null;
    }
}
