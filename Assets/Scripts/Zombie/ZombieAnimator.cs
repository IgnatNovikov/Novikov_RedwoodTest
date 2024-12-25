using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ZombieAnimator : MonoBehaviour
{
    [SerializeField] private Animator _animator;
    [SerializeField] private Transform _zombieTransform;

    public void Run(RuntimeAnimatorController controller, Vector2 direction)
    {
        _animator.runtimeAnimatorController = controller;

        Vector3 scale = _zombieTransform.localScale;
        if (direction.x < 0)
        {
            scale.x = -1;
        }
        else
        {
            scale.x = 1;
        }
        _zombieTransform.localScale = scale;
    }
}
