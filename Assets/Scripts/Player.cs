using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    private float horizontalMovement;
    private bool pressedJumpButton;
    private bool lookingRight = true;
    private Rigidbody rb;
    private Animator animator;

    [SerializeField] private float speed;
    [SerializeField] private float jumpHeight;

    void Start()
    {
        rb = GetComponent<Rigidbody>();
        animator = GetComponent<Animator>();
    }

    void Update()
    {
        animator.SetFloat("horizontal_movement", Mathf.Abs(horizontalMovement));
    }

    private void FixedUpdate() 
    {
        rb.velocity = new Vector3(horizontalMovement * Time.fixedDeltaTime, rb.velocity.y, rb.velocity.z);
        Move(horizontalMovement * Time.fixedDeltaTime);
    }

    private void Move(float moving) {
        rb.velocity = new Vector3(moving, rb.velocity.y, rb.velocity.z);
        
        if (pressedJumpButton) {
            // Salto
            pressedJumpButton = false;
        }
    }

    public void UpdateMovement(Vector3 direction) 
    {
        horizontalMovement = direction.x * speed;
        if (horizontalMovement > 0 && !lookingRight) Turn();
        else if (horizontalMovement < 0 && lookingRight) Turn();
    }

    public void Jump() {
        pressedJumpButton = true;
    }

    private void Turn() {
        lookingRight = !lookingRight;
        Vector3 rot = transform.eulerAngles;
        rot.y = Mathf.Abs(transform.eulerAngles.y) * -1f;
        
        transform.eulerAngles = rot;
    }
}
