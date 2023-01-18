using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DisableZoom : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        ForceDisable();
    }

    public void ForceDisable()
    {
        StartCoroutine("DisableCam");
    }

    IEnumerator DisableCam()
        {
            yield return new WaitForSeconds(2);
            this.gameObject.SetActive(false);
        }

}
