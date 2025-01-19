using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//[System.Serializable]
//public class AudioPrefabPair
//{
//    public GameObject prefab;
//    public AudioClip audioClip;
//}

public class PlayerAudioController : MonoBehaviour
{
    //public List<AudioPrefabPair> audioPrefabPairs; // ��Inspector�б༭����Ƶ��Prefab��Ӧ�б�
    public AudioClip audio_default; // Ĭ�ϲ��ŵ���Ƶ
    public AudioClip audio_pressKey; // ����WASD��ʱ���ŵ���Ƶ
    public AudioClip audio_Death; // �������ʱ���ŵ���Ƶ
    public float audio_default_volume = 0.3f;
    public float audio_pressKey_volume = 3.0f;
    //public float audio_item_volume = 1.0f;
    public float audio_Death_volume = 1.0f;
    private AudioSource audioSource;
    private PlayerAttributes playerAttributes;

    // Start is called before the first frame update
    void Start()
    {
        audioSource = GetComponent<AudioSource>();
        PlayAudio(audio_default, audio_default_volume);
        playerAttributes = gameObject.GetComponent<PlayerAttributes>();
    }

    // Update is called once per frame
    void Update()
    {
        if (playerAttributes.isDead)
        {
            if (audioSource.clip != audio_Death)
            {
                PlayAudio(audio_Death, audio_Death_volume); 
            }
        }
        else if (Input.GetKey(KeyCode.W) || Input.GetKey(KeyCode.A) || Input.GetKey(KeyCode.S) || Input.GetKey(KeyCode.D))
        {
            if (audioSource.clip != audio_pressKey)
            {
                PlayAudio(audio_pressKey, audio_pressKey_volume); // ����WASD��ʱ����audio_pressKey
            }
        }
        else
        {
            if (audioSource.clip != audio_default)
            {
                PlayAudio(audio_default, audio_default_volume); // û�а���WASD��ʱ����audio_default
            }
        }
    }

    //void OnTriggerEnter2D(Collider2D other)
    //{
    //    foreach (var pair in audioPrefabPairs)
    //    {
    //        if (other.gameObject == pair.prefab)
    //        {
    //            PlayAudio(pair.audioClip, audio_item_volume); // ������ײ����Prefab��Ӧ����Ƶ������Ϊaudio_item_volume
    //            break;
    //        }
    //    }
    //}

    void PlayAudio(AudioClip clip, float volume)
    {
        if (audioSource != null && clip != null)
        {
            audioSource.clip = clip;
            audioSource.volume = volume; // ��������
            audioSource.Play();
        }
    }
}

