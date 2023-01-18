using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class pause : MonoBehaviour
{
    bool isPaused = false;
    public GameObject pauseMenu;


    void Start()
    {
        isPaused = false;
        Time.timeScale = 1f;
    }
    public void SetPauseState()
    {
        SFXMgr.Instance.PlaySFXbyID(3);
        if(!isPaused)
        {
            pauseMenu.SetActive(true);
            Time.timeScale = 0f;
        }
        else
        {
            pauseMenu.SetActive(false);
            Time.timeScale = 1f;
        }
        isPaused = !isPaused;
    }
}
