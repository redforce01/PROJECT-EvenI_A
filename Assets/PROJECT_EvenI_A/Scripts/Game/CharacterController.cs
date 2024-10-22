using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

namespace Even
{
    // 한글로 주석을 적었음.

    public class CharacterController : MonoBehaviour
    {
        // => WASD => 상하좌우 이동
        // => WASD 키를 눌렀는가? 알아오는 방법
        // => 키를 눌렀다면 캐릭터를 움직인다.
        // => 캐릭터를 움직인다 : character(GameObject)의 transform 을 움직인다.

        public float speed = 3.0f;
        public float walkSpeed = 2.0f;
        public float runSpeed = 7.0f;
        public bool isRunning = false;

        public Animator characterAnimator; // 인스펙터창에서 Drag & Drop을 해서 연결시켜줄 예정

        public float maxStamina = 100f;
        public float curStamina = 0f;

        public UnityEngine.UI.Image staminaBar;

        [SerializeField] private float blendSpeed = 10.0f;

        private float horizontalBlend;
        private float verticalBlend;

        private void Awake()
        {
            curStamina = maxStamina;
        }

        // C#에서는 접근한정자가 앞에 생략되어있으면 => private
        void Update()
        {
            staminaBar.fillAmount = curStamina / maxStamina;

            isRunning = Input.GetKey(KeyCode.LeftShift);
            // Vector 2 : x, y 값이 들어있는 구조체
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


            if (isRunning && input.magnitude > 0)
            {
                curStamina -= Time.deltaTime * 10;
            }
            else
            {
                curStamina += Time.deltaTime * 10;
            }


            Vector3 movement = new Vector3();
            speed = isRunning ? runSpeed : walkSpeed;
            movement.x = input.x * speed * Time.deltaTime;
            movement.z = input.y * speed * Time.deltaTime;

            float mouseX = Input.GetAxis("Mouse X");
            transform.rotation = Quaternion.Euler(0, transform.rotation.eulerAngles.y + mouseX, 0);
            transform.Translate(movement);



            horizontalBlend = Mathf.Lerp(horizontalBlend, input.x, Time.deltaTime * blendSpeed);
            verticalBlend = Mathf.Lerp(verticalBlend, input.y, Time.deltaTime * blendSpeed);

            characterAnimator.SetFloat("Speed", input.magnitude > 0 ? (isRunning ? 3.0f : 1.0f) : 0f);
            characterAnimator.SetFloat("Horizontal", horizontalBlend);
            characterAnimator.SetFloat("Vertical", verticalBlend);
        }
    }
}

