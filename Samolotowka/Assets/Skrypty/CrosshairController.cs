using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CrosshairController : MonoBehaviour {
    public Transform tr;
    private Image im;
	void Start ()
    {
        im = GetComponent<Image>();
	}
	void Update ()
    {
        Vector3 pos = Camera.main.WorldToScreenPoint(transform.position);
        im.transform.position = new Vector3 (pos.x,pos.y,im.transform.position.z);
    }
}
