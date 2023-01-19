using DG.Tweening;
using SCN.Animation;
using Spine.Unity;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class _CharMenu : MonoBehaviour
{
    [SerializeField] GameObject _movPos;
    AnimationSpineController spineController;
    [SerializeField] AnimationSpineController.SpineAnim _batDau;
    [SerializeField] AnimationSpineController.SpineAnim _idel;
    [SerializeField] AnimationSpineController.SpineAnim _mov;

    void Start()
    {
        spineController = GetComponent<AnimationSpineController>();
        spineController.InitValue();

        StartCoroutine(nameof(aniMoly));
    }

    public void aniMonlly()
    {
        spineController.PlayAnimation(_batDau, true);
       
    }

    IEnumerator aniMoly()
    {

        spineController.PlayAnimation(_idel, true);

        spineController.PlayAnimation(_mov, true);
        transform.DOMoveX(5, 2).OnComplete(() =>
        {
            spineController.PlayAnimation(_idel, true);
        });
        yield return new WaitForSeconds(1);

        transform.GetComponent<SkeletonGraphic>().initialFlipX = true;
        transform.DOMoveX(-5, 3);
        spineController.PlayAnimation(_mov, true);
       
    }
}
