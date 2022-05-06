using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Martial_player : MonoBehaviour
{
    public float moveSpeed;
    public Rigidbody2D rb;
    private Vector2 Direction;
    bool facingRignt = true;
    public Animator animator;
    void Update()
    {
        // gets the value of the axis which is in the brackets
        float movementX = Input.GetAxisRaw("Horizontal");
        float movementY = Input.GetAxisRaw("Vertical");
        //creating a new vector which has the values obatained
        Direction = new Vector2(movementX, movementY).normalized;

        //Setting speed to let the running animation play // Used MathF.Abs because the two movement variables would return -1 when moving backwards, so this function returns a positive value
        animator.SetFloat("Speed", Mathf.Abs(movementX) + Mathf.Abs(movementY));


        if (movementX < 0 && facingRignt)
        {
            Flip();
        }
        else if (movementX > 0 && !facingRignt)
        {
            Flip();
        }

    }

    // Update is called once per frame
    void FixedUpdate()
    {
        //dealing with the movespeed


        if (Input.GetKey(KeyCode.LeftShift))
        {
            rb.velocity = new Vector2(Direction.x * (moveSpeed + 2), Direction.y * (moveSpeed + 2));

        }
        else
        {
            rb.velocity = new Vector2(Direction.x * moveSpeed, Direction.y * moveSpeed);
        }

    }

    void Flip()
    {
        facingRignt = !facingRignt;
        transform.Rotate(0f, 180f, 0f);
    }
}