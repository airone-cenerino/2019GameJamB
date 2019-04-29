using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

namespace System
{
    public class GoalManager : MonoBehaviour
    {
        public void OnTriggerEnter(Collider other)
        {
            if (other.tag == "Player")
            {
                SceneManager.LoadScene("GameClear");
            }
        }
    }
}