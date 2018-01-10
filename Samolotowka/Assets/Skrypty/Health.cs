using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Health : MonoBehaviour {

    public float maxhealth;
    public float currenthealth;


	void Start ()
    {
        currenthealth = maxhealth;
	}
	
	public void Damage (float dmg)
    {
        currenthealth -= dmg;
    }
    void Heal (float ammount)
    {
        currenthealth += ammount;
        if(currenthealth>maxhealth)
        {
            currenthealth = maxhealth;
        }

    }
}
