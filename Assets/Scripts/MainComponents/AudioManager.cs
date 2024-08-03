using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioManager : MonoBehaviour
{
    private AudioSource audioSource;
    public AudioClip[] music;

    private void Awake()
    {
        audioSource = GetComponent<AudioSource>();
    }

    private void Start()
    {
        PlayBGM();
    }

    private void PlayBGM()
    {
        StopAllCoroutines();
        StartCoroutine(PlayMusic());
    }

    private IEnumerator PlayMusic()
    {
        audioSource.clip = music[Random.Range(0, music.Length - 1)];
        audioSource.Play();
        yield return new WaitForSeconds(audioSource.clip.length);
        audioSource.Stop();
        PlayBGM();
    }
}
