using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class Finish : MonoBehaviour
{
    public static List<GameObject> chickensRank = new List<GameObject>();
    public List<Text> chickensRankText = new List<Text>();
    public GameObject ScoreBoard;
    private void OnCollisionEnter(Collision collision)
    {
        if (collision.collider.tag == "Player")
        {
            ScoreBoard.SetActive(true);
            chickensRank.Add(collision.collider.gameObject);
            for (int i = 0; i < chickensRank.Count; i++)
            {
                chickensRankText[i].text = (i+1)+"- "+chickensRank[i].name;
            }
        }
    }
}
