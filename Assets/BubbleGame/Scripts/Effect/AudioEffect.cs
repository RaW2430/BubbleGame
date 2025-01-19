using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioEffect : MonoBehaviour
{
    public AudioClip audioClip; // 要播放的音频
    public float volume = 1.0f; // 音量
    public bool isTrap = false; // 是否为陷阱音效
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
            PlayerAttributes playerAttributes = other.GetComponent<PlayerAttributes>();
            if (playerAttributes != null)
            {
                if (isTrap && playerAttributes.isInvincible)
                {
                    // 如果是陷阱音效且玩家处于无敌状态，则不播放音效
                    Debug.Log("Player is invincible, no need to play audio effect.");
                    return;
                }
                PlayAudio(audioClip, volume);
            }
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


