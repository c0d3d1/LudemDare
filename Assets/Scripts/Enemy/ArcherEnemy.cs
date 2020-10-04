using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ArcherEnemy : MonoBehaviour
{
    public float speed;
    public float stoppingDistance;
    public float retreaDistance;

    private float timeBtwShots = 0;
    public float startTimeBtwShots;


    [SerializeField] private float health = 2;


    public Transform player;
    public GameObject projectile;

    // Start is called before the first frame update
    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player").transform;
        timeBtwShots = 0;
    }
    private void FixedUpdate()
    {
        timeBtwShots += Time.deltaTime;
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
    private void OnTriggerStay2D(Collider2D collision)
    {
        if (Vector2.Distance(transform.position, player.position) > stoppingDistance)
        {
            transform.position = Vector2.MoveTowards(transform.position, player.position, speed * Time.deltaTime);
        }
        else if (Vector2.Distance(transform.position, player.position) > stoppingDistance && Vector2.Distance(transform.position, player.position) > retreaDistance)
        {
            transform.position = this.transform.position;
        }
        else if (Vector2.Distance(transform.position, player.position) > retreaDistance)
        {
            transform.position = Vector2.MoveTowards(transform.position, player.position, -speed * Time.deltaTime);
        }

        if (timeBtwShots >= startTimeBtwShots)
        {
            timeBtwShots = 0;
            Instantiate(projectile, transform.position, Quaternion.identity);
        }
        else
        {
            //timeBtwShots += Time.deltaTime;
        }
    }
}
