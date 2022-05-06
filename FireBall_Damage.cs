using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FireBall_Damage : MonoBehaviour
{
    private Transform Player;
    private Vector2 playerPostition;
    public float speed;
    public int damage;
    public GameObject fireball_explosion;
    private void Start()
    {
        Player = GameObject.FindGameObjectWithTag("Player").transform;
        playerPostition = Player.transform.position;
    }

    private void Update()
    {
        
        if(Vector2.Distance(transform.position, playerPostition) > 0.1f)
        {
            transform.position = Vector2.MoveTowards(transform.position, playerPostition, speed * Time.deltaTime);
        }
        else
        {
            Destroy(gameObject);
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        GameObject explosion =  Instantiate(fireball_explosion, transform.position, Quaternion.identity);
        Destroy(explosion, 2f);
        if(Player != null)
        {
            if (collision.tag == "Player")
            {
                Player.GetComponent<PlayerCombatStats>().takeDmaage(damage);
               
                Destroy(gameObject);
            }
        }
        
    }
}
