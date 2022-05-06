using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Martial_player_combat : PlayerCombatStats
{

    // Update is called once per frame
    public Animator animator;
    public Animator camAnimator;
    public Transform hitBox_sword;
    public float attackRange = 0.5f;
    public LayerMask enemyLayers;
    public int BaseDamage = 25;
    public int DamageMultiplier = 2;
    public float attackSpeed;
    private float timeB4attacks;
    public GameObject SoundEffect;
    void Update()
    {
        if (timeB4attacks <= 0)
        {
            if (Input.GetKeyDown(KeyCode.Mouse0))
            {
                Attack();
                timeB4attacks = attackSpeed;
            }

        }
        else
        {
            timeB4attacks -= Time.deltaTime;
        }

    }


    void Attack()
    {
        animator.SetTrigger("Attack");
        Instantiate(SoundEffect);
        Collider2D[] enemiesHit = Physics2D.OverlapCircleAll(hitBox_sword.position, attackRange, enemyLayers);

        foreach (Collider2D enemy in enemiesHit)
        {
            if (enemy.tag == "Skeleton_Melee")
            {
                enemy.GetComponent<EnemyClass>().takeDmaage(BaseDamage);
                enemy.GetComponent<Skeleton_Melee>().HitAnim_Skeleton();
                camAnimator.SetTrigger("Shake");
            }
            if (enemy.tag == "FireSnake")
            {
                enemy.GetComponent<EnemyClass>().takeDmaage_resist(BaseDamage/DamageMultiplier);
                enemy.GetComponent<FireSnake_Ranged>().hitAnim_FireSnake();
                camAnimator.SetTrigger("Shake");
            }
            if (enemy.tag == "Rock")
            {

                enemy.GetComponent<Rock_boss>().rock_takeDamage_crit(BaseDamage * DamageMultiplier);
                camAnimator.SetTrigger("Shake");
            }
            if (enemy.tag == "DeathBringer")
            {

                enemy.GetComponent<EnemyClass>().takeDmaage_crit(BaseDamage * DamageMultiplier);
                camAnimator.SetTrigger("Shake");
            }

        }
    }
    void OnDrawGizmosSelected()
    {
        Gizmos.DrawSphere(hitBox_sword.position, attackRange);
    }

}