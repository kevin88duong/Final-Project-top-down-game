using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Rock_Proj_dmg : MonoBehaviour
{
    private Transform Player;
    private Vector2 playerPostition;
    public float speed;
    public int damage;
    // Start is called before the first frame update
    void Start()
    {
        Player = GameObject.FindGameObjectWithTag("Player").transform;
        playerPostition = Player.transform.position;
    }

    // Update is called once per frame
    void Update()
    {
        if (Vector2.Distance(transform.position, playerPostition) > 0.1f)
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
        if (Player != null)
        {
            if (collision.tag == "Player")
            {
                Player.GetComponent<PlayerCombatStats>().takeDmaage(damage);

                Destroy(gameObject);
            }
        }

    }
}
