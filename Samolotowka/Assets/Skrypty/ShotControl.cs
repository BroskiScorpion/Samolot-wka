using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShotControl : MonoBehaviour {
    private Rigidbody rb;
    public float speed;
    private float timer;
    private void Start()
    {
        timer = 1.5f;
        rb = GetComponent<Rigidbody>();
    }
    void FixedUpdate () {
        rb.velocity = rb.transform.up * speed;
	}
    private void Update()
    {
        timer -= Time.deltaTime;
        if(timer<=0)
        {
            Destroy(this.gameObject);
        }
    }
}
