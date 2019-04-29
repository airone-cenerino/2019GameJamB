using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PCScript : Item.ItemBase
{
    public Renderer renderer;
    // Start is called before the first frame update
    void Start()
    {
        renderer = GetComponent<Renderer>();
    }
    public override void Use()
    {
       // renderer.material.SetFloat("_EdgeWidth", 10f);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
