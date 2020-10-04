using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Health : MonoBehaviour
{
    public GameObject[] health;
    public int heartsLeft = 3;

    public void Heal() 
    {
        health[heartsLeft].SetActive(true);
        heartsLeft += 1;
    }
    public void takeDamage() 
    {
        heartsLeft -= 1;
        health[heartsLeft].SetActive(false);
    }
}
