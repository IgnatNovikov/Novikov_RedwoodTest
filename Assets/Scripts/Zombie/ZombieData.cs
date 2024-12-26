using System;
using UnityEngine;

[Serializable]
public class ZombieData
{
    [SerializeField, Min(0)] private float _moveSpeed;
    public float MoveSpeed => _moveSpeed;
    [SerializeField, Min(0)] private int _health;
    public int Health => _health;
    [SerializeField] private RuntimeAnimatorController _animatorController;
    public RuntimeAnimatorController AnimatorController => _animatorController;
}
