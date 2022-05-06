using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Death_bringer_Combat : EnemyClass
{
    public float attackDistance;
    public Animator animator;
    private float attackTime_enemy;
    public Transform Death_bringer_HitBox;
    public float attackRange_Death_bringer;
    public Transform Death_Bringer_Spell_hitbox;
    public GameObject Death_Bringer_Spell;
    public LayerMask playerLayer;

    private void Update()
    {

        if (Player != null)
        {
            if (Vector2.Distance(transform.position, Player.position) > attackDistance)
            {
                transform.position = Vector2.MoveTowards(transform.position, Player.position, speed * Time.deltaTime);
                animator.SetTrigger("Walk");

            }
            else
            {
                int randNumb = Random.Range(0, 11);
                if (Time.time >= attackTime_enemy)
                {
                    if (randNumb < 5)
                    {
                        animator.SetTrigger("Attack");
                        attackTime_enemy = Time.time + attackSpeed_enemy;
                    }
                    if (randNumb >= 5)
                    {
                        animator.SetTrigger("Attack_2");
                        attackTime_enemy = Time.time + attackSpeed_enemy;
                    }
                   
                    
                }
            }
        }

    }
    void Attack_Death_bringer()
    {
       
            Collider2D[] PlayerHit = Physics2D.OverlapCircleAll(Death_bringer_HitBox.position, attackRange_Death_bringer, playerLayer);

            foreach (Collider2D player in PlayerHit)
            {
                if (Player != null)
                {
                    player.GetComponent<PlayerCombatStats>().takeDmaage(Damage);
                    Debug.Log("hit");
                }
            }       
    }

    void Attack_Death_Bringer_Spell()
    {
        Instantiate(Death_Bringer_Spell, Death_Bringer_Spell_hitbox.position, Death_Bringer_Spell_hitbox.rotation);   
    }
    void OnDrawGizmosSelected()
    {
        Gizmos.DrawSphere(Death_bringer_HitBox.position, attackRange_Death_bringer);
    }
}