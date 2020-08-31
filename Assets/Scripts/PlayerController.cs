using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public float walkSpeed = 1.5f;
    public float runSpeed = 2.5f;
    public float jumpHeight = 1.0f;

    private bool _falling = false;
    private bool _jumping = false;
    private float _jumpTime = 0.0f;
    private Vector3 _velocity;
    private CharacterController _controller;
    
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        ControlByKeyboard();
        SimpleJump();
    }

    void ControlByKeyboard()
    {
        float speed = walkSpeed;

        if (!_jumping && !_falling)
        {
            if (Input.GetKey(KeyCode.LeftShift))
            {
                speed = runSpeed;
            }
            if (Input.GetKey("w"))
            {
                transform.position += transform.TransformDirection(Vector3.forward)
                                    * Time.deltaTime * speed;
            }
            else if (Input.GetKey("s"))
            {
                transform.position += transform.TransformDirection(Vector3.back)
                                    * Time.deltaTime * speed;
            }
            
            if (Input.GetKey("a"))
            {
                transform.position += transform.TransformDirection(Vector3.left)
                                    * Time.deltaTime * speed;
            }
            else if (Input.GetKey("d"))
            {
                transform.position += transform.TransformDirection(Vector3.right)
                                    * Time.deltaTime * speed;
            }
            if (Input.GetKey("space"))
            {
                _jumping = true;
            }
        }
        if (Input.GetKey("escape"))
        {
            Application.Quit();
        }
    }

    void SimpleJump()
    {
        if (_jumping)
        {
            if (transform.position.y < jumpHeight)
            {
                transform.position += transform.TransformDirection(Vector3.up)
                                      * Time.deltaTime * jumpHeight;
            }
            else
            {
                _jumping = false;
                _falling = !_jumping;
            }
        }
        else if (_falling)
        {
            transform.position += transform.TransformDirection(Vector3.down)
                                  * Time.deltaTime * jumpHeight;
            if (transform.position.y <= 0.0f)
            {
                _jumping = _falling = false;
            }
        }
    }
}
