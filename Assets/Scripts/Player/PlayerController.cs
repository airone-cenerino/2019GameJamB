﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    private Camera m_camera;
    Vector3 center;
    // Start is called before the first frame update
    void Start()
    {
        m_camera = Camera.main;
        center = new Vector3(Screen.width / 2, Screen.height / 2);
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            // 画面の中心にレイを飛ばす
            Ray ray = m_camera.ScreenPointToRay(center);
            RaycastHit hit;
            if(Physics.Raycast(ray,out hit, 1000f))
            {
                // アイテムに対する処理を書く
            }

        }
    }
}
