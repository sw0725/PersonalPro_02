using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Explosion : MonoBehaviour
{
    GameObject explosion;
    Animator animator;
    float animeLenth = 0.0f;

    private void Awake()
    {
        explosion = transform.GetChild(0).gameObject;
        animator = explosion.GetComponent<Animator>();
        animeLenth = animator.GetCurrentAnimatorClipInfo(0)[0].clip.length;
    }

    private void OnEnable()
    {
        Destroy(gameObject, animeLenth);
    }
}
