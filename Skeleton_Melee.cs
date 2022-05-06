using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Skeleton_Melee : EnemyClass
{
    public float attackDistance;
    public Animator animator;
    private  float attackTime_enemy;
    public Transform Skeleton_HitBox;
    public float attackRange_Skeleton;
    public LayerMask playerLayer;

    private void Update()
    {
        
        if (Player != null)
        {
            if(Vector2.Distance(transform.position, Player.position) > attackDistance)
            {
                transform.position = Vector2.MoveTowards(transform.position, Player.position, speed*Time.deltaTime);
                animator.SetTrigger("Walk");
               
            }
            else
            {
                if(Time.time >= attackTime_enemy)
                {
                    animator.SetTrigger("Attack");
                    attackTime_enemy = Time.time + attackSpeed_enemy;
                }
            }
        }
       
    }
    public void Attack_Skeleton()
    {
        
        Collider2D[] PlayerHit = Physics2D.OverlapCircleAll(Skeleton_HitBox.position, attackRange_Skeleton, playerLayer);

        foreach (Collider2D player in PlayerHit)
        {
            if(Player != null)
            {
                player.GetComponent<PlayerCombatStats>().takeDmaage(Damage);
            }
            
            
        }
    }
    void OnDrawGizmosSelected()
    {
        Gizmos.DrawSphere(Skeleton_HitBox.position, attackRange_Skeleton);
    }

    public void HitAnim_Skeleton()
    {
        animator.SetTrigger("Hit");
    }
}
