using DitzeGames.Effects;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Sword : MonoBehaviour
{
    public Animator anim;
    private BoxCollider2D bc;
    private LookAtMouse lam;
    private Vector3 tempLocation;
    private bool canSwing = true;
    private bool haveCollided = false;

    // Start is called before the first frame update
    void Start()
    {
        bc = GetComponent<BoxCollider2D>();
        lam = GameObject.Find("MouseRegion").GetComponent<LookAtMouse>();
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            if (canSwing)
            {
                if (lam.direction == 1)
                {
                    //up
                    tempLocation = transform.position;
                    transform.position = transform.position + new Vector3(0, 1.2f, 0);
                    canSwing = false;
                    transform.eulerAngles = new Vector3(
                    transform.eulerAngles.x,
                    transform.eulerAngles.y,
                    transform.eulerAngles.z
                    );
                }
                else if (lam.direction == 0)
                {
                    //right
                    tempLocation = transform.position;
                    transform.position = transform.position + new Vector3(1.2f, 0, 0);
                    canSwing = false;
                    transform.eulerAngles = new Vector3(
                    transform.eulerAngles.x,
                    transform.eulerAngles.y,
                    transform.eulerAngles.z + 270
                    );
                }
                else if (lam.direction == 3)
                {
                    //down
                    tempLocation = transform.position;
                    transform.position = transform.position + new Vector3(0, -1.2f, 0);
                    canSwing = false;
                    transform.eulerAngles = new Vector3(
                    transform.eulerAngles.x,
                    transform.eulerAngles.y,
                    transform.eulerAngles.z + 180
                    );
                }
                else if (lam.direction == 2)
                {
                    //left
                    tempLocation = transform.position;
                    transform.position = transform.position + new Vector3(-1.2f, 0, 0);
                    canSwing = false;
                    transform.eulerAngles = new Vector3(
                    transform.eulerAngles.x,
                    transform.eulerAngles.y,
                    transform.eulerAngles.z + 90
                    );
                }
                bc.enabled = true;
                anim.SetTrigger("SwordSlash");
            }
            
        }
    }

    public void SwordEnd() 
    {
        bc.enabled = false;
        anim.SetTrigger("SwordEnd");
        transform.position = transform.parent.position;
        canSwing = true;
        transform.eulerAngles = new Vector3(0, 0, 0);
        haveCollided = false;
    }

    private void OnTriggerEnter2D(Collider2D col)
    {
        if (col.CompareTag("Enemy") && !haveCollided)
        {
            //damage
            if (col.GetComponent<ArcherEnemy>() ?? null)
            {
                col.GetComponent<ArcherEnemy>().takeDamage(1);
                haveCollided = true;
            }
            else if (col.GetComponent<FollowEnemy>() ?? null)
            {
                col.GetComponent<FollowEnemy>().takeDamage(1);
                haveCollided = true;
            }
            CameraShake.ShakeOnce(0.15f, 2f);
        }
    }
}
