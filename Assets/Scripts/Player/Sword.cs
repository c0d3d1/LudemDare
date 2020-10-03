using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Sword : MonoBehaviour
{
    public Animator anim;
    private BoxCollider2D bc;
    // Start is called before the first frame update
    void Start()
    {
        bc = GetComponent<BoxCollider2D>();
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            bc.enabled = true;
            anim.SetTrigger("SwordSlash");
        }
    }

    public void SwordEnd() 
    {
        bc.enabled = false;
        anim.SetTrigger("SwordEnd");
    }
}
