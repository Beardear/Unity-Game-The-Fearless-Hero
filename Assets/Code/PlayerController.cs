using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Platformer
{
    public class PlayerController : MonoBehaviour
    {
        //Outlet
        Rigidbody2D _rigidbody2D;
        SpriteRenderer sprite;
        Animator animator;

        void Start()
        {
            _rigidbody2D = GetComponent<Rigidbody2D>();
            sprite = GetComponent<SpriteRenderer>();
            animator = GetComponent<Animator>();
        }

        // Update is called once per frame
        void Update()
        {
            animator.SetFloat("Speed", _rigidbody2D.velocity.magnitude);


            if (Input.GetKey(KeyCode.W))
            {
                //transform.position += new Vector3(0, 0.1f, 0);
                _rigidbody2D.AddForce(Vector2.up * 25f * Time.deltaTime, ForceMode2D.Impulse);
            }

            if (Input.GetKey(KeyCode.S))
            {
                //transform.position += new Vector3(0, -0.1f, 0);
                _rigidbody2D.AddForce(Vector2.down * 25f * Time.deltaTime, ForceMode2D.Impulse);
            }

            if (Input.GetKey(KeyCode.A))
            {
                //transform.position += new Vector3(-0.1f, 0, 0);
                _rigidbody2D.AddForce(Vector2.left * 36f * Time.deltaTime, ForceMode2D.Impulse);
                sprite.flipX = true;
            }

            if (Input.GetKey(KeyCode.D))
            {
                //transform.position += new Vector3(0.1f, 0, 0);
                _rigidbody2D.AddForce(Vector2.right * 36f * Time.deltaTime, ForceMode2D.Impulse);
                sprite.flipX = false;
            }

            if (Input.GetMouseButtonDown(0))
            {
                //_rigidbody2D.velocity.Set(0,0);
                //animator.SetFloat("Speed", _rigidbody2D.velocity.magnitude);

                animator.SetTrigger("Attack");
            }
        }

        void FixedUpdate()
        {

        }
    }

}