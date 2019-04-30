using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Item
{
    public class LetterController : ItemBase
    {
        [SerializeField] private GameObject canvasOnOff;

        public override void Use()
        {
            canvasOnOff.SetActive(true);
        }
    }
}