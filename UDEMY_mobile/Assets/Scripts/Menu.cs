using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Menu : MonoBehaviour
{
    public void LaunchGame()
    {
        SceneManager.LoadScene(1);
    }

    public void LaunchLevel(int lvl)
    {
        SceneManager.LoadScene(lvl);
    }
}
