using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class NickName : MonoBehaviour
{
    
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
