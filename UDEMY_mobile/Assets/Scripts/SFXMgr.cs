using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SFXMgr : MonoBehaviour
{
    public static SFXMgr _instance;
    public static SFXMgr Instance
    {
        get
        {
            if(_instance == null)
            {
                _instance = GameObject.FindObjectOfType<SFXMgr>();
            }
            return _instance;
        }
    }
    public AudioClip[] sfx;
    public AudioSource aSource;

    public void PlaySFXbyID(int id)
    {
        aSource.PlayOneShot(sfx[id]);
    }

    void Awake()
    {
        if(_instance != null && _instance != this)
        {
            Destroy(this.gameObject);
        }
    }
}
