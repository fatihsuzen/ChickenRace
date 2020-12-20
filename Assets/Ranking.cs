using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Mirror;
using UnityEngine.UI;
public class Ranking : NetworkBehaviour
{
    void Start()
    {
        
    }
    void PlayerRank()
    {
        foreach (var gameObj in FindObjectsOfType(typeof(GameObject))as GameObject[])
        {
            if (gameObj.name == "")
            {

            }
        }
    }
}
