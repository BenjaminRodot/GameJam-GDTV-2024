using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RandomSound : MonoBehaviour
{
    [SerializeField] private AudioSource _audioSource;

    [SerializeField] private AudioClip[] _clips;

    void Start()
    {
        AudioClip randomClip = _clips[Random.Range(0,_clips.Length)];
        _audioSource.PlayOneShot(randomClip);
    }
}
