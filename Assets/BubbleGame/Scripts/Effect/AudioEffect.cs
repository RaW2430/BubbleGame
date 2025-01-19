using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioEffect : MonoBehaviour
{
    public AudioClip audioClip; // 要播放的音频
    public float volume = 1.0f; // 音量
    private AudioSource audioSource;

    // Start is called before the first frame update
    void Start()
    {
        audioSource = GetComponent<AudioSource>();
        if (audioSource == null)
        {
            audioSource = gameObject.AddComponent<AudioSource>();
        }
    }

    // Update is called once per frame
    void Update()
    {

    }

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            PlayAudio(audioClip, volume);
        }
    }

    void PlayAudio(AudioClip clip, float volume)
    {
        if (audioSource != null && clip != null)
        {
            audioSource.clip = clip;
            audioSource.volume = volume; // 设置音量
            audioSource.Play();
        }
    }
}

