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
        private bool IsOpen = false;

        private void Update()
        {

        }

        public override void Use()
        {
            if (!IsOpen)
            {
                doorCollider.SetActive(true);
                doorAnimator.SetTrigger("DoorOpen");
                StartCoroutine("DoorOpenWait");
            }
            else
            {
                DoorClose();
            }
        }

        public void DoorClose()
        {
            doorCollider.SetActive(false);
            doorAnimator.SetTrigger("DoorClose");
            IsOpen = false;
        }

        private IEnumerator DoorOpenWait()
        {
            yield return new WaitForSeconds(1.0f);
            IsOpen = true;
        }
    }
}