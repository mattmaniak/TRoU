using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class PlayerController : MonoBehaviour
{
    public float walkSpeed = 1.5f;
    public float runSpeed = 2.5f;
    public float jumpHeight = 1.0f;
    NavMeshAgent playerMeshAgent;
    static bool _selected = false;

    bool _falling = false;
    bool _jumping = false;
    
    // Start is called before the first frame update
    void Start()
    {
        playerMeshAgent = GetComponent<NavMeshAgent>();
    }

    // Update is called once per frame
    void Update()
    {
        MoveToMouseClick();
    }

    public static bool Selected
    {
        get { return _selected; }

    }
    public static void Select()
    {
        _selected = true;
    }

    public static void Unselect()
    {
        _selected = false;
    }

    void MoveToMouseClick()
    {
        RaycastHit destinationHit;
        
        if (_selected && Input.GetMouseButtonDown(0)
            && Physics.Raycast(Camera.main.ScreenPointToRay(Input.mousePosition),
                               out destinationHit, 10.0f))
        {
            playerMeshAgent.destination = destinationHit.point;
        }
    }
}
