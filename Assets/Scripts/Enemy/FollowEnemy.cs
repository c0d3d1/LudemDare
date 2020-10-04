using DitzeGames.Effects;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class FollowEnemy : MonoBehaviour
{
    private Vector3 home;
    [SerializeField] private float speed = 5;
    [SerializeField] private float stoppingDistance = 2;
    [SerializeField] private float attackingTime;
    [SerializeField] private int health = 4;

    private Transform target;
    // Start is called before the first frame update
    void Start()
    {
        home = transform.position;
        target = GameObject.FindGameObjectWithTag("Player").GetComponent<Transform>();
    }
    private RoomManager rm;
    public void takeDamage(int damage)
    {
        health -= damage;
        if (health <= 0)
        {
            
            //do death fanfare
            GameObject.Find("Slider").GetComponent<Slider>().value += 15;
            rm = GameObject.Find("RoomManager").GetComponent<RoomManager>();
            rm.Enemies.Remove(rm.Enemies[rm.Enemies.Count - 1]);
            Destroy(gameObject);
        }
    }

    private void OnTriggerStay2D(Collider2D col)
    {
        if (col.CompareTag("Player"))
        {
            if (Vector2.Distance(transform.position, target.position) > stoppingDistance)
            {
                transform.position = Vector2.MoveTowards(transform.position, target.position, speed * Time.deltaTime);
            }
            else if (Vector2.Distance(transform.position, target.position) < stoppingDistance + 0.1f)
            {
                attackingTime += Time.deltaTime;
                if (attackingTime > 0.8)
                {
                    // Do attack and attack anim
                    CameraShake.ShakeOnce(0.2f, 2.5f);
                    GameObject.Find("Health").GetComponent<Health>().takeDamage();
                    attackingTime = 0;
                }
            }
        }
    }
}
