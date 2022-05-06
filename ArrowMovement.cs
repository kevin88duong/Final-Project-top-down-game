using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ArrowMovement : MonoBehaviour
{
    // Start is called before the first frame update
    public Rigidbody2D rb;
    public int BaseDamage = 25;
    private int DamageMultiplier = 2;
    public float lifetime = 2f;
   
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        Destroy(gameObject, lifetime);
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "Skeleton_Melee")
        {
            
            collision.GetComponent<EnemyClass>().takeDmaage_crit(BaseDamage * DamageMultiplier);
            collision.GetComponent<Skeleton_Melee>().HitAnim_Skeleton();
            
        }
        if (collision.tag == "FireSnake")
        {
            
            collision.GetComponent<EnemyClass>().takeDmaage_resist(BaseDamage/DamageMultiplier);
            collision.GetComponent<FireSnake_Ranged>().hitAnim_FireSnake();

        }
        if (collision.tag == "DeathBringer")
        {

            collision.GetComponent<EnemyClass>().takeDmaage(BaseDamage);
            

        }
        if (collision.tag == "Rock")
        {

            collision.GetComponent<Rock_boss>().rock_takeDamage_resist(BaseDamage / 2);

        }

        Destroy(gameObject);
    }
}
