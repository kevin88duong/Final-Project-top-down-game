using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player_0_Combat : PlayerCombatStats
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
    public GameObject SoundEffect;
    private float timeB4attacks;
    public float offset;
    private Vector2 mousePos;
    public Camera gameCam;
    public Rigidbody2D rb;
    private Quaternion angleHolder;
    public GameObject Thunder_BirdShot;
    public Transform Thunder_BirdStart;
    public float Thunder_BirdForce;
    private Vector3 mousePosVec;
    private Vector3 finalVec;
    private float BirdCD;
    public float timeUntillBird;
    public Animator animator_Bird;
    void Update()
    {
        Debug.Log(Health);
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

        if (BirdCD <= 0)
        {
            if (Input.GetKeyDown(KeyCode.Q))
            {
                animator_Bird.SetTrigger("Attack");
                GameObject projectile = Instantiate(Thunder_BirdShot, Thunder_BirdStart.position, angleHolder);
                camAnimator.SetTrigger("Shake");
                projectile.GetComponent<Rigidbody2D>().AddForce(finalVec * Thunder_BirdForce, ForceMode2D.Impulse);
                BirdCD = timeUntillBird;

            }
        }
        else
        {
            BirdCD -= Time.deltaTime;
        }

        mousePos = gameCam.ScreenToWorldPoint(Input.mousePosition);
        mousePosVec = new Vector3(mousePos.x, mousePos.y);
        finalVec = mousePosVec - Thunder_BirdStart.position;
       
        //Debug.Log(Thunder_BirdStart.position);
       

    }


    void Attack()
    {
        animator.SetTrigger("Attack");
        Instantiate(SoundEffect);
        Collider2D[] enemiesHit = Physics2D.OverlapCircleAll(hitBox_sword.position, attackRange, enemyLayers);

        foreach(Collider2D enemy in enemiesHit)
        {
            if (enemy.tag == "Skeleton_Melee")
            {
                enemy.GetComponent<EnemyClass>().takeDmaage_resist(BaseDamage/DamageMultiplier);
                enemy.GetComponent<Skeleton_Melee>().HitAnim_Skeleton();
                camAnimator.SetTrigger("Shake");
            }
            if (enemy.tag == "FireSnake")
            {
                enemy.GetComponent<EnemyClass>().takeDmaage_crit(BaseDamage*DamageMultiplier);
                enemy.GetComponent<FireSnake_Ranged>().hitAnim_FireSnake();
                camAnimator.SetTrigger("Shake");
            }
            if (enemy.tag == "DeathBringer")
            {
                enemy.GetComponent<EnemyClass>().takeDmaage(BaseDamage);
                camAnimator.SetTrigger("Shake");
            }
            if (enemy.tag == "Rock")
            {

                enemy.GetComponent<Rock_boss>().rock_takeDamage(BaseDamage);
                camAnimator.SetTrigger("Shake");
            }

        }
    }
    void OnDrawGizmosSelected()
    {
        Gizmos.DrawSphere(hitBox_sword.position, attackRange);
    }

   

    void FixedUpdate()
    {
        Vector2 aim = mousePos - rb.position;
        float angleZ = Mathf.Atan2(aim.y, aim.x) * Mathf.Rad2Deg + offset;
        angleHolder = Quaternion.Euler(0f, 0f, angleZ);



    }

}
