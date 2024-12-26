using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletController : MonoBehaviour
{
    [SerializeField] private Rigidbody2D _rigidBody;
    [SerializeField] private float _speed;

    private void Start()
    {
        Shoot();
    }

    public void Shoot()
    {
        _rigidBody.AddForce(Vector2.right * _speed);
        Debug.Log(_rigidBody.velocity);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        ZombieHurtbox zombie = collision.GetComponent<ZombieHurtbox>();
        if (zombie == null)
            return;

        zombie.TakeHit();
        gameObject.SetActive(false);
    }
}
