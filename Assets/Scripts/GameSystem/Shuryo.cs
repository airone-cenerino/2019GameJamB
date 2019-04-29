using System.Collections;
//using System.Collections.Ganeric;
using UnityEngine;
using UnityEngine.UI;

public class Shuryo : MonoBehaviour
{
    // Use this for initialization
    public void Quit()
    {
#if UNITY_EDITOR
    UnityEditor.EditorApplication.isPlaying = false;
#elif UNITY_STANDALONE
    UnityEngine.Application.Quit();
#endif
    }
}