using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Mirror;
using UnityEngine.UI;
public class Ranking : NetworkBehaviour
{
    public Text RankText;
    public GameObject network;
    
    public int PlayerCount;
    void Start()
    {
        InvokeRepeating("PlayerRank",0,1);
    }
    void PlayerRank()
    {
        PlayerCount = network.GetComponent<NetworkManager>().numPlayers;
        RankText.text = PlayerCount.ToString();
    }
}
