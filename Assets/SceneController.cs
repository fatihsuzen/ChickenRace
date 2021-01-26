using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SceneController : MonoBehaviour
{
    public List<GameObject> BotComponent = new List<GameObject>();
    public GameObject Player;
    void Start()
    {
        Invoke("StartRace",10);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    void StartRace()
    {
        Player.GetComponent<CharacterMovement>().enabled = true;
        for (int i = 0; i < BotComponent.Count; i++)
        {
            BotComponent[i].GetComponent<Bot>().enabled = true;
        }
    }
}
