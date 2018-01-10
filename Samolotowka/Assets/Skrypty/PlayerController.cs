using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class Boundary
{
    public float xmin, xmax, ymin, ymax;
}
[System.Serializable]
public class Rails
{
    public float zrails;
    public float znonrails;
    public float switchspeed;
    public bool onrails;
    public float railspeed;
    public float railturnspeed;
}
public class PlayerController : MonoBehaviour { 
    public Rails rails;
    private Rigidbody thisrb;
    public Transform samolotTransform;
    private Transform tr;
    public Boundary boundary;
    public float hrotspeed;
    public float zrotspeed;
    public float vrotspeed;
    public bool switching;
    public float switchtime;
    private float switchtimeremaining;
    private float xswitch;
    private float yswitch;
    private float zswitch;
    public float tilt;
    public Rigidbody rb;
    public Transform target;
    public float targetspeed;
	void Start ()
    {
        switching=false;
        switchtimeremaining = 0.0f;
        tr = GetComponent<Transform>();
        thisrb = GetComponent<Rigidbody>();
	}
 	void FixedUpdate ()
    {
        float moveHorizontal = Input.GetAxis("Horizontal");
        float moveVertical = Input.GetAxis("Vertical");
        if(switching==false)
        {
            if (rails.onrails)
            {
                if(target!=null)
                {
                    Quaternion targ = Quaternion.LookRotation(target.transform.position - tr.position);
                    tr.rotation = Quaternion.Slerp(tr.rotation, targ, targetspeed * Time.deltaTime);
                    if (tr.rotation == targ)
                    {
                        target = null;
                    }
                }
                rb.velocity = (3 *rb.velocity + tr.right * rails.railturnspeed * moveHorizontal + tr.up * moveVertical * rails.railturnspeed + thisrb.velocity)/4;
                rb.position = new Vector3(Mathf.Clamp(rb.position.x, boundary.xmin + tr.position.x, boundary.xmax + tr.position.x), Mathf.Clamp(rb.position.y, boundary.ymin + tr.position.y, boundary.ymax + tr.position.y), thisrb.position.z + rails.zrails);
                rb.rotation = Quaternion.Slerp(transform.rotation, Quaternion.Euler(rb.velocity.y * -tilt, 0.0f, rb.velocity.x * -tilt),0.4f);
            }
            else
            {
                samolotTransform.localRotation = Quaternion.Euler(0.0f, 0.0f, 0.0f);
                rb.velocity = thisrb.velocity;
                tr.Rotate(new Vector3(-moveVertical, 0.0f, -moveHorizontal));
            }

        }

        else
        {
            if (!rails.onrails)
            {
                switchtimeremaining -= Time.deltaTime;
                if (switchtimeremaining>0)
                {
                    rb.velocity = (-tr.right * samolotTransform.localPosition.x* rails.railturnspeed/3.5f) + (-tr.up * samolotTransform.localPosition.y*rails.railturnspeed/3.5f) + (-tr.forward * (samolotTransform.localPosition.z - rails.znonrails)* rails.railturnspeed/3.5f) + thisrb.velocity;
                    rb.rotation = Quaternion.Euler(rb.velocity.y * -tilt, 0.0f, rb.velocity.x * -tilt);
                }
                else
                {
                    switching = false;
                    samolotTransform.localPosition = new Vector3(0.0f, 0.0f,rails.znonrails);
                }
            }
            else
            {
                switchtimeremaining -= Time.deltaTime;
                if (switchtimeremaining>0)
                {
                    samolotTransform.localPosition = new Vector3(samolotTransform.localPosition.x, samolotTransform.localPosition.y, samolotTransform.localPosition.z + zswitch * Time.deltaTime);
                }
                else
                {
                    switching =false;
                    samolotTransform.localPosition = new Vector3(0.0f, 0.0f, rails.zrails);
                }
            }
        }
    }
    public void RailSwitch()
    {
        zswitch = 2 / switchtime;
    switching = true;
    switchtimeremaining = switchtime;
    if (rails.onrails)
        {
        rails.onrails = false;
        }
    else
        {
        rails.onrails = true;
        }
    }
}
