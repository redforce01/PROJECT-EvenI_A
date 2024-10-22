using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Even
{
    public class InputSystem : MonoBehaviour
    {
        private void Awake()
        {
            // Cursor.lockState = CursorLockMode.None;      // 기본 상태
            // Cursor.lockState = CursorLockMode.Locked;    // 마우스 커서를 잠금/[센터 위치에]
            // Cursor.lockState = CursorLockMode.Confined;  // 마우스 커서를 화면 안에 가둔다.

            Cursor.visible = false;
            Cursor.lockState = CursorLockMode.Locked;
        }

        private void Update()
        {
            SetVisibleCursor(Input.GetKey(KeyCode.LeftAlt));
        }

        private void SetVisibleCursor(bool isVisible)
        {
            Cursor.visible = isVisible;
            Cursor.lockState = isVisible ? CursorLockMode.None : CursorLockMode.Locked;
        }
    }
}
