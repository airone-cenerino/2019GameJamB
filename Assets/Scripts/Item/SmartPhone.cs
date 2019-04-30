using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Item
{
    public class SmartPhone : ItemBase
    {
        public override void Use()
        {
            Destroy(gameObject);
        }
        // Start is called before the first frame update
        void Start()
        {

        }

        // Update is called once per frame
        void Update()
        {

        }
    }
}
