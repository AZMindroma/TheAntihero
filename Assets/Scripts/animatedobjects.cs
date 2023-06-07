using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class animatedobjects : MonoBehaviour
{

    public Animator anim;

    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Player")
        {
            anim.SetBool("down", true);
        }
    }
}