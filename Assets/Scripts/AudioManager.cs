using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioManager : MonoBehaviour
{
    [SerializeField] AudioClip playerHurtSound;
    [SerializeField] AudioSource source;

    private void OnEnable()
    {
        PlayerObservee.HealthChanged += PlayHurtSound;
    }

    private void OnDisable()
    {
        PlayerObservee.HealthChanged -= PlayHurtSound;
    }
    void PlayHurtSound(int _health)
    {
        source.clip = playerHurtSound;
        source.Play();
    }
}
