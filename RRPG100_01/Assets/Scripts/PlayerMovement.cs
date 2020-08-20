﻿// email: benjiferoce@gmail.com | GitHub: https://github.com/benjiferoce
// Copyright 2020, Benjamin Weaver, All rights reserved

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    Rigidbody rb;
    Animator anim;
    Vector3 destination;
    public float speed = 2.5f;

    void Start()
    {
        anim = GetComponent<Animator>();
        rb = GetComponent<Rigidbody>();
    }

    void FixedUpdate()
    {
        Vector3 movement_vector = new Vector3(Input.GetAxisRaw("Horizontal"), 0f, Input.GetAxisRaw("Vertical"));
        rb.MovePosition(rb.position + movement_vector * Time.deltaTime * speed);
    }

    void Update()
    {
        if (Input.GetAxisRaw("Horizontal") < -.01)
        {
            anim.Play("partyWalkMirror");
        }
        if (Input.GetAxisRaw("Horizontal") > .01)
        {
            anim.Play("partyWalk");
        }
    }
}
