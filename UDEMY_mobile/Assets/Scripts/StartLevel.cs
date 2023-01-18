using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StartLevel : MonoBehaviour
{
    public GameObject gameIHM;
    public GameObject animCam;

    // Update is called once per frame
    void Update()
    {
        if(Input.GetKeyUp(KeyCode.Space) || Input.GetMouseButtonUp(0))
        {
            gameIHM.SetActive(true);
            animCam.SetActive(false);
            this.gameObject.SetActive(false);
        }
    }
}
