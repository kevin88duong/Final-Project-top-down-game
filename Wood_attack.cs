using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Wood_attack : PlayerCombatStats
{
    private Vector2 mousePos;
    public Camera gameCam;
    public Rigidbody2D rb;
    public GameObject Wood_attack_obj;
    private float shotCD;
    public float timeUntillShot;
    private Quaternion angleHolder;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        

        if (shotCD <= 0)
        {
            if (Input.GetKeyDown(KeyCode.Q))
            {

                GameObject projectile = Instantiate(Wood_attack_obj, mousePos, angleHolder);
                shotCD = timeUntillShot;

            }
        }
        else
        {
            shotCD -= Time.deltaTime;
        }
        mousePos = gameCam.ScreenToWorldPoint(Input.mousePosition);
    }
}
