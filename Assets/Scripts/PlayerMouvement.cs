using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMouvement : MonoBehaviour
{
    public CharacterController controller;

    public float speed = 12f;
    public float speedCrouch = 5f;
    public float gravity = -103f;
    public float jumpHeight = 3f;

    public Transform groundCheck;
    public float groundDistance = 0.4f;
    public LayerMask groundMask;

    Vector3 velocity;
    bool isGrounded;

    CharacterController playerCollider;
    float originalHeight;
    public float reduceHeight;

    // Start is called before the first frame update
    void Start()
    {
        playerCollider = GetComponent<CharacterController>();
        originalHeight = playerCollider.height;
    }

    // Update is called once per frame
    void Update()
    {
        isGrounded = Physics.CheckSphere(groundCheck.position, groundDistance, groundMask);

        if(isGrounded && velocity.y < 0)
        {
            velocity.y = -2f;
        }

        float x = Input.GetAxis("Horizontal");
        float z = Input.GetAxis("Vertical");

        Vector3 move = transform.right * x + transform.forward * z;

        

        if(Input.GetButtonDown("Jump") && isGrounded)
        {
            velocity.y = Mathf.Sqrt(jumpHeight * -2f * gravity);
        }

        velocity.y += gravity * Time.deltaTime;

        controller.Move(velocity * Time.deltaTime);


        //-------------------S'accroupir----------------//

        if (Input.GetKeyDown(KeyCode.LeftControl))
        {
            Crouching();
            controller.Move(move * speedCrouch * Time.deltaTime);
        }

        else if (Input.GetKeyUp(KeyCode.LeftControl))
            UnCrouching();
        else
            controller.Move(move * speed * Time.deltaTime);
    }

    void Crouching()
    {
        playerCollider.height = reduceHeight;
    }

    void UnCrouching()
    {
        playerCollider.height = originalHeight;
    }
}
