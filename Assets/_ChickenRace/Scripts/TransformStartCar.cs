using System.Collections;
using System.Collections.Generic;
using UnityEngine;
public class TransformStartCar : MonoBehaviour
{
    private void OnTriggerEnter(Collider other)
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
