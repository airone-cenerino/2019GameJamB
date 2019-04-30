using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR;

namespace Player
{
    public class PlayerController : MonoBehaviour
    {
        private Camera m_camera;
        private Vector3 center;
        private Material mat;
        private Shader bright;
        private Shader standard;
        private bool reset = false;
        // Start is called before the first frame update
        void Start()
        {
            m_camera = Camera.main;
            bright = Shader.Find("Custom/bright");
            standard = Shader.Find("Standard");
#if UNITY_STANDALONE
            center = new Vector3(Screen.width / 2, Screen.height / 2);
#elif UNITY_WSA
            center = new Vector3(XRSettings.eyeTextureWidth * 3, XRSettings.eyeTextureHeight * 2.5f);
#endif
        }

        // Update is called once per frame
        void Update()
        {
            // 画面の中心にレイを飛ばす
            Ray ray = m_camera.ScreenPointToRay(center);
            RaycastHit hit;
            if (Physics.Raycast(ray, out hit, 100f) && (hit.collider.gameObject.CompareTag("Item")|| hit.collider.gameObject.CompareTag("Door")))
            {
                Debug.Log(hit);

                // アイテムに対する処理を書く
                if (hit.collider.gameObject.CompareTag("Door"))
                {
                    mat = hit.collider.transform.parent.gameObject.GetComponent<Renderer>().material;
                }
                else
                {
                    mat = hit.collider.gameObject.GetComponent<Renderer>().material;
                }
                mat.shader = bright;

                if (Input.GetMouseButtonDown(0) || Input.GetKeyDown("joystick button 15"))
                {
                    if (hit.collider.gameObject.CompareTag("Door"))
                    {
                        hit.collider.transform.parent.gameObject.GetComponent<Item.ItemBase>().Use();
                    }
                    else
                    {
                        hit.collider.gameObject.GetComponent<Item.ItemBase>().Use();
                    }
                }


                reset = true;
            }
            else if (reset)
            {
                mat.shader = standard;
                reset = false;
            }
        }
    }
}
