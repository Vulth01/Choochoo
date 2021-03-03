using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class GameManger : MonoBehaviour
{
    Rigidbody ballBody;
    float startSpeed = 500;
    public GameObject ball;
    public Transform ballStartPoint;
    public Transform goalpost1;
    public Transform goalpost2;
    public TextMeshPro scoreTXT1;
    public TextMeshPro scoreTXT2;

    public int score1 = 0;
    public int score2 = 0;

    // Start is called before the first frame update
    void Start()
    {
        ballBody = ball.GetComponent<Rigidbody>();
        StartCoroutine(GameStartup());
    }

    // Update is called once per frame
    void Update()
    {
        Debug.Log(goalpost1.position.z);
        if (ballBody.transform.position.y < -5)
        {
            restartGame();
            if (ballBody.transform.position.z > goalpost1.position.z)
            {
                score1 += 1;
                scoreTXT1.text = score1.ToString();

            }
            else if (ballBody.transform.position.z < goalpost2.position.z)
            {
                score1 += 1;
                scoreTXT1.text = score1.ToString();
            }

        }


    }
    void restartGame()
    {
        if (ball)
        {
            Destroy(ball);
            StartCoroutine(GameStartup());
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
