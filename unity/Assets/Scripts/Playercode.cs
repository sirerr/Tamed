using UnityEngine;
using System.Collections;

public class Playercode : MonoBehaviour {

	public float raydistance = 0;

	//area 1 code
	public bool holdingring = false;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
		if(Application.loadedLevelName == "area1")
		{
			if(Input.GetMouseButton(0))
			{
				pickupring();
			}
		}
	

	}

	public void pickupring()

	{

		RaycastHit ringhitter;

		if(Physics.Raycast(transform.position,Vector3.forward,out ringhitter,raydistance))
		{
			print("raycasting right now");

			if(ringhitter.transform.gameObject.transform.tag == "Ring" && !holdingring )
			{
				holdingring = true;


			}

		}



	}

	void OnCollisionEnter(Collision gothit)
	{
		print("got hit");
		if(gothit.gameObject.tag == "Walls")
		{
			area1manager.deathrestart1 = true;
		}

	}
}
