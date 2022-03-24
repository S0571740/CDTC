using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioController : MonoBehaviour
{
    [SerializeField] private AudioClip menuMusic;
    [SerializeField] private AudioClip gameMusic;
    [SerializeField] private AudioSource source;

    void Start(){
        source.clip = menuMusic;
        source.Play();
    }

    public void disable(){
        source.Stop();
    }

    public void enable(){
        source.Play();
    }

    public void switchTrack(){
        source.clip = gameMusic;
    }
}