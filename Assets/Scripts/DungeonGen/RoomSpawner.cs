﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RoomSpawner : MonoBehaviour
{

	public int openingDirection;

	private RoomTemplates templates;
	private int rand;
	public bool spawned = false;

	public float waitTime = 4f;

	void Start()
	{
		Destroy(gameObject, waitTime);
		templates = GameObject.FindGameObjectWithTag("Rooms").GetComponent<RoomTemplates>();
		Invoke("Spawn", 0.2f);
	}


	void Spawn()
	{
		if (spawned == false)
		{
			if (openingDirection == 2)
			{
				// Need to spawn a room with a BOTTOM door.
				rand = Random.Range(0, templates.bottomRooms.Length);
				Instantiate(templates.bottomRooms[rand], transform.position, templates.bottomRooms[rand].transform.rotation);
				spawned = true;
			}
			else if (openingDirection == 1)
			{
				// Need to spawn a room with a TOP door.
				rand = Random.Range(0, templates.topRooms.Length);
				Instantiate(templates.topRooms[rand], transform.position, templates.topRooms[rand].transform.rotation);
				spawned = true;
			}
			else if (openingDirection == 4)
			{
				// Need to spawn a room with a LEFT door.
				rand = Random.Range(0, templates.leftRooms.Length);
				Instantiate(templates.leftRooms[rand], transform.position, templates.leftRooms[rand].transform.rotation);
				spawned = true;
			}
			else if (openingDirection == 3)
			{
				// Need to spawn a room with a RIGHT door.
				rand = Random.Range(0, templates.rightRooms.Length);
				Instantiate(templates.rightRooms[rand], transform.position, templates.rightRooms[rand].transform.rotation);
				spawned = true;
			}
			spawned = true;
		}
	}

	void OnTriggerEnter2D(Collider2D other)
	{
		
		if (other.CompareTag("SpawnPoint"))
		{
			try
			{
				if (!other.GetComponent<RoomSpawner>().spawned && !spawned)
				{
					Instantiate(templates.closedRoom, transform.position, Quaternion.identity);
					Destroy(gameObject);
				}
			}
			catch (System.Exception)
			{
				Destroy(gameObject);
			}
			spawned = true;
			
		}
	}
}
