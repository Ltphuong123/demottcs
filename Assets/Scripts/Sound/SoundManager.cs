using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoundManager : MonoBehaviour
{
    public AudioClip soundClip1; 
    public AudioClip soundClip2; 
    [SerializeField]protected AudioSource audioSource;
    private static SoundManager instance;
    public static SoundManager Instance {get=>instance;}
    void Start()
    {
        // Lấy hoặc thêm Component AudioSource
        audioSource = GetComponent<AudioSource>();
        if (audioSource == null)
        {
            audioSource = gameObject.AddComponent<AudioSource>();
        }
        
        // Gán âm thanh cho AudioSource
        
    }
    public virtual void aa(){
        audioSource.clip = soundClip1;
        audioSource.Play();
    }
    public virtual void aa1(){
        audioSource.clip = soundClip1;
        audioSource.Play();
    }

}
