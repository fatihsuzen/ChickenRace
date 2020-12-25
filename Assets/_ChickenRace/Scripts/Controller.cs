using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Mirror;
using UnityEngine.UI;
public class Controller : NetworkBehaviour
{
    public Text TimeText;
    [SyncVar]
    private int Time = 45;
    [SyncVar]
    public int playerCount;
    public static int PlayerCount;
    int PlayerRankNo;
    public GameObject network;
    public GameObject Cam;
    void Start()
    {
       
        if (isServer)
        {
            InvokeRepeating("TimeCountDown", 0, 1);
        }

        InvokeRepeating("TimeUpdate", 0, 1);
        InvokeRepeating("PlayerRank", 0, 0.33f);
    }
    void PlayerRank()
    {
        if (isServer)
        {
            playerCount = network.GetComponent<NetworkManager>().numPlayers;
        }
        
        //Debug.Log(conn);
        PlayerCount = playerCount;
        
    }
    void TimeCountDown()
    {
        Time--;
        TimeText.text = Time.ToString();
        if (Time <= 10)
        {
            TimeText.color = Color.red;
        }
        if (Time == 0)
        {
            CancelInvoke("TimeCountDown");
            //openscoreboard
        }
    }
    void TimeUpdate()
    {
        TimeText.text = Time.ToString();
        if (Time <= 10)
        {
            TimeText.color = Color.red;
        }
        if (Time == 0)
        {
            CancelInvoke("TimeCountDown");
            //openscoreboard
        }
    }
    void Camera()
    {
        Cam.SetActive(false);
    }
}
