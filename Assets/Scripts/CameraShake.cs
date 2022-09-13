using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Random = UnityEngine.Random;

public class CameraShake : MonoBehaviour
{
    private Vector3 originalPos;

    public float lerpTime = 10f;
    public float power;
    public float time;
    
    private void Start()
    {
        originalPos = transform.position;
    }


    private void Update()
    {
        transform.position = Vector3.Lerp(transform.position, originalPos, Time.deltaTime * lerpTime);

        transform.Translate(Vector3.up * Random.Range(-power, power) * Time.deltaTime);
        transform.Translate(Vector3.right * Random.Range(-power, power)* Time.deltaTime);
        transform.Translate(Vector3.forward * Random.Range(-power, power)* Time.deltaTime);

        if (time <= 0f)
        {
            power = Mathf.Lerp(power, 0f, Time.deltaTime * 10f);
            time = 0;
        }

        time -= Time.deltaTime;
    }

    public void screenShake(float intensity, float timer)
    {
        power = intensity;
        time = timer;
    }
}
