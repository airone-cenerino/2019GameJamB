using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

namespace GameSystem
{
    public class GoalManager : MonoBehaviour
    {
        public void OnTriggerEnter(Collider other)
        {
            if (other.tag == "Player" && TextScroll.IsReadFinish)
            {
                SceneManager.LoadScene("Epilogue");
            }
        }
    }
}