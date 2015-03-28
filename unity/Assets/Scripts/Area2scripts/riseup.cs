using UnityEngine;
using System.Collections;

public class riseup : MonoBehaviour {

	public float floatspeed;
	public float speedinc = 1f;

	public bool startgoingup = false;


	void Start () {

	}
	
	// Update is called once per frame
	void Update () {

	//if the bool to start the floating becomes true, increase Y by speed.
	
		if (startgoingup) 
		{
			transform.Translate(0,floatspeed * Time.deltaTime,0);
			transform.rigidbody.useGravity = false;
		}

		if (Input.GetKeyDown (KeyCode.F)) 
		{
			startgoingup = true;
		}

	}

	void OnTriggerEnter(Collider skyceiling)
	{
		if (skyceiling.gameObject.name == "gameceiling") 
		{
			Application.LoadLevel("Scene1");
		}
	}
}
