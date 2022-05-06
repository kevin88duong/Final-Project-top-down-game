using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player_ThunderBird_combat : PlayerCombatStats
{
    // Start is called before the first frame update
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
    private float shotCD;
    public float timeUntillShot;
    public Animator camAnimator;

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
                
                GameObject projectile = Instantiate(Thunder_BirdShot, Thunder_BirdStart.position, angleHolder);
                camAnimator.SetTrigger("Shake");
                projectile.GetComponent<Rigidbody2D>().AddForce(finalVec * Thunder_BirdForce, ForceMode2D.Impulse);
                shotCD = timeUntillShot;

            }
        }
        else
        {
            shotCD -= Time.deltaTime;
        }

        mousePos = gameCam.ScreenToWorldPoint(Input.mousePosition);
        mousePosVec = new Vector3(mousePos.x, mousePos.y);
        finalVec = mousePosVec - Thunder_BirdStart.position;
        //Debug.Log(Thunder_BirdStart.position);
        //Debug.Log(mousePosVec);



    }

    void FixedUpdate()
    {
        Vector2 aim = mousePos - rb.position;
        float angleZ = Mathf.Atan2(aim.y, aim.x) * Mathf.Rad2Deg + offset;
        angleHolder = Quaternion.Euler(0f, 0f, angleZ);



    }


}
