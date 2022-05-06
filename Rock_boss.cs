using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Rock_boss : EnemyClass
{
    public float attackDistance;
    public Animator animator;
    private float attackTime_enemy;
    public Transform Rock_hitbox;
    public float attackRange_Rock;
    public float attackDistance_ranged;
    public Transform Rock_proj_start;
    public GameObject Rock_proj;
    public EnemyClass[] enemies;
    public float spawnOffset;
    public LayerMask playerLayer;
    // Start is called before the first frame update
    
    // Update is called once per frame
    void Update()
    {

        if (Player != null)
        {

            int randNumb = Random.Range(0, 11);
            if (randNumb < 7)
            {
                if (Vector2.Distance(transform.position, Player.position) > attackDistance)
                {
                    transform.position = Vector2.MoveTowards(transform.position, Player.position, speed * Time.deltaTime);
                }
                else
                {
                    if (Time.time >= attackTime_enemy)
                    {
                        animator.SetTrigger("Attack");
                        attackTime_enemy = Time.time + attackSpeed_enemy;
                    }
                }
            }
            if (randNumb >= 8)
            {
                if (Vector2.Distance(transform.position, Player.position) > attackDistance_ranged)
                {
                    transform.position = Vector2.MoveTowards(transform.position, Player.position, speed * Time.deltaTime);

                }
                else
                {
                    if (Time.time >= attackTime_enemy)
                    {
                        animator.SetTrigger("Ranged");
                        attackTime_enemy = Time.time + attackSpeed_enemy;
                    }
                }
            }



        }
    }

    void Attack_Rock_Melee()
    {
        
        Collider2D[] PlayerHit = Physics2D.OverlapCircleAll(Rock_hitbox.position, attackRange_Rock, playerLayer);

        foreach (Collider2D player in PlayerHit)
        {
            if (Player != null)
            {
                player.GetComponent<PlayerCombatStats>().takeDmaage(Damage);
               
            }
        }
    }

    void Attack_Rock_Ranged()
    {
        
        Vector2 direction = Player.position - Rock_proj_start.position;
        float angleZ = Mathf.Atan2(direction.y, direction.x) * Mathf.Rad2Deg;
        Quaternion angleHolder = Quaternion.Euler(0f, 0f, angleZ);
        Rock_proj_start.rotation = angleHolder;
        Instantiate(Rock_proj, Rock_proj_start.position, Rock_proj_start.rotation);
    }
    void OnDrawGizmosSelected()
    {
        Gizmos.DrawSphere(Rock_hitbox.position, attackRange_Rock);
    }

    public void rock_takeDamage(float amount)
    {
        Health -= amount;
        GameObject dmgNumb = Instantiate(DmgNumb_normal, transform.position, Quaternion.identity) as GameObject;
        dmgNumb.transform.GetChild(0).GetComponent<TextMesh>().text = amount.ToString();
        if (Health <= 0)
        {
            Destroy(this.gameObject);
            SceneManager.LoadScene("Win");
        }

        EnemyClass random = enemies[Random.Range(0, enemies.Length)];
        Instantiate(random, transform.position + new Vector3(spawnOffset, spawnOffset, 0), transform.rotation);
    }
    public void rock_takeDamage_crit(float amount)
    {
        Health -= amount;
        GameObject dmgNumb = Instantiate(DmgNumb_crit, transform.position, Quaternion.identity) as GameObject;
        dmgNumb.transform.GetChild(0).GetComponent<TextMesh>().text = amount.ToString();
        if (Health <= 0)
        {
            Destroy(this.gameObject);
            SceneManager.LoadScene("Win");
        }

        EnemyClass random = enemies[Random.Range(0, enemies.Length)];
        Instantiate(random, transform.position + new Vector3(spawnOffset, spawnOffset, 0), transform.rotation);
    }
    public void rock_takeDamage_resist(float amount)
    {
        Health -= amount;
        GameObject dmgNumb = Instantiate(DmgNumb_resist, transform.position, Quaternion.identity) as GameObject;
        dmgNumb.transform.GetChild(0).GetComponent<TextMesh>().text = amount.ToString();
        if (Health <= 0)
        {
            Destroy(this.gameObject);
            SceneManager.LoadScene("Win");
        }

        EnemyClass random = enemies[Random.Range(0, enemies.Length)];
        Instantiate(random, transform.position + new Vector3(spawnOffset, spawnOffset, 0), transform.rotation);
    }
}
