using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HealthPickup : MonoBehaviour
{
    Transform playerLoc;
    public int healAmount;

    private void Start()
    {
        playerLoc = GameObject.FindGameObjectWithTag("Player").transform;
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.tag == "Player")
        {
            playerLoc.GetComponent<PlayerCombatStats>().Heal(healAmount);
            Destroy(gameObject);
        }
    }

}
