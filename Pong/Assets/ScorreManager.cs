using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using Mirror;


public class ScorreManager : NetworkBehaviour
{

    GameManger GameManger;

    public Light MainSpotlight;


    public Transform goalpost1;
    public Transform goalpost2;


    public TextMeshProUGUI scoreTXT1;
    public TextMeshProUGUI scoreTXT2;

    int score1 = 0;
    int score2 = 0;
    void Start()
    {
        GameManger = GetComponent<GameManger>();
    }
    void Update()
    {

        RpcCheckForGoal();
    }

    [ClientRpc]
    void RpcCheckForGoal()
    {
        if (GameManger.ballInstance)
        {





            Debug.Log("ballExists");


            if (GameManger.ballInstance.transform.position.y < -5)
            {

                if (GameManger.ballInstance.transform.position.z > goalpost1.position.z)
                {
                    score1 += 1;
                    scoreTXT1.text = score1.ToString();
                    StartCoroutine(FlashLightCoroutine());
                }
                else if (GameManger.ballInstance.transform.position.z < goalpost2.position.z)
                {
                    score2 += 1;
                    scoreTXT2.text = score2.ToString();
                    StartCoroutine(FlashLightCoroutine());
                }

                Object.Destroy(GameManger.ballInstance.gameObject);
                StartCoroutine(GameManger.GameStartupCoroutine());
            }
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
}
