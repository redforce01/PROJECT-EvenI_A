using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Even
{
    public class InputSystem : MonoBehaviour
    {
        private void Awake()
        {
            // Cursor.lockState = CursorLockMode.None;      // �⺻ ����
            // Cursor.lockState = CursorLockMode.Locked;    // ���콺 Ŀ���� ���/[���� ��ġ��]
            // Cursor.lockState = CursorLockMode.Confined;  // ���콺 Ŀ���� ȭ�� �ȿ� ���д�.

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
