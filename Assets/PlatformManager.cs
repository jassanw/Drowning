using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlatformManager : MonoBehaviour
{
    [SerializeField] AudioSource audioSource;

    private void Awake()
    {
        Platform.OnPlatformHit += OnPlatformHit;
    }

    private void OnDestroy()
    {
        Platform.OnPlatformHit -= OnPlatformHit;
    }

    private void OnPlatformHit()
    {
        audioSource.Play();
    }


}
