using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WierzyczkaController : MonoBehaviour {

    public Transform horyzontal;
    public Transform vertical;
    public Transform lufa;
    public Transform player;
    private Vector3 celowanie;
	
	// Update is called once per frame
	void Update () {
        celowanie = player.position - lufa.position;
	}
    void Shot()
    {
        Debug.Log("SHOOT");
    }
}
