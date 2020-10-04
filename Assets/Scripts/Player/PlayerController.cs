using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerController : MonoBehaviour
{
    Rigidbody2D body;

    float horizontal;
    float vertical;
    float moveLimiter = 0.7f;

    public float runSpeed = 20.0f;

    private Animator anim;

    [SerializeField]private Vector3 lastMoveDir;

    public float dashSpeed;


    void Start()
    {
        body = GetComponent<Rigidbody2D>();
        anim = GetComponent<Animator>();

        
    }

    void Update()
    {
        HandleDash();
        HandleHeal();
        horizontal = Input.GetAxisRaw("Horizontal");
        vertical = Input.GetAxisRaw("Vertical");
        
    }
   

    void FixedUpdate()
    {
        if (horizontal > 0.25 || vertical > 0.25 || horizontal < -0.25 || vertical < -0.25)
        {
            anim.SetBool("Walking", true);
        }
        else if (horizontal < 0.25 && vertical < 0.25 && horizontal > -0.25 && vertical > -0.25)
        {
            anim.SetBool("Walking", false);
        }
        if (horizontal != 0 && vertical != 0) // Check for diagonal movement
        {
            horizontal *= moveLimiter;
            vertical *= moveLimiter;
        }
        lastMoveDir = new Vector2(horizontal, vertical).normalized;
        body.velocity = new Vector2(horizontal * runSpeed, vertical * runSpeed);
    }

    private void HandleDash()
    {
            if (Input.GetKeyDown(KeyCode.Space))
            {
                if (GameObject.Find("Slider").GetComponent<Slider>().value >= 10)
                {
                    GameObject.Find("Slider").GetComponent<Slider>().value -= 10;
                    StartCoroutine(DashMove());
                }
            }
    }

    IEnumerator DashMove()
    {
        runSpeed += dashSpeed;
        yield return new WaitForSeconds(.2f);
        runSpeed -= dashSpeed;
    }

    private void HandleHeal()
    {
        if (Input.GetKeyDown(KeyCode.E))
        {
            if (GameObject.Find("Slider").GetComponent<Slider>().value >= 30 
                && GameObject.Find("Health").GetComponent<Health>().heartsLeft < 3)
            {
                GameObject.Find("Health").GetComponent<Health>().Heal();
                GameObject.Find("Slider").GetComponent<Slider>().value -= 30;
            }
            
        }
    }
}
