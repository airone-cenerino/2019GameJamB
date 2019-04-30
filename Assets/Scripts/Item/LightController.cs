using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Item
{
    public class LightController : MonoBehaviour
    {
        LetterController letterController;

        private void Start()
        {
            letterController = GameObject.FindGameObjectWithTag("Letter").GetComponent<LetterController>();
        }

        // Update is called once per frame
        void Update()
        {

        }
    }
}