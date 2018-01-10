using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MeteorTumble : MonoBehaviour {
    public float x;
    public float y;
    public float z;
    public float speed;
    public Transform tr;
    private Vector3 tumble;
    private void Start()
    {
        tumble = new Vector3(x, y, z);
    }
    void FixedUpdate ()
    {
        tr.Rotate(tumble * speed * Time.deltaTime);
	}
}
