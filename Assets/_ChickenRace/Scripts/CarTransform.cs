using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;
using Mirror;
public class CarTransform : NetworkBehaviour
{
   public bool way;
   public Vector3 posZ;

    private void Start()
    {
        if (way)
        {
            posZ = new Vector3(0, 0, 0.3f);
        }
        else
        {
            posZ = new Vector3(0, 0, -0.3f);
        }
      
        //transform.DOMoveZ(transform.position.z +  300f, 15f).SetLoops(0, LoopType.Yoyo).SetEase(Ease.Linear);
    }
    private void FixedUpdate()
    {
        if (isServer)
        {
            transform.position += posZ;
        }
        
    }
}
