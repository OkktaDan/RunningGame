using System;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.AI;

namespace RunGame
{
    class PlayerMovement : MonoBehaviour
    {
        public float speed;
        private float savedSpeedData;
        public float jumpForce;
        [SerializeField] private bool isJump;
        private float horizontalD;
        private float verticalD;
        private Rigidbody2D rb;
        private Animator animate;
        private bool isAlive;
        private GameManager gManager;

        void Start()
        {   
            gManager = GameManager.Instance;
            rb = gameObject.GetComponent<Rigidbody2D>();
            animate = gameObject.GetComponent<Animator>();

            savedSpeedData = speed;
            isJump = false;

            isAlive = gManager.isPlaying();
            SpawnPlayer();
        }

        void Update()
        {
            horizontalD = Input.GetAxisRaw("Horizontal");
            verticalD = Input.GetAxisRaw("Jump");

            // Debug.Log($"{verticalD} || Force: {Vector2.up}");
            if (!isJump)
            {
                if(verticalD > 0)
                {
                    animate.Play("Jump");
                }
                
                if(horizontalD > 0 && verticalD <= 0)
                {
                    animate.Play("Run");
                    gameObject.transform.rotation = Quaternion.Euler(0,0,0);
                }
                else if(horizontalD < 0 && verticalD <= 0)
                {
                    animate.Play("Run");
                    gameObject.transform.rotation = Quaternion.Euler(0,180,0);
                }
            }
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

            if(!isJump)
            {
                speed = savedSpeedData;
            }
            else
            {
                speed = 4;
            }
        }

        void OnTriggerEnter2D(Collider2D collider)
        {
            if(collider.gameObject.tag == "Platform")
            {
                isJump = false;
                // Debug.Log("OnGround");
            }

            // Player Death
            if(collider.gameObject.tag == "Deathlider")
            {
                Debug.Log("DeadAF");
                isAlive = false;
                gManager.setIsPlaying(isAlive);
                gameObject.SetActive(false);
            }

        }

        void OnTriggerExit2D(Collider2D collider)
        {
            if(collider.gameObject.tag == "Platform")
            {
                isJump = true;
                // Debug.Log("Air");
            }
        }

        public void SpawnPlayer()
        {
            gameObject.SetActive(true);
        }

        public bool IsPlayerAlive()
        {
            return isAlive;
        }
    }
}