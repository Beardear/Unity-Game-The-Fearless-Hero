using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoundManager : MonoBehaviour
{
    //Outlet
    AudioSource audioSource;
    public AudioClip JabAudio;
    public AudioClip KickAudio;
    public AudioClip DiveKickAudio;
    public AudioClip JumpKickAudio;
    //public AudioClip backgroundLevelMusic;
    //public AudioClip hitAudio;

    public void playJabAudio()
    {
        audioSource.PlayOneShot(JabAudio);
    }
    public void playKickAudio()
    {
        audioSource.PlayOneShot(KickAudio);
    }
    public void playDiveKickAudio()
    {
        audioSource.PlayOneShot(DiveKickAudio);
    }
    public void playJumpKickAudio()
    {
        audioSource.PlayOneShot(JumpKickAudio);
    }


    // Start is called before the first frame update
    void Start()
    {
        audioSource = GetComponent<AudioSource>();      //≤•∑≈±≥æ∞“Ù¿÷
        audioSource.Play();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
