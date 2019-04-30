using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Player
{
    public class PlayerMover : MonoBehaviour
    {
        [SerializeField]
        float rotateSpeed = 2.0f;
        public static float moveSpeed;
        public float playerMoveSpeed;
        private Camera m_Camera;
        private CharacterController controller;
        private Quaternion m_CharacterTargetRot;
        private Quaternion m_CameraTargetRot;
        private Vector3 forward, right;
        private Vector3 moveDirection;
        // Start is called before the first frame update
        void Start()
        {
            moveSpeed = playerMoveSpeed;
            controller = GetComponent<CharacterController>();
            m_Camera = Camera.main;
            m_CharacterTargetRot = this.transform.localRotation;
            m_CameraTargetRot = m_Camera.transform.localRotation;
#if UNITY_STANDALONE
            Cursor.lockState = CursorLockMode.Locked;
            Cursor.visible = false;
#endif
        }

        // Update is called once per frame
        void Update()
        {
#if UNITY_STANDALONE
            this.transform.rotation *= Quaternion.Euler(0, rotateSpeed * Input.GetAxis("Mouse X"), 0);
            m_Camera.transform.rotation *= Quaternion.Euler(-rotateSpeed * Input.GetAxis("Mouse Y"), 0, 0);
#elif UNITY_WSA
            if(Input.GetKeyDown("joystick button 19")){
                UnityEngine.XR.InputTracking.Recenter();
            }
            if(Input.GetKey("joystick button 9"))
            {
                this.transform.rotation *= Quaternion.Euler(0, 2 * rotateSpeed * Input.GetAxis("Touch"), 0);
            }
#endif
            forward = new Vector3(m_Camera.transform.forward.x, 0, m_Camera.transform.forward.z).normalized;
            right = (Input.GetAxis("Horizontal") * m_Camera.transform.right);
            moveDirection = (Input.GetAxis("Vertical") * forward + right).normalized;
            controller.Move(moveSpeed * moveDirection * Time.deltaTime);
            if (Input.GetKeyDown(KeyCode.Escape))
            {
                Cursor.lockState = CursorLockMode.None;
                Cursor.visible = true;
            }
        }
        public void OnTriggerEnter(Collider other)
        {
            if (other.tag == "Books")
            {
                WalkSlowly();   // Enemy一時停止
            }
        }

        public void OnTriggerExit(Collider other)
        {
            if (other.tag == "Books")
            {
                WalkNormally();
            }
        }

        private void WalkSlowly()
        {
            moveSpeed /= 3.0f;
        }

        private void WalkNormally()
        {
            moveSpeed *= 3.0f;
        }
    }
}
