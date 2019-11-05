using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// RRPG 100 Player Movement Script      // 11/05/2019 ------- Added basic movement and animation functionality //
// Developed by Benjamin Weaver

public class movement : MonoBehaviour
{
    Rigidbody rb;
    Animator anim;
    Vector3 destination;
    public float speed = 4.0f;

    void Start () {
        anim = GetComponent <Animator> ();
        rb = GetComponent<Rigidbody>();
    }

  void FixedUpdate()
    {
        Vector3 movement_vector = new Vector3(Input.GetAxisRaw("Horizontal"), 0f, Input.GetAxisRaw("Vertical"));
        rb.MovePosition (rb.position + movement_vector * Time.deltaTime);
    }

    void Update(){
        if(Input.GetAxisRaw("Horizontal") < -.01){
            anim.Play("sideview");
        }
        if(Input.GetAxisRaw("Horizontal") > .01){
            anim.Play("sideview_mirror");
        }
        if(Input.GetAxisRaw("Horizontal") > -.01 && Input.GetAxisRaw("Horizontal") < .01){
            anim.Play("Idle");
        }
    }
}
