using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class NickName : MonoBehaviour
{
    public Text nickNameText;
    public static string nickName;
    public void PlayBtn()
    {
        nickName = nickNameText.text; 
    }
}
