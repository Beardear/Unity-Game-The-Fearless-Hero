using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoundManager : MonoBehaviour
{
    //Outlet
    AudioSource backgroundLevelMusic;
    //public AudioClip backgroundLevelMusic;
    //public AudioClip hitAudio;




    // Start is called before the first frame update
    void Start()
    {
        backgroundLevelMusic = GetComponent<AudioSource>();
        backgroundLevelMusic.Play();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
