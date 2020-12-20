using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Mirror;
using UnityEngine.UI;
public class TimeController : NetworkBehaviour
{
    public Text TimeText;
    public static int Time=60;
    void Start()
    {
        
            InvokeRepeating("TimeCountDown", 0, 1);
        
        InvokeRepeating("TimeUpdate", 0, 1);
    }

    void TimeCountDown()
    {
        Time--;
        TimeText.text = Time.ToString();
        if (Time<=10)
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
    }
}
