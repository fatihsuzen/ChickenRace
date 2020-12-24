using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using Mirror;
public class NickName : NetworkBehaviour
{
    private string nickName;
    public Text nickNameText;
    public void PlayBtn()
    {
        nickName = nickNameText.text;
        CharacterMovement.NickName = GameObject.Find("playerNickName").GetComponent<Text>();
        CharacterMovement.NickName.text = nickNameText.text;

        Debug.Log(nickName);
    }
}
