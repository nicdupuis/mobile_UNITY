using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class CamScript : MonoBehaviour
{
    public GameObject balle;
    public float distance = 3.5f;
    float x = 0f;
    float y = 0f;
    Quaternion rotation;
    Touch touch;

    void Start()
    {
        x = transform.eulerAngles.y;
        y = transform.eulerAngles.x;
    }

    void LateUpdate()
    {
        // Si on est sur PC 
#if UNITY_EDITOR || UNITY_STANDALONE
        x += Input.GetAxis("Mouse X") * 3;
#endif
        // Si on est sur mobile
#if UNITY_ANDROID || UNITY_IPHONE
        if(Input.touches.Length == 1)
        {
            x += Input.GetTouch(0).deltaPosition.x * 0.1f;
        }
#endif

        if(!EventSystem.current.IsPointerOverGameObject())
        {
            rotation = Quaternion.Euler(y, x, 0);
        }

        Vector3 position = rotation * new Vector3(0f, balle.transform.position.y / 3, -distance) + balle.transform.position;

        transform.rotation = rotation;
        transform.position = position;

        if(transform.position.y < 2.5f)
        {
            transform.position = new Vector3(transform.position.x, 2.5f, transform.position.z);
        }
    }
}
