using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using Mirror;

public class GameManger : NetworkBehaviour
{

    Rigidbody ballBody;
    float startSpeed = 500;
    public GameObject ball;
    public Transform ballStartPoint;
    public Transform goalpost1;
    public Transform goalpost2;
    public TextMeshProUGUI scoreTXT1;
    public TextMeshProUGUI scoreTXT2;
    GameObject ballInstance;

    public Light MainSpotlight;


    public int score1 = 0;
    public int score2 = 0;


    public GameObject player1Prefab;
    public GameObject player2Prefab;
    // Start is called before the first frame update
    void OnClientConnect()
    {
        if (isClient)
        {
            Debug.Log("p2");
            GameObject player2 = Instantiate(player2Prefab);
            NetworkServer.Spawn(player2.gameObject);
        }



    }
    public override void OnStartServer()
    {

        StartCoroutine(GameStartup());
        if (isServer)
        {
            Debug.Log("p2");
            GameObject player1 = Instantiate(player1Prefab);
            NetworkServer.Spawn(player1.gameObject);

        }

    }

    void Start()
    {



    }

    // Update is called once per frame
    void Update()
    {
        if (!ball || !ballBody)
        {

            return;
        }


        Debug.Log("ballExists");


        if (ballBody.transform.position.y < -5)
        {

            if (ballBody.transform.position.z > goalpost1.position.z)
            {
                score1 += 1;
                scoreTXT1.text = score1.ToString();
                StartCoroutine(FlashLightCoroutine());
            }
            else if (ballBody.transform.position.z < goalpost2.position.z)
            {
                score2 += 1;
                scoreTXT2.text = score2.ToString();
                StartCoroutine(FlashLightCoroutine());
            }

            Object.Destroy(ballInstance.gameObject);
            StartCoroutine(GameStartup());
        }



    }
    float flashIntervals = 0.2f;
    float initialIntensity;
    IEnumerator FlashLightCoroutine()
    {
        initialIntensity = MainSpotlight.intensity;
        Color initialColour = MainSpotlight.color;
        MainSpotlight.color = Color.red;


        yield return new WaitForSeconds(flashIntervals);
        MainSpotlight.color = Color.blue;

        yield return new WaitForSeconds(flashIntervals);
        MainSpotlight.color = Color.green;
        yield return new WaitForSeconds(flashIntervals);
        MainSpotlight.color = Color.magenta;
        yield return new WaitForSeconds(flashIntervals);
        MainSpotlight.color = initialColour;
        MainSpotlight.intensity = initialIntensity * 20;
        yield return new WaitForSeconds(flashIntervals);
        MainSpotlight.color = initialColour;
        MainSpotlight.intensity = initialIntensity;
    }

    IEnumerator GameStartup()
    {
        ballInstance = Instantiate(ball);
        NetworkServer.Spawn(ballInstance.gameObject);
        ballBody = ballInstance.GetComponent<Rigidbody>();

        yield return new WaitForSeconds(1);
        Debug.Log("3");
        yield return new WaitForSeconds(1);
        Debug.Log("2");
        yield return new WaitForSeconds(1);
        Debug.Log("1");
        yield return new WaitForSeconds(1);
        Debug.Log("start");

        RpcShootBall(ballBody);

    }
    [ClientRpc]
    void RpcShootBall(Rigidbody rb)
    {
        Debug.Log("shoot");
        ballBody.AddForce(new Vector3(0, 0, -startSpeed));
    }
}
