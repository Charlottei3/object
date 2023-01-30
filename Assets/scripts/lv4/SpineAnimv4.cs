using DG.Tweening;
using SCN.Animation;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpineAnimv4 : MonoBehaviour
{
    private static SpineAnimv4 _instace;
    public static SpineAnimv4 Instance { get { return _instace; } }

    private void Awake()
    {
        _instace = this; 
    }
    AnimationSpineController spineControl;
    [SerializeField] AnimationSpineController.SpineAnim animScaleOn;
    [SerializeField] AnimationSpineController.SpineAnim animIdle;
    void Start()
    {
        spineControl = GetComponent<AnimationSpineController>();
        spineControl.InitValue();
    }

    public IEnumerator ScaleOn()
    {

        spineControl.PlayAnimation(animScaleOn, true);
      
        yield return new WaitForSeconds(2);
        spineControl.PlayAnimation(animIdle, true);

    }
}
