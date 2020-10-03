﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RoomManager : MonoBehaviour
{
    [SerializeField] private List<GameObject> Enemies = new List<GameObject>();

    public GameObject[] Doors;

    public bool isPlayerhere = false;

    // Update is called once per frame
    void Update()
    {
        
        if (isPlayerhere && Enemies.Count > 0)
        {
            for (int i = 0; i < Doors.Length; i++)
            {
                Doors[i].SetActive(true);
            }
        }
        else if (Enemies.Count == 0)
        {
            for (int i = 0; i < Doors.Length; i++)
            {
                Doors[i].SetActive(false);
            }
        }
    }

    private void OnTriggerStay2D(Collider2D col)
    {
        if (col.CompareTag("Enemy") && !Enemies.Contains(col.gameObject))
        {
            Enemies.Add(col.gameObject);
        }
        if (col.CompareTag("Player"))
        {
            isPlayerhere = true;
        }
    }
    private void OnTriggerExit2D(Collider2D col)
    {
        if (col.CompareTag("Player"))
        {
            isPlayerhere = false;
        }
    }
}
