using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using GameSystem;

namespace Item
{
    public class LightController : MonoBehaviour
    {
        GameObject canvas;
        bool flg = true;

        private void Start()
        {
            canvas = GameObject.FindGameObjectWithTag("Letter");
        }

        // Update is called once per frame
        void Update()
        {
            if (TextScroll.IsReadFinish && flg)
            {
                this.GetComponent<Light>().intensity = 0.2f;
                flg = false;
            }
        }
    }
}