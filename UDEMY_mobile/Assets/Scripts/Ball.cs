using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;

public class Ball : MonoBehaviour
{
public GameObject winParticles;
public TextMeshProUGUI text;
public Shoot shootscript;

public GameObject panelFin;
public Transform cubeFin;
public GameObject camZoom;
bool canZoom = true;

void Start()
{
    cubeFin = GameObject.Find("Cube_fin").transform;
}

void Update()
{
    if(camZoom)
    {
        if(Vector3.Distance(transform.position, cubeFin.position) < 2f)
        {
            if(canZoom)
            {
                canZoom = false;
                camZoom.SetActive(true);
                camZoom.GetComponent<DisableZoom>().ForceDisable();
            }
        }
        else
        {
            camZoom.SetActive(false);
            canZoom = true;
        }
    }
    
}
    void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.tag == "fall")
        {
            SFXMgr.Instance.PlaySFXbyID(2);
            StartCoroutine("LoadLevelAfterSeconds");
            SceneManager.LoadScene(SceneManager.GetActiveScene().name);
        }
        if(other.gameObject.tag == "fin")
        {
            int score = (10 - shootscript.nbShots) * 100;
            if(score < 0) score = 0;
            GameManager.Instance.score += score;

            Instantiate(winParticles, transform.position, Quaternion.identity);
            SFXMgr.Instance.PlaySFXbyID(0);
            text.text = "Terminé en " + shootscript.nbShots + " coups!";
            panelFin.SetActive(true);
        }
        if(other.gameObject.tag == "bonus")
        {
            Destroy(other.gameObject);
            SFXMgr.Instance.PlaySFXbyID(3);
            GameManager.Instance.bonusCount++;
        }
    }

    IEnumerator LoadLevelAfterSeconds()
    {
        yield return new WaitForSeconds(2);
    }
}
