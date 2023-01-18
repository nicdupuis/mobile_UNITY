using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SetVolume : MonoBehaviour
{
    public AudioSource aSource;


    void Start()
    {
        float val = PlayerPrefs.GetFloat("volume");
        if(val == 0)
        {
            val = 0.2f;
        }
        GetComponent<Slider>().value = val;
        aSource.volume = val;
    }
    public void SetMusicVolume()
    {
        float val = GetComponent<Slider>().value;
        PlayerPrefs.SetFloat("volume", val);
        aSource.volume = val;
    }
}
