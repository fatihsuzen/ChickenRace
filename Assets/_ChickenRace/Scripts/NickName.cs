using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using Mirror;
public class NickName : NetworkBehaviour
{
    [SyncVar]
    private string nickName;
    public Text nickNameText;
    CharacterMovement characterMovement;
    
    public void PlayBtn()
    {
        characterMovement = GameObject.Find("LocalPlayer").GetComponent<CharacterMovement>();
        nickName = nickNameText.text;
        characterMovement.NickName.text = nickName;

        Debug.Log(nickName);
    }
}
