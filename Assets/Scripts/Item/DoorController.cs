using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Item
{
    public class DoorController : ItemBase
    {
        [SerializeField] GameObject doorCollider;
        [SerializeField] Animator doorAnimator;
        float time = 2.0f;

        public override void Use()
        {
            doorCollider.SetActive(true);
            doorAnimator.SetTrigger("DoorOpen");
        }

        public void DoorClose()
        {
            doorCollider.SetActive(false);
            doorAnimator.SetTrigger("DoorClose");
        }
    }
}