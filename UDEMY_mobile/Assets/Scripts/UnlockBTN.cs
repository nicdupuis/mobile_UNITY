using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UnlockBTN : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        int lvl = PlayerPrefs.GetInt("lastLevel");
        int thisLevel = int.Parse(gameObject.name);
        if(thisLevel <= lvl)
        {
            GetComponent<Button>().interactable = true;
        }
    }
}
