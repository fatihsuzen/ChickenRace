using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Mirror;
public class TransformStartCar : NetworkBehaviour
{
    private void OnTriggerEnter(Collider other)
    {
      if (isServer)
      {        
        if (other.gameObject.GetComponent<CarTransform>().way)
        {
            other.transform.position = new Vector3(other.transform.position.x, other.transform.position.y - 5, -115f);
            other.transform.position = new Vector3(other.transform.position.x, other.transform.position.y + 5, -115f);
        }
        else
        {
            other.transform.position = new Vector3(other.transform.position.x, other.transform.position.y - 5, 115f);
            other.transform.position = new Vector3(other.transform.position.x, other.transform.position.y + 5, 115f);
        }

      }
    }
}
