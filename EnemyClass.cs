using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class EnemyClass : MonoBehaviour
{
    public int Damage;
    public float Health;
    public GameObject DmgNumb_normal;
    public GameObject DmgNumb_crit;
    public GameObject DmgNumb_resist;
    [HideInInspector]
    public Transform Player;
    public float speed;
    public float attackSpeed_enemy;
    public GameObject effect;
    public int dropChance;
    public GameObject[] drops;

    
  
    private void Start()
    {
        
        
        Player = GameObject.FindGameObjectWithTag("Player").transform;
        
       
    }

    
    public void takeDmaage(int damageNumber)
    {
      
        Health -= damageNumber;
        GameObject dmgNumb =  Instantiate(DmgNumb_normal, transform.position, Quaternion.identity) as GameObject;
        dmgNumb.transform.GetChild(0).GetComponent<TextMesh>().text = damageNumber.ToString();
        if (Health <= 0)
        {
            int randNumb = Random.Range(0, 101);
            if (randNumb < dropChance)
            {
                GameObject ranDrop = drops[Random.Range(0, drops.Length)];
                Instantiate(ranDrop, transform.position, transform.rotation);
            }
            
            FindObjectOfType<TimeStop>().timeStop(0.1f);
            StartCoroutine(waitForTime());
            
        }
    }
    public void takeDmaage_crit(int damageNumber)
    {

        Health -= damageNumber;
        GameObject dmgNumb = Instantiate(DmgNumb_crit, transform.position, Quaternion.identity) as GameObject;
        dmgNumb.transform.GetChild(0).GetComponent<TextMesh>().text = damageNumber.ToString() + "!";
        if (Health <= 0)
        {
            int randNumb = Random.Range(0, 101);
            if (randNumb < dropChance)
            {
                GameObject ranDrop = drops[Random.Range(0, drops.Length)];
                Instantiate(ranDrop, transform.position, transform.rotation);
            }
            
            FindObjectOfType<TimeStop>().timeStop(0.1f);
            StartCoroutine(waitForTime());

        }
    }
    public void takeDmaage_resist(int damageNumber)
    {

        Health -= damageNumber;
        GameObject dmgNumb = Instantiate(DmgNumb_resist, transform.position, Quaternion.identity) as GameObject;
        dmgNumb.transform.GetChild(0).GetComponent<TextMesh>().text = damageNumber.ToString();
        if (Health <= 0)
        {
            int randNumb = Random.Range(0, 101);
            if (randNumb < dropChance)
            {
                GameObject ranDrop = drops[Random.Range(0, drops.Length)];
                Instantiate(ranDrop, transform.position, transform.rotation);
            }
            
            FindObjectOfType<TimeStop>().timeStop(0.1f);
            StartCoroutine(waitForTime());

        }
    }



    IEnumerator waitForTime()
    {
        while (Time.timeScale != 1.0f)
        {
            yield return null;
        }
        Instantiate(effect, transform.position, Quaternion.identity);
        Destroy(gameObject);
    }
}
