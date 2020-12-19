using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;
using Mirror;
public class Movement : NetworkBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        transform.DOMoveZ(150, 20f);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
