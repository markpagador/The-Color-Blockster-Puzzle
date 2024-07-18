using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Rendering;

public class SoundEffects : MonoBehaviour
{
    public AudioSource src;
    public AudioClip sfx1, sfx2, sfx3, sfx4, sfx5,sfx6;
    
    public void Start()
    {
        src.clip = sfx1;
        src.Play();
    }
    public void Settings()
    {
        src.clip = sfx2;
        src.Play();
    }
    public void Credits ()
    {
        src.clip = sfx3;
        src.Play();
    }
    public void Close ()
    {
        src.clip = sfx4;
        src.Play();
    }
    public void Achievement ()
    {
        src.clip = sfx5;
        src.Play();
    }
    public void BackButton()
    {
    src.clip = sfx6;
    src.Play(); 
    }
}
