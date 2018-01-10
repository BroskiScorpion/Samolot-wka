using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMover : MonoBehaviour {
    private Rigidbody rb;
    private PlayerController pc;
    public float maxspeed;
    public float minspeed;
    public float acceleration;
    public float hamulec;
    public float startspeed;
    public float currentspeed;
    public bool ready = false;
    private Transform tr;
	void Start () {
        tr = GetComponent<Transform>();
        pc = GetComponent<PlayerController>();
        rb = GetComponent<Rigidbody>();
	}
    void Update()
    {
        if (!pc.rails.onrails)
        {
            if (Input.GetButton("Przyspieszenie"))
            {
                Przyspieszenie();

            }
            if (Input.GetButton("Hamulec"))
            {
                Hamulec();
            }
        }
        else
        {

        }
        if (!ready)
        {
            currentspeed = 0.0f;
        }
        else
        {
            if(currentspeed == 0.0f)
            {
                currentspeed = startspeed;
            }
        }
        rb.velocity = tr.forward * currentspeed;
	}
    public void Przyspieszenie()
    {
        if (currentspeed < maxspeed)
        {
            currentspeed += acceleration * Time.deltaTime;
            if (currentspeed > maxspeed)
            {
                currentspeed = maxspeed;
            }
        }
    }
    public void Hamulec()
    {
        if (currentspeed > minspeed)
        {
            currentspeed -= hamulec * Time.deltaTime;
            if (currentspeed < minspeed)
            {
                currentspeed = minspeed;
            }
        }
    }
}
