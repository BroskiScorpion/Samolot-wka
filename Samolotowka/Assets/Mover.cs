using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Mover : MonoBehaviour {

    public float x;
    public float y;
    public float z;
    public float speed;
    private Rigidbody rb;
	void Start ()
    {
        rb = GetComponent<Rigidbody>();
	}
	
	void FixedUpdate () {
        rb.velocity = new Vector3(x, y, z) * speed;
    }
}
