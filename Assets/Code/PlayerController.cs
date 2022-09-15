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
            if (Input.GetKey(KeyCode.UpArrow))
                transform.position += new Vector3(0, 0.2f, 0);
            if (Input.GetKey(KeyCode.DownArrow))
                transform.position += new Vector3(0, -0.2f, 0);
            if (Input.GetKey(KeyCode.LeftArrow))
                transform.position += new Vector3(-0.2f, 0, 0);
            if (Input.GetKey(KeyCode.RightArrow))
                transform.position += new Vector3(0.2f, 0, 0);
        }
    }
}