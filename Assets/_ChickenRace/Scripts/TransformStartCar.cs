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
            if (other.gameObject.tag == "Car")
            {
                if (other.gameObject.GetComponent<CarTransform>().way)
                {
                    other.gameObject.SetActive(false);
                    other.transform.position = new Vector3(other.transform.position.x, other.transform.position.y - 5, -115f);
                    other.transform.position = new Vector3(other.transform.position.x, other.transform.position.y + 5, -115f);
                    other.gameObject.SetActive(true);
                }
                else
                {
                    other.gameObject.SetActive(false);
                    other.transform.position = new Vector3(other.transform.position.x, other.transform.position.y - 5, 115f);
                    other.transform.position = new Vector3(other.transform.position.x, other.transform.position.y + 5, 115f);
                    other.gameObject.SetActive(true);
                }
            }
            

      }
    }
}
