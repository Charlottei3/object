using DG.Tweening;
using SCN.Animation;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EmotionChar : MonoBehaviour
{
    private static EmotionChar _instance;
    public static EmotionChar Instance { get { return _instance; } }

    private void Awake()
    {
        _instance = this; 
    }

    AnimationSpineController spineControl;
    [SerializeField] AnimationSpineController.SpineAnim anibatDau;
    [SerializeField] AnimationSpineController.SpineAnim animOnPle;
    [SerializeField] AnimationSpineController.SpineAnim aniFail;
    [SerializeField] AnimationSpineController.SpineAnim shake_head;
    [SerializeField] AnimationSpineController.SpineAnim animIdle;
    [SerializeField] AnimationSpineController.SpineAnim animketThuc;

  
    void Start()
    {
        spineControl = GetComponent<AnimationSpineController>();
        spineControl.InitValue();

    }

    public IEnumerator batDau()
    {

        spineControl.PlayAnimation(anibatDau, true);
      
        yield return new WaitForSeconds(2);

        spineControl.PlayAnimation(animIdle, true);
    }

 
    public IEnumerator EmoFail()
    {

        spineControl.PlayAnimation(aniFail, true);
        yield return new WaitForSeconds(0.5f);
        spineControl.PlayAnimation(shake_head, true);
        yield return new WaitForSeconds(1f);
        spineControl.PlayAnimation(animIdle, true);

    }

    public IEnumerator Completed()
    {

        spineControl.PlayAnimation(animOnPle, true);

        yield return new WaitForSeconds(2);

        spineControl.PlayAnimation(animketThuc, true);
    }


}
