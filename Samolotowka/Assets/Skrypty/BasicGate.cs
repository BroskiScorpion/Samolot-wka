using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BasicGate : MonoBehaviour {

    public Transform next;

    void OnTriggerEnter(Collider other)
    {
        Debug.Log("TRIGGERED");
        if (other.gameObject.tag=="Player")
        {
            PlayerController pc = other.GetComponent<PlayerController>();
            if (next!=null)
            {
                Debug.Log("TRIGGERED");
                other.gameObject.GetComponent<PlayerController>().target=next;
                if(!pc.rails.onrails)
                {
                    pc.RailSwitch();
                }
            }
            else
            {
                pc.RailSwitch();
            }
        }
    }
}
