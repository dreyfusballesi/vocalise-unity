using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class VocaliseConsole : MonoBehaviour
{
    private LibPdInstance libPdInstance;
    private void Start() 
    {
        libPdInstance = GetComponent<LibPdInstance>();
        libPdInstance.Bind("pitch-in");
        libPdInstance.Bind("frequency-in");
        libPdInstance.Bind("loudness-in");
        libPdInstance.Bind("vowel-in");
        libPdInstance.Bind("formant-list");
    }
    public void LogPdValue(string name, float value)
    {
        Debug.Log(name + ": " + value);
    }

    public void LogPdList(string name, Object[] list)
    {
        Debug.Log(name + ": " + list);
    }
}
