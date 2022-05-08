using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAnimationController : MonoBehaviour
{
    [SerializeField] private VoidEvent onLevelFinishLineReached;
    private Animator animator;

    private void OnEnable() {
        onLevelFinishLineReached.OnEventRaised += PlayAnimation;
    }

    private void OnDisable() {
        onLevelFinishLineReached.OnEventRaised -= PlayAnimation;
    }
    private void Start() {
        animator = GetComponent<Animator>();
    }

    private void PlayAnimation()
    {
        animator.SetBool("isJumping", true);
    }
}
