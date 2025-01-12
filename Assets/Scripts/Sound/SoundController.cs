using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoundController : MonoBehaviour
{
    [SerializeField] private AudioSource _source;
    [SerializeField] private AudioClip _zombieSound;

    public void Play()
    {
        _source.PlayOneShot(_zombieSound);
    }
}
