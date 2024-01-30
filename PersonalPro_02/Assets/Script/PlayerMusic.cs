using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum SoundType 
{
    Jump = 0,
    Coin,
    Button,
    Die,
    Wind
}

public class PlayerMusic : MonoBehaviour
{
    AudioSource jump;
    AudioSource coin;
    AudioSource button;
    AudioSource die;
    AudioSource wind;
    
    private void Awake()
    {
        jump = transform.GetChild(0).GetComponent<AudioSource>();
        coin = transform.GetChild(1).GetComponent<AudioSource>();
        button = transform.GetChild(2).GetComponent<AudioSource>();
        die = transform.GetChild(3).GetComponent<AudioSource>();
        wind = transform.GetChild(4).GetComponent<AudioSource>();
    }

    public void SoundPlay(SoundType sound)
    {
        switch (sound)
        {
            case SoundType.Jump:
                jump.Play();
                break;
            case SoundType.Coin:
                coin.Play();
                break;
            case SoundType.Button:
                button.Play();
                break;
            case SoundType.Die:
                die.Play();
                break;
            case SoundType.Wind:
                wind.Play();
                break;
        }
    }
}
