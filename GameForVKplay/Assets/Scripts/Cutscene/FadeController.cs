using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FadeController : MonoBehaviour
{
    [SerializeField] private GameObject scene;
    private Animator animatorScene;
    private Animator animator;

    void Start()
    {
        animator = GetComponent<Animator>();
        animatorScene = scene.GetComponent<Animator>();
    }

    public void ShowBadEnd()
    {
        animatorScene.SetTrigger("SetBadEnd");
        animator.SetTrigger("Fade");
    }

    public void AnimBadEnd() 
    {
        animatorScene.SetTrigger("Next");
    }
}
