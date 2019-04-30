using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Item
{
    public class SmartPhone : ItemBase
    {
        public static bool getS = false;
        private Collider collider;
        private Renderer renderer;
        public override void Use()
        {
            collider.enabled = false;
            renderer.enabled = false;
            getS = true;
            Destroy(gameObject);
        }
        // Start is called before the first frame update
        void Start()
        {
            collider = GetComponent<Collider>();
            renderer = GetComponent<Renderer>();
        }

        // Update is called once per frame
        void Update()
        {

        }
    }
}
