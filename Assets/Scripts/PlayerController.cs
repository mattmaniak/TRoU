using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public float maxSpeed = 0.2f;

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
    }

    void ControlByKeyboard()
    {
        if (Input.GetKey("w"))
        {
            transform.position += transform.TransformDirection(Vector3.forward)
                                  * Time.deltaTime * maxSpeed;
        }
        else if (Input.GetKey("s"))
        {
            transform.position += transform.TransformDirection(Vector3.back)
                                  * Time.deltaTime * maxSpeed;
        }
        
        if (Input.GetKey("a"))
        {
            transform.position += transform.TransformDirection(Vector3.left)
                                  * Time.deltaTime * maxSpeed;
        }
        else if (Input.GetKey("d"))
        {
            transform.position += transform.TransformDirection(Vector3.right)
                                  * Time.deltaTime * maxSpeed;
        }
        if (Input.GetKey("space"))
        {
            transform.position += transform.TransformDirection(Vector3.up)
                                  * Time.deltaTime * maxSpeed;
        }
        if (Input.GetKey("escape"))
        {
            Application.Quit();
        }
    }
}
