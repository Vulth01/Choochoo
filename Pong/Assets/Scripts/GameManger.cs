using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManger : MonoBehaviour
{
    public Rigidbody ballBody;
    float startSpeed = 500;

    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(GameStartup());
    }

    // Update is called once per frame
    void Update()
    {

    }
    IEnumerator GameStartup()
    {
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
