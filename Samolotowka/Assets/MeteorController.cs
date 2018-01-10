using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MeteorController : MonoBehaviour {
    public int damage;
    private void OnTriggerEnter(Collider other)
    {
        Health player = other.GetComponent<Health>();
        if(player!=null)
        {
            player.Damage(damage);
        }
    }

}
