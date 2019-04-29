using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PCScript : Item.ItemBase
{
    private Material mat;
    // Start is called before the first frame update
    void Start()
    {
        mat = GetComponent<Material>();
    }
    public override void Use()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
