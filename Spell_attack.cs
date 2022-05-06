using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spell_attack : MonoBehaviour
{
    public int damage;
    public float lifetime = 1.5f;
    private bool Hitted;
    private float timeB4dmg = 1;
    private float dmgCD = 4;
    
    [HideInInspector]
    public Transform Player;
    private void Start()
    {
        Player = GameObject.FindGameObjectWithTag("Player").transform;
    }

    // Update is called once per frame
    void Update()
    {
        Destroy(gameObject, lifetime);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {  
        if (Player != null)
        {
            if ((collision.tag == "Player") && (Hitted == false))
            {
                
                Player.GetComponent<PlayerCombatStats>().takeDmaage(damage);
                Hitted = true;
                damageCD();

            }
        }

    }

    void damageCD()
    {
        if (timeB4dmg <= 0)
        {
            Hitted = false;
            timeB4dmg = dmgCD;
        }
        else
        {
            timeB4dmg -= Time.deltaTime;
        }
    }
}
