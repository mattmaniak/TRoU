using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public float maxSpeed = 2;

    private Vector3 _velocity;
    private CharacterController _controller;
    
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        Vector3 deltaTransform = new Vector3(0.0f, 0.0f, 0.0f);

        if (Input.GetKey("w"))
        {
            deltaTransform = transform.TransformDirection(Vector3.forward);
        }
        else if (Input.GetKey("s"))
        {
            deltaTransform = transform.TransformDirection(Vector3.back);
        }
        else if (Input.GetKey("a"))
        {
            deltaTransform = transform.TransformDirection(Vector3.left);
        }
        else if (Input.GetKey("d"))
        {
            deltaTransform = transform.TransformDirection(Vector3.right);
        }
        transform.position += deltaTransform * Time.deltaTime * maxSpeed;

        // Vector3 movementRatio = new Vector3(Input.GetAxis("Horizontal"), 0,
        //                                     Input.GetAxis("Vertical"));

        // _controller.Move(movementRatio * Time.deltaTime);
    }
}
