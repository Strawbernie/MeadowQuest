using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StartFlyingScript : MonoBehaviour
{
    public Animator anim;

    void Awake()
    {
        anim = GetComponent<Animator>();
        //trigger animation on trigger (StartFlying)
        anim.SetTrigger("StartFlying");
    }
}
