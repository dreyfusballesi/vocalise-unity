using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FormantSender : MonoBehaviour
{
    public LibPdInstance vocaliseInstance;

    public void SendFormant(int index, float frequency, float bandwidth, float amplitude)
    {
        SendFormantToVocalise(index, frequency, bandwidth, amplitude);
    }

    private void SendFormantToVocalise(int index, float frequency, float bandwidth, float amplitude)
    {
        float[] formantList = {index, frequency, bandwidth, amplitude};
        vocaliseInstance.SendList("formant", formantList);
    }
}