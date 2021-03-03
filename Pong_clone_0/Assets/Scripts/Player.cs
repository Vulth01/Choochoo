using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    Rigidbody playerRB;


    Rigidbody ballbody;

    public float PlayerSpeed = 100;
    float direction;
    // Start is called before the first frame update
    void Start()
    {
        playerRB = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        direction = Input.GetAxis("Horizontal");

        playerMovement();


    }


    void playerMovement()
    {
        direction *= PlayerSpeed;
        playerRB.velocity = new Vector3(direction, 0, 0);
    }
}
