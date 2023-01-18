using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;

public class PanelFin : MonoBehaviour
{
    public TextMeshProUGUI text;

    void Start()
    {
        SetTotalScore();
    }
    public void BackToMenu()
    {
        SceneManager.LoadScene(0);
    }

    public void GoToNextLevel()
    {
        int nextLevel = SceneManager.GetActiveScene().buildIndex + 1;
        UnlockNextLevel(nextLevel);
        if(nextLevel < 11)
        {
            SceneManager.LoadScene(nextLevel);
        }
        else
        {
            SceneManager.LoadScene(0); //retour menu
        }
    }

    public void UnlockNextLevel(int lvl)
    {
        int lastUnlockedLevel = PlayerPrefs.GetInt("lastLevel");
        if(lvl > lastUnlockedLevel)
        {
            PlayerPrefs.SetInt("lastLevel", lvl);
        }
    }

    public void SetTotalScore()
    {
        text.text = "Votre score total: " + GameManager.Instance.score;
    }

    public void Quitter()
    {
        Application.Quit();
    }
}
