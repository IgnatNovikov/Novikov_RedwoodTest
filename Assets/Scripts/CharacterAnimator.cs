using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterAnimator : MonoBehaviour
{
    [SerializeField] private Animator _animator;
    [SerializeField] private Transform _characterTransform;
    [SerializeField] private string _moveBoolName;
    [SerializeField] private string _shotTriggerName;

    public void Moving(Vector2 direction)
    {
        if (direction.x == 0)
        {
            _animator.SetBool(_moveBoolName, false);
            return;
        }

        Vector3 scale = _characterTransform.localScale;
        if (direction.x < 0)
        {
            scale.x = -1;
        }
        else
        {
            scale.x = 1;
        }
        _characterTransform.localScale = scale;

        _animator.SetBool(_moveBoolName, true);
    }

    public void Shot(bool enable)
    {
        _animator.SetBool(_shotTriggerName, enable);
    }
}
