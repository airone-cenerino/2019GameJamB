using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace GameSystem
{
    public class VanishWall : MonoBehaviour
    {
        // Start is called before the first frame update
        void Start()
        {
        }

        private void Update()
        {
            if (LoopManager.loop > 1 && TextScroll.IsReadFinish)
            {
                this.gameObject.SetActive(false);
            }

        }
    }
}