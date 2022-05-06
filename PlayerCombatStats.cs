using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class PlayerCombatStats : MonoBehaviour
{
    public int MaxHealth;
    public int Health;
    public healthBar healthBar;

    void Start()
    {
        Health = MaxHealth;
        healthBar.setMaxHealth(MaxHealth);
    }




    public void takeDmaage(int damageNumber)
    {
        Health -= damageNumber;
        if (Health <= 0)
        {
            Destroy(gameObject);
            SceneManager.LoadScene("Lose");
        }
        healthBar.setHealth(Health);
    }
    
    
    public void Heal(int healAmount)
    {
        if (Health + healAmount > 500)
        {
            Health = 500;
        }
        else
        {
            Health += healAmount;
            healthBar.setHealth(Health);
        }
    }
    

}
