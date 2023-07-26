using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{

    private Vector3 moveDirection;
    private bool pressedJumpButton;
    private CharacterController controller;
    
    [SerializeField] private float speed;
    [SerializeField] private float gravity;
    [SerializeField] private float jumpHeight;

    // Start is called before the first frame update
    void Start()
    {
        controller = GetComponent<CharacterController>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void Movement(Vector3 direction) 
    {
        // TODO: Revisar movemento con inputactions
        
        if (controller.isGrounded) 
        {
            moveDirection = direction;
            moveDirection *= speed;
            
            if (pressedJumpButton)
            {
                moveDirection.y = jumpHeight;
                pressedJumpButton = false;
            }
        }

        moveDirection.y -= gravity * Time.deltaTime;
        controller.Move(moveDirection * Time.deltaTime);
    }

    public void Jump() {
        pressedJumpButton = true;
    }
}
