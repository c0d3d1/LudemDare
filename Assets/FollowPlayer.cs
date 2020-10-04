using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FollowPlayer : MonoBehaviour
{
    private GameObject pc;
    // Start is called before the first frame update
    void Start()
    {
        pc = GameObject.Find("Player");
    }

    // Update is called once per frame
    void Update()
    {
       transform.position = new Vector3(pc.transform.position.x, pc.transform.position.y, -1);
    }
}
