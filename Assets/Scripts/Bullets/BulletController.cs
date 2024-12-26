using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Zenject;

public class BulletController : MonoBehaviour
{
    [SerializeField] private Rigidbody2D _rigidBody;
    [SerializeField] private float _speed;


    //[Inject] private IBulletPool _bulletPool;
    public void Shoot(Vector3 direction)
    {
        _rigidBody.AddForce(direction * _speed);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        ZombieHurtbox zombie = collision.GetComponent<ZombieHurtbox>();
        if (zombie == null)
            return;

        zombie.TakeHit();
        gameObject.SetActive(false);
        //_bulletPool.FreeBullet(this);
    }
}
