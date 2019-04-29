using System.Collections;
using System.Collections.Generic;
using UnityEngine;

using UnityEngine.SceneManagement;

namespace GameSystem
{
    public class LoopManager : MonoBehaviour
    {
        public static int loop = 1;

        private void Start()
        {
            SceneManager.LoadScene("GameScene");
        }
    }
}