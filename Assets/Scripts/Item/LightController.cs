using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using GameSystem;

namespace Item
{
    public class LightController : MonoBehaviour
    {
        TextScroll textScroll;

        private void Start()
        {
            textScroll = GameObject.FindGameObjectWithTag("Letter").GetComponent<TextScroll>();
        }

        // Update is called once per frame
        void Update()
        {
            if (textScroll.IsReadFinish)
            {
                gameObject.SetActive(false);
            }
        }
    }
}