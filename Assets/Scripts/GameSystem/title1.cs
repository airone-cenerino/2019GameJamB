using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

namespace GameSystem
{
    public class title1 : MonoBehaviour
    {
        // Use this for initialization
        void Start()
        {

        }

        // Update is called once per frame
        void Update()
        {
            Debug.Log("aaa");
            if (Input.GetMouseButtonDown(0))
            {
                SceneManager.LoadScene("GameScene");
            };
        }
    }
}
