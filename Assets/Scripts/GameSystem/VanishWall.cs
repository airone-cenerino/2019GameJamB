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
            if(LoopManager.loop > 1)
            {
                this.gameObject.SetActive(false);
            }
        }
    }
}