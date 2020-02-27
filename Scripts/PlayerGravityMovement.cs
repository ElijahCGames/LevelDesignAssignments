using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerGravityMovement : MonoBehaviour
{

    public float speed = 12;
    public float jumpHeight = 3f;
    public float gravity;
    public float defaultGravity = -9.81f;
    public Transform groundCheck;
    public float groundDistance = 0.4f;
    public CharacterController controller;
    public LayerMask groundMask;
    public GravPush gp;
    float xIn = 0;
    float zIn = 0;

    Vector3 tRight;
    Vector3 tForward;

    Vector3 velocity;
    bool isGrounded;
    // Start is called before the first frame update
    void Start()
    {
        gravity = defaultGravity;
    }

    // Update is called once per frame
    void Update()
    {
        isGrounded = Physics.CheckSphere(groundCheck.position, groundDistance, groundMask);

        if (isGrounded && velocity.y < 0) {
            velocity.y = -2f;
        }

        if (isGrounded) {
            xIn = Input.GetAxis("Horizontal");
            zIn = Input.GetAxis("Vertical");
            tRight = transform.right;
            tForward = transform.forward;
        }

        Vector3 move = tRight * xIn + tForward * zIn;
        if(gp.impact != Vector3.zero) {
            move = new Vector3(move.x * gp.impact.x, move.y * gp.impact.y, move.z * gp.impact.z);
        }
        move.Normalize();
       
        controller.Move(move * speed * Time.deltaTime);
        

        if (Input.GetKey(KeyCode.Space) && isGrounded) {
            velocity.y = Mathf.Sqrt(jumpHeight * -2 * gravity);
        }

        velocity.y += gravity * Time.deltaTime;
        controller.Move(velocity * Time.deltaTime);
    }

    public void GravityChange(float newGrav) {
        gravity = newGrav;
    }
}
