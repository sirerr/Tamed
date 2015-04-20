using UnityEngine;
using System.Collections;

public class floatobj : MonoBehaviour {

	// the objects speed to float
	public float upspeed = 0;
	//default scale size
	public Vector3 defaultscalesize;
	//speed of decrease outside obj size
	public float outsideobjspeed = 0;


	// Use this for initialization
	void Start () {
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	public void onlookenter()
	{
	//	print ("you are looking at cube" + transform.name);
		transform.Translate(0,upspeed *Time.deltaTime,0,Space.World);
		rigidbody.useGravity =false;

	}

	public void onlookexit()
	{
	//	print ("you aren't looking at" + transform.name);
		rigidbody.useGravity =true;
	}
}
