using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RandomSky : MonoBehaviour
{
    public Material[] mat;

    void Start()
    {
        int random = Random.Range(0, mat.Length);
        RenderSettings.skybox = mat[random];
    }

    void Update()
    {
        RenderSettings.skybox.SetFloat("_Rotation", -0.75f * Time.time);
    }

}
