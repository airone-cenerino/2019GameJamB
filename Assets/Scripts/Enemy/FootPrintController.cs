using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// 足跡にアタッチするスクリプト

namespace Enemy
{
    public class FootPrintController : MonoBehaviour
    {
        [SerializeField] private float destroyTime = 5.0f;


        // Update is called once per frame
        void Update()
        {
            destroyTime -= Time.deltaTime;

            if (destroyTime < 0.0f)
            {
                Destroy(this.gameObject);
            }
        }
    }
}
