using System;
using Unity.VisualScripting;
using UnityEngine;

namespace RunGame
{
    class PlayerMovement : MonoBehaviour
    {
        public float speed;
        public float jumpForce;
        [SerializeField] private bool isJump;
        private float horizontalD;
        private float verticalD;
        private Rigidbody2D rb;

        void Start()
        {   
            rb = gameObject.GetComponent<Rigidbody2D>();
            isJump = false;
        }

        void Update()
        {
            horizontalD = Input.GetAxisRaw("Horizontal");
            verticalD = Input.GetAxisRaw("Jump");            
        }

        void FixedUpdate()
        {
            if(horizontalD > 0 || horizontalD < 0)
            {
                rb.AddForce(new Vector2(horizontalD * speed, 0), ForceMode2D.Force);
            }

            if(verticalD > 0 && !isJump)
            {
                rb.AddForce(new Vector2(0,verticalD * jumpForce), ForceMode2D.Impulse);
            }
        }

        void OnTriggerEnter2D(Collider2D collider)
        {
            if(collider.gameObject.tag == "Platform")
            {
                isJump = false;
                Debug.Log("OnGround");
            }

            if(collider.gameObject.tag == "Deathlider")
            {
                Debug.Log("DeadAF");
                Destroy(gameObject);
            }

        }

        void OnTriggerExit2D(Collider2D collider)
        {
            if(collider.gameObject.tag == "Platform")
            {
                isJump = true;
                Debug.Log("Air");
            }
        }
    }
}