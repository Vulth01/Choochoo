using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Mirror;

public class Player : NetworkBehaviour
{
    public float PlayerSpeed = 10;
    float direction;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        if (hasAuthority)
        {
        
            direction = Input.GetAxis("Horizontal");

            PlayerMovement();

        }
    

    }


    void PlayerMovement()
    {
       
        transform.position = new Vector3((direction * PlayerSpeed) + transform.position.x, transform.position.y, transform.position.z);
    }
}
