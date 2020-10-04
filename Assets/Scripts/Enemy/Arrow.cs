using DitzeGames.Effects;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Arrow : MonoBehaviour
{
    public float speed;

    [SerializeField] private Transform player;
    [SerializeField] private Vector2 target;

    private bool destroying = false;

    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player").transform;

        target = new Vector2(player.position.x, player.position.y);
        float angle = 0;

        Vector3 relative = transform.InverseTransformPoint(GameObject.FindGameObjectWithTag("Player").transform.position);
        angle = Mathf.Atan2(relative.x, relative.y) * Mathf.Rad2Deg;
        transform.Rotate(0, 0, -angle + 45);
    }

    void Update()
    {
        if (!destroying)
        {
            transform.position = Vector2.MoveTowards(transform.position, target, speed * Time.deltaTime);
        }
        

        if (transform.position.x == target.x && transform.position.y == target.y)
        {
            DestroyProjectile();
        }
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player") && !destroying)
        {
            CameraShake.ShakeOnce(0.2f, 2.5f);
            GameObject.Find("Health").GetComponent<Health>().takeDamage();
            Destroy(gameObject);
            // damage player
        }
    }

    void DestroyProjectile() 
    {
        destroying = true;
        Destroy(gameObject, 4);
    }
}
