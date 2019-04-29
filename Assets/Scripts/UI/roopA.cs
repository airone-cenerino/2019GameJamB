using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;


public class roopA : MonoBehaviour
{
    public string Prologue;

   public void changeNext()
    {
       if (Time.timeSinceLevelLoad > 6.0f)
        {
            SceneManager.LoadScene("Prologue");
        } 
    }

    // Update is called once per frame
    void Update()
    {
        changeNext();
    }
}
