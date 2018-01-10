using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shooter : MonoBehaviour {

    public GameObject shoot;
    public float shootspace;
    public bool ready;
    public float shoottime;
    public float dps;
	void Update () {
		if(Input.GetButton("Fire1") && ready)
        {
            if(shoottime<=0)
            {
                shoottime = shootspace;
                GameObject z = Instantiate(shoot,this.transform);
                z.transform.localPosition = new Vector3(0.0f, 0.0f, 0.0f);
                z.transform.localRotation = Quaternion.Euler(90.0f, 0.0f,0.0f);
                z.transform.parent = null;

            }
        }
        shoottime -= Time.deltaTime;    
	}
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Hitable"))
        {
            Health enemy = other.gameObject.GetComponent<Health>();
            if(enemy!=null)
            {
                enemy.Damage(dps);
            }
        }
    }
}
