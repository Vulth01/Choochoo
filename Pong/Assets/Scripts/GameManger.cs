using System.Collections;
using System.Collections.Generic;
using UnityEngine;

using Mirror;

[DisallowMultipleComponent]
[AddComponentMenu("ScorreManager")]
public class GameManger : NetworkManager
{

    [Header("Scoring components")]
    public GameObject ball;
    public Transform ballStartPoint;

   public  GameObject ballInstance;
    //for flashing lights





    public GameObject p1Prefab;
    public GameObject p2Prefab;

    public Transform p1Trans;
    public Transform p2Trans;

    bool serverStarted;
    //to launch the ball
    Rigidbody ballBody;
    float startSpeed = 500;
    // Start is called before the first frame update
    void OnClientConnect()
    {
        // if (isClient)
        ///   {
        //       Debug.Log("p2");
        //        GameObject player2 = Instantiate(player2Prefab);
        //        NetworkServer.Spawn(player2.gameObject);
        //        StartCoroutine(GameStartupCoroutine());
        //  }




    }
    public override void OnStartServer()
    {


        //  if (hasAuthority)
        // // {
        //      Debug.Log("p1");
        //      GameObject player1 = Instantiate(player1Prefab);
        //     NetworkServer.Spawn(player1.gameObject);

        // }
    }
    public override void OnServerAddPlayer(NetworkConnection conn)
    {
        if (numPlayers == 0)
        {
            playerPrefab = p1Prefab;

            GameObject player = Instantiate(playerPrefab, p1Trans.position, p1Trans.rotation);
            NetworkServer.AddPlayerForConnection(conn, player);


        }
        else
        {
            playerPrefab = p2Prefab;
            GameObject player = Instantiate(playerPrefab, p2Trans.position, p2Trans.rotation);
            NetworkServer.AddPlayerForConnection(conn, player);

            StartCoroutine(GameStartupCoroutine());

        }


        //  if (hasAuthority)
        // // {
        //      Debug.Log("p1");
        //      GameObject player1 = Instantiate(player1Prefab);
        //     NetworkServer.Spawn(player1.gameObject);

        // }
    }
    void SpawnPlayers(GameObject playerPrefab, NetworkConnection conn, Transform startPoint)
    {

    }


    // Update is called once per frame



    void updateText()
    {

    }
    public IEnumerator GameStartupCoroutine()
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

        RpcShootBall();

    }

    // dont put any complicated types through here
    //dont you dare
    // also dont try to make an rpc in a netwrok manager/ rather use an inherrited netwrok behaviour

    void RpcShootBall()
    {

        ballBody.AddForce(new Vector3(0, 0, -startSpeed));
    }
}
