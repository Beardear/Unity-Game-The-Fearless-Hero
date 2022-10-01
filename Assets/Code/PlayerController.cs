using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Platformer
{
    public class PlayerController : MonoBehaviour
    {
        void Start()
        {

        }

        // Update is called once per frame
        void Update()
        {
            if (Input.GetKey(KeyCode.W))
                transform.position += new Vector3(0, 0.01f, 0);
            if (Input.GetKey(KeyCode.S))
                transform.position += new Vector3(0, -0.01f, 0);
            if (Input.GetKey(KeyCode.A))
                transform.position += new Vector3(-0.01f, 0, 0);
            if (Input.GetKey(KeyCode.D))
                transform.position += new Vector3(0.01f, 0, 0);
        }
    }

}