using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FollowPlayer : MonoBehaviour
{
    public  Transform playerTransform;
    
    public float Speed;
    // Start is called before the first frame update
    

    // Update is called once per frame
    void LateUpdate()
    {

        transform.position = playerTransform.position;
        
       

    }
}
