using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TransformStartCar : MonoBehaviour
{

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.collider.gameObject.GetComponent<CarTransform>().way)
        {
            collision.collider.transform.position = new Vector3(collision.collider.transform.position.x, collision.collider.transform.position.y, -115f);
        }
        else
        {
            collision.collider.transform.position = new Vector3(collision.collider.transform.position.x, collision.collider.transform.position.y, 115f);
        }
        
    }
}
