using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraControl : MonoBehaviour {
    public GameObject player;
    public GameObject samolot;
    private Transform tr;
    public bool pierwszaosoba;
    public PlayerController parentrails;
	void Start () {
        pierwszaosoba = false;
        tr = GetComponent<Transform>();
	}
	
	// Update is called once per frame
	void Update ()
    {
        if (Input.GetButtonDown("Camswitch"))
        {
            if (pierwszaosoba)
            {
                pierwszaosoba = false;
                tr.parent = player.transform;
                tr.localPosition = new Vector3(0.0f, 0.0f, 0.0f);
            }
            else
            {
                pierwszaosoba = true;
                tr.parent = samolot.transform;
                if(parentrails.rails.onrails)
                {
                    tr.localPosition = new Vector3(0.0f, 0.0f, 11.0f);
                }
                else
                {
                    tr.localPosition = new Vector3(0.0f, 0.0f, 6.0f);
                }
            }
        }
        tr.localRotation.eulerAngles.Set(0.0f, 0.0f, 0.0f);
	}
}
