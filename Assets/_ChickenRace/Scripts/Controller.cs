using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Mirror;
using UnityEngine.UI;
public class Controller : NetworkBehaviour
{
    public Text TimeText;
    [SyncVar]
    private int Time = 45, PlayerCount;
    int PlayerRankNo;
    public Text RankText;
    public GameObject network;
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
            PlayerCount = network.GetComponent<NetworkManager>().numPlayers;
        }
        /*foreach (var gameObj in FindObjectsOfType(typeof(GameObject)) as GameObject[])
        {
            if (gameObj.name == "player(Clone)")
            {
                PlayerRankNo++;
            }
        }*/
        RankController();
        RankText.text = PlayerRankNo.ToString() + "/" + PlayerCount.ToString();
    }
    void RankController()
    {

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
}
