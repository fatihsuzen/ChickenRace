using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChickenFinishAnim : MonoBehaviour
{
    Animator animator;
    // Start is called before the first frame update
    void Start()
    {
        animator = GetComponent<Animator>();
        InvokeRepeating("RandomIdleAnimation", Random.Range(1f, 3f), Random.Range(4f, 10f));
    }
    void RandomIdleAnimation()
    {
        int Rnd = Random.Range(0, 2);
 
            if (Rnd % 2 == 0)
            {
                animator.SetBool("Turn Head", false);
                animator.SetBool("Run", false);
                animator.SetBool("Eat", true);
            }
            else
            {
                animator.SetBool("Run", false);
                animator.SetBool("Eat", false);
                animator.SetBool("Turn Head", true);
            }        
    }
}
