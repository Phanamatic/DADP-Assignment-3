using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;

public class FindAudioListeners : Editor
{
    [MenuItem("Tools/Find All Audio Listeners")]
    public static void FindListeners()
    {
        AudioListener[] listeners = GameObject.FindObjectsOfType<AudioListener>();
        foreach(AudioListener listener in listeners)
        {
            Debug.Log(listener.gameObject.name, listener.gameObject);
        }
    }
}
