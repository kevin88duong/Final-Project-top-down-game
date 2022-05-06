using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player_Archer_Combat : PlayerCombatStats
{
    // Start is called before the first frame update
    public float offset;
    private Vector2 mousePos;
    public Camera gameCam;
    public Rigidbody2D rb;
    private Quaternion angleHolder;
    public GameObject arrowShot;
    public Transform arrowStart;
    public float arrowForce;
    private Vector3 mousePosVec;
    private Vector3 finalVec;
    private float shotCD;
    public float timeUntillShot;
    public Animator camAnimator;
    public Animator animator;
    public GameObject arrowSFX;
   

    // Update is called once per frame
    void Update()
    {
        Debug.Log(Health);
        if (shotCD <= 0)
        {
            if (Input.GetKeyDown(KeyCode.Mouse0))
            {
                animator.SetTrigger("Attack");
                GameObject projectile = Instantiate(arrowShot, arrowStart.position, angleHolder);
                GameObject SFX = Instantiate(arrowSFX, arrowStart.position, Quaternion.identity);
                Destroy(SFX, 2f);
                camAnimator.SetTrigger("Shake");
                projectile.GetComponent<Rigidbody2D>().AddForce(finalVec * arrowForce, ForceMode2D.Impulse);
                shotCD = timeUntillShot;
                
            }
        }
        else
        {
            shotCD -= Time.deltaTime;
        }
        
            mousePos = gameCam.ScreenToWorldPoint(Input.mousePosition);
            mousePosVec = new Vector3(mousePos.x, mousePos.y);
            finalVec = mousePosVec - arrowStart.position;
            //Debug.Log(arrowStart.position);
            //Debug.Log(mousePosVec);
            
            

    }

   void FixedUpdate()
    {
        Vector2 aim = mousePos - rb.position;
        float angleZ = Mathf.Atan2(aim.y, aim.x) * Mathf.Rad2Deg + offset;
        angleHolder = Quaternion.Euler(0f, 0f, angleZ);

        

    }

    
}
