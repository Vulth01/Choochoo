using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManger : MonoBehaviour
{
    Rigidbody ballBody;
    float startSpeed = 500;
    GameObject ball;
    public Transform ballStartPoint;
    // Start is called before the first frame update
    void Start()
    {
        ballBody = ball.GetComponent<Rigidbody>();
        StartCoroutine(GameStartup());
    }

    // Update is called once per frame
    void Update()
    {
        if (ballBody.transform.position.y < -5)
        {


        }
    }
    IEnumerator GameStartup()
    {
        Instantiate(ball, ballStartPoint);
        yield return new WaitForSeconds(1);
        Debug.Log("3");
        yield return new WaitForSeconds(1);
        Debug.Log("2");

        yield return new WaitForSeconds(1);
        Debug.Log("1");
        yield return new WaitForSeconds(1);
        Debug.Log("start");

        ballBody.AddForce(new Vector3(0, 0, -startSpeed));

    }

}
