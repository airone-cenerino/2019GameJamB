using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Item
{
    public class LetterController : ItemBase
    {
        [SerializeField] private GameObject canvas;

        public override void Use()
        {
            canvas.SetActive(true);
        }
    }
}