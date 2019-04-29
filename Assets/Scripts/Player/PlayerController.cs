using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Player
{
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
            if (Input.GetMouseButtonDown(0) || Input.GetKeyDown("joystick button 15"))
            {
                // 画面の中心にレイを飛ばす
                Ray ray = m_camera.ScreenPointToRay(center);
                RaycastHit hit;
                if (Physics.Raycast(ray, out hit, 100f))
                {
                    // アイテムに対する処理を書く
                    hit.collider.gameObject.GetComponent<Item.ItemBase>().Use();
                }
            }
        }
    }
}
