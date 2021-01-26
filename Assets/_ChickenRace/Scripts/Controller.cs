using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
public class Controller : MonoBehaviour
{
    public Text TimeText;    
    private int Time = 80;    
    public int playerCount;
    public static int PlayerCount;
    int PlayerRankNo;
    public GameObject Cam;
    void Start()
    {
       
            InvokeRepeating("TimeCountDown", 0, 1);
        

        InvokeRepeating("TimeUpdate", 0, 1);
        InvokeRepeating("PlayerRank", 0, 0.33f);
    }
    void PlayerRank()
    {
        
        playerCount = 10;
        
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
            //openfin-ishscene
            SceneManager.LoadScene("finish");
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
