using UnityEngine;
using System.Collections;

public class wallbehavoir : MonoBehaviour {

	//wall personal speed
	public float perwallspeed = 0;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
		transform.Translate(0,0,perwallspeed *Time.deltaTime);
	}
}
