using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class GyroscopeManager : MonoBehaviour
{
    public Vector2 pitchRange;
    public Vector2 vowelRange;
    public Vector2 loudnessRange;
    public LibPdInstance pdPatch;
    public TextMeshProUGUI tiltText;

    // Start is called before the first frame update
    void Start()
    {
        Input.gyro.enabled = true;
    }

    // Update is called once per frame
    void Update()
    {
        var pitchOut = Remap(Input.gyro.attitude.eulerAngles.x, 0, 360, pitchRange.x, pitchRange.y);
        var vowelOut = Remap(Input.gyro.attitude.eulerAngles.y, 0, 360, vowelRange.x, vowelRange.y);
        var loudnessOut = Remap(Input.gyro.attitude.eulerAngles.z, 0, 360, loudnessRange.x, loudnessRange.y);


        pdPatch.SendFloat("pitch", pitchOut);
        pdPatch.SendFloat("vowel", vowelOut);
        pdPatch.SendFloat("loudness", loudnessOut);;

        Debug.Log("pitch: " + pitchOut);
        Debug.Log("vowel: " + vowelOut);
        Debug.Log("loudness: " + loudnessOut);
        /*
        tiltText.text = "x: " + Input.gyro.rotationRate.x
                    + "\ny: " + Input.gyro.rotationRate.y
                    + "\nz: " + Input.gyro.rotationRate.z;
                    */
    }

    private float Remap(float value, float inputMin, float inputMax, float outputMin, float outputMax)
    {
        var lerped = Mathf.InverseLerp(value, inputMin, inputMax);
        return Mathf.Lerp(lerped, outputMin, outputMax);
    }
}
