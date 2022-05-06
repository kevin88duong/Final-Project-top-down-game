using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FireSnake_Ranged : EnemyClass
{
    public float attackDistance;
    private float attackTime_enemy;
    public Animator animator;
    public Transform FireballPoint;
    public GameObject FireBall;



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
                if (Time.time >= attackTime_enemy)
                {
                    attackTime_enemy = Time.time + attackSpeed_enemy;
                    animator.SetTrigger("Attack");
                }
            }
        }
    }

    public void RangedAttack()
    {
        Vector2 direction = Player.position - FireballPoint.position;
        float angleZ = Mathf.Atan2(direction.y, direction.x) * Mathf.Rad2Deg;
        Quaternion angleHolder = Quaternion.Euler(0f, 0f, angleZ);
        FireballPoint.rotation = angleHolder;
        Instantiate(FireBall, FireballPoint.position, FireballPoint.rotation);
    }

    public void hitAnim_FireSnake()
    {
        animator.SetTrigger("Hit");
    }
}
