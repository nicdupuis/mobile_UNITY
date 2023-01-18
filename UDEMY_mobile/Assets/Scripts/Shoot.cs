using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class Shoot : MonoBehaviour
{

    public RectTransform powerBar;
    bool powerActivated = false;
    public GameObject balle;
    bool canShoot = true;
    public int shootPowerMultiplier;
    bool canCheckSpeed = false;
    public int nbShots = 0;
    public GameObject guide;


void Update()
{
    if(Input.GetMouseButtonUp(1))
    {
        HandleShoot();
    }

    if(balle.GetComponent<Rigidbody>().velocity.magnitude < 0.2f && canCheckSpeed)
    {
        canShoot = true;
        GetComponent<Button>().interactable = canShoot;
    }
}

    public void HandleShoot()
    {
        if(canShoot)
        {
            if(!powerActivated)
            {
                guide.SetActive(true);
                ActivatePowerBar();
            }
            else{
                canShoot = false;
                GetComponent<Button>().interactable = canShoot;
                nbShots++;
                guide.SetActive(false);
                ShootBall();
            }
        }     
    }

    public void ActivatePowerBar()
    {
        SFXMgr.Instance.PlaySFXbyID(4);
        powerActivated = true;
        StartCoroutine("AnimatePowerBar");
    }

    public void ShootBall()
    {
        SFXMgr.Instance.PlaySFXbyID(1);
        powerActivated = false;
        StopAllCoroutines();
        float shootPower = powerBar.localScale.x * shootPowerMultiplier;
        balle.GetComponent<Rigidbody>().AddForce(Camera.main.transform.forward * shootPower);
        StartCoroutine("ActivateSpeedCheck");
    }

    IEnumerator AnimatePowerBar()
    {
        float val = 0.1f;
        while(powerActivated)
        {
            yield return new WaitForSeconds(0.15f);
            powerBar.localScale = new Vector3(powerBar.localScale.x - val, powerBar.localScale.y, powerBar.localScale.z);
            if(powerBar.localScale.x < 0.2f)
            {
                val = -0.1f;
            }
            if(powerBar.localScale.x > 0.9f)
            {
                val = 0.1f;
            }
        }
    }

    IEnumerator ActivateSpeedCheck()
    {
        yield return new WaitForSeconds(1);
        canCheckSpeed = true;
    }
}
