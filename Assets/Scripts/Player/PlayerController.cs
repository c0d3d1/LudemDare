using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    Rigidbody2D body;

    float horizontal;
    float vertical;
    float moveLimiter = 0.7f;

    public float runSpeed = 20.0f;

    private Animator anim;

    void Start()
    {
        body = GetComponent<Rigidbody2D>();
        anim = GetComponent<Animator>();
    }

    void Update()
    {

        horizontal = Input.GetAxisRaw("Horizontal");
        vertical = Input.GetAxisRaw("Vertical");
    }

    void FixedUpdate()
    {
        if (horizontal > 0.25 || vertical > 0.25 || horizontal < -0.25 || vertical < -0.25)
        {
            anim.SetBool("Walking", true);
        }
        else if(horizontal < 0.25 && vertical < 0.25 && horizontal > -0.25 && vertical > -0.25)
        {
            anim.SetBool("Walking", false);
        }
        if (horizontal != 0 && vertical != 0) // Check for diagonal movement
        {
            horizontal *= moveLimiter;
            vertical *= moveLimiter;
        }

        body.velocity = new Vector2(horizontal * runSpeed, vertical * runSpeed);
    }
}
