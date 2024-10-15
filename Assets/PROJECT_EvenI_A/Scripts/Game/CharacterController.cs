using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Even
{
    public class CharacterController : MonoBehaviour
    {
        // => WASD => �����¿� �̵�
        // => WASD Ű�� �����°�? �˾ƿ��� ���
        // => Ű�� �����ٸ� ĳ���͸� �����δ�.
        // => ĳ���͸� �����δ� : character(GameObject)�� transform �� �����δ�.

        public float speed = 3.0f;
        public float walkSpeed = 2.0f;
        public float runSpeed = 7.0f;
        public bool isRunning = false;

        // C#������ ���������ڰ� �տ� �����Ǿ������� => private
        void Update()
        {
            isRunning = Input.GetKey(KeyCode.LeftShift);

            // Vector 2 : x, y ���� ����ִ� ����ü
            Vector2 input = new Vector2();
            if (Input.GetKey(KeyCode.W))
            {
                input.y += 1;
            }

            if (Input.GetKey(KeyCode.S))
            {
                input.y -= 1;
            }

            if (Input.GetKey(KeyCode.A))
            {
                input.x -= 1;
            }

            if (Input.GetKey(KeyCode.D))
            {
                input.x += 1;
            }

            Vector3 movement = new Vector3();

            speed = isRunning ? runSpeed : walkSpeed;
            movement.x = input.x * speed * Time.deltaTime;
            movement.z = input.y * speed * Time.deltaTime;

            float mouseX = Input.GetAxis("Mouse X");
            transform.rotation = Quaternion.Euler(0, transform.rotation.eulerAngles.y + mouseX, 0);
            transform.Translate(movement);
        }
    }
}

