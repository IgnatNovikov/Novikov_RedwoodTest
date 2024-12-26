using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ZombieHurtbox : MonoBehaviour
{
    [SerializeField] private ZombieController _zombieController;

    public void  TakeHit()
    {
        _zombieController.TakeHit();
    }
}
