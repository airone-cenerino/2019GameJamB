using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Player
{
    public class PlayerMover : MonoBehaviour
    {
        [SerializeField]
        float rotateSpeed = 2.0f;
        [SerializeField]
        float moveSpeed = 60f;
        private Camera m_Camera;
        private CharacterController controller;
        private Quaternion m_CharacterTargetRot;
        private Quaternion m_CameraTargetRot;
        private Vector3 forward, right;
        private Vector3 moveDirection;
        // Start is called before the first frame update
        void Start()
        {
            controller = GetComponent<CharacterController>();
            m_Camera = Camera.main;
            m_CharacterTargetRot = this.transform.localRotation;
            m_CameraTargetRot = m_Camera.transform.localRotation;
            Cursor.lockState = CursorLockMode.Locked;
            Cursor.visible = false;
        }

        // Update is called once per frame
        void Update()
        {
#if UNITY_STANDALONE
            this.transform.rotation *= Quaternion.Euler(0, rotateSpeed * Input.GetAxis("Mouse X"), 0);
            m_Camera.transform.rotation *= Quaternion.Euler(-rotateSpeed * Input.GetAxis("Mouse Y"), 0, 0);
#elif UNITY_WSA
            if(Input.GetKeyDown("joystick button 9")){
                UnityEngine.XR.InputTracking.Recenter();
            }
#endif
            forward = new Vector3(m_Camera.transform.forward.x, 0, m_Camera.transform.forward.z).normalized;
            right = (Input.GetAxis("Horizontal") * m_Camera.transform.right);
            moveDirection = (Input.GetAxis("Vertical") * forward + right).normalized;
            controller.SimpleMove(moveSpeed * moveDirection * Time.deltaTime);
            if (Input.GetKeyDown(KeyCode.Escape))
            {
                Cursor.lockState = CursorLockMode.None;
                Cursor.visible = true;
            }
        }
    }
}
