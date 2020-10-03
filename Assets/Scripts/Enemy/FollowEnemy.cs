using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FollowEnemy : MonoBehaviour
{
    private Vector3 home;
    [SerializeField] private float speed = 5;
    [SerializeField] private float stoppingDistance = 2;
    [SerializeField] private float attackingTime;

    private Transform target;
    // Start is called before the first frame update
    void Start()
    {
        home = transform.position;
        target = GameObject.FindGameObjectWithTag("Player").GetComponent<Transform>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    private void OnTriggerStay2D(Collider2D col)
    {
        if (col.CompareTag("Player"))
        {
            if (Vector2.Distance(transform.position, target.position) > stoppingDistance)
            {
                transform.position = Vector2.MoveTowards(transform.position, target.position, speed * Time.deltaTime);
            }
            else if (Vector2.Distance(transform.position, target.position) < stoppingDistance)
            {
                attackingTime += Time.deltaTime;
                if (attackingTime > 0.5)
                {
                    // Do attack and attack anim
                    attackingTime = 0;
                }
            }
        }
    }
}
