using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Formant
{
    public Formant(float frequency, float bandwidth, float amplitude) =>
    (Frequency, Bandwidth, Amplitude) = (frequency, bandwidth, amplitude);

    public Formant(Formant formant) =>
    (Frequency, Bandwidth, Amplitude) = (formant.Frequency, formant.Bandwidth, formant.Amplitude);

    public Formant(float[] formantArray) =>
    (Frequency, Bandwidth, Amplitude) = (formantArray[0], formantArray[1], formantArray[2]);

    public Formant() {}

    public float Frequency {get; set;}
    public float Bandwidth {get; set;}
    public float Amplitude {get; set;}

    public float[] ToArray() 
    {
        /**
        Return an array of three floats for in the order {Frequency, Bandwidth, Amplitude}
        */
        return new float[] {Frequency, Bandwidth, Amplitude};
    }

    public static Formant Blend(Formant formant1, Formant formant2, float weight)
    {
        /** 
        Linearly blend two formants
        */
        var newFormant = new Formant();
        weight = Math.Clamp(weight, 0, 1);
        var f1Mix = 1 - weight;
        var f2Mix = weight;

        newFormant.Frequency = formant1.Frequency * f1Mix + formant2.Frequency * f2Mix;
        newFormant.Bandwidth = formant1.Bandwidth * f1Mix + formant2.Bandwidth * f2Mix;
        newFormant.Amplitude = formant1.Amplitude * f1Mix + formant2.Amplitude * f2Mix;

        return formant1;
    }

    public static float[] ToArray(Formant formant)
    {
        return formant.ToArray();
    }
}

