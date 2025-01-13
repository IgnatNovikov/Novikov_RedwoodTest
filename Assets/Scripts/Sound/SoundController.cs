using UnityEngine;

public class SoundController : MonoBehaviour
{
    [SerializeField] private AudioSource _source;
    [SerializeField] private AudioClip _zombieDeadSound;
    [SerializeField] private AudioClip _zombieHitSound;
    [SerializeField] private AudioClip _pickUpSound;

    public void PlayZombieDead()
    {
        _source.PlayOneShot(_zombieDeadSound);
    }

    public void PlayZombieHit()
    {
        _source.PlayOneShot(_zombieHitSound);
    }

    public void PlayPickUp()
    {
        _source.PlayOneShot(_pickUpSound);
    }
}
