using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
public class Bot : MonoBehaviour
{
    BoxCollider box;
    public Vector3 Target;
    NavMeshAgent nMesh;
    Animator animator;
    int road0, road1, road2, road3;
    public Vector3 LastPoint;
    bool eggAnimIsPlaying = false;
    // Start is called before the first frame update
    void Start()
    {
        box = GetComponent<BoxCollider>();
        LastPoint = transform.position;
        animator = GetComponent<Animator>();
        nMesh = GetComponent<NavMeshAgent>();       
    }   

    // Update is called once per frame
    void FixedUpdate()
    {
        if (!eggAnimIsPlaying)
        {
            Target = new Vector3(50, transform.position.y, transform.position.z);
            nMesh.SetDestination(Target);
            animator.SetBool("Run", true);
        }
        else
        {
            animator.SetBool("Run", false);
        }
       
        CheckPoint();

    }
    void ReturnLastPoint()
    {
        animator.SetBool("Egg", false);
        eggAnimIsPlaying = false;        
        transform.position = LastPoint;
        nMesh.enabled = true;
        box.isTrigger = false;
        InvokeRepeating("RandomIdleAnimation", Random.Range(1f, 3f), Random.Range(4f, 10f));
    }
    void CheckPoint()
    {
        if (transform.position.x > 0 && road1 == 0)
        {
            road1++;
            LastPoint = transform.position;

        }
        else if (transform.position.x > 12.5f && road2 == 0)
        {
            road2++;
            LastPoint = transform.position;
        }
        else if (transform.position.x > 29 && road3 == 0)
        {
            road3++;
            LastPoint = transform.position;

        }
    }
    private void OnCollisionEnter(Collision collision)
    {
        if (collision.collider.tag == "Car")
        {
            animator.SetBool("Egg", true);
            eggAnimIsPlaying = true;
            nMesh.enabled = false;
            box.isTrigger = true;
            CancelInvoke("RandomIdleAnimation");

            //audioSource.Stop();
            //audioSource.clip = AudioList[1];
            //audioSource.Play();
            Invoke("ReturnLastPoint", 3);
        }
        if (collision.collider.tag == "Finish")
        {
            Finish.chickensRank.Add(gameObject);
            gameObject.SetActive(false);
        }
    }
}
