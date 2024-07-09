using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class VocaliseController : MonoBehaviour
{
    public float VowelScale;
    public float Loudness;
    public float Pitch;
    public float Frequency;

    private LibPdInstance receiverInstance;

    void Awake() 
    {
        receiverInstance = GetComponent<LibPdInstance>();
        UpdateVowelScale(VowelScale);
        UpdateFrequency(Frequency);
        UpdateLoudness(Loudness);
        UpdatePitch(Pitch);
    }

    public void UpdateVowelScale (float vowelScale) 
    { 
        VowelScale = vowelScale; 
        receiverInstance.SendFloat("vowel", VowelScale);
    }
    public void UpdateLoudness (float loudness) 
    { 
        Loudness = loudness;
        receiverInstance.SendFloat("loudness", Loudness);
    }
    public void UpdatePitch (float pitch) 
    { 
        Pitch = pitch; 
        receiverInstance.SendFloat("pitch", Pitch);
    }
    public void UpdateFrequency (float frequency) 
    {
        Frequency = frequency;
        receiverInstance.SendFloat("frequency", Frequency);
    }

    public void UpdateToggle(bool value)
    {
        receiverInstance.SendFloat("toggle", value ? 1 : 0);
    }
}
