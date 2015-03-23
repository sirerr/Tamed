using UnityEngine;
using System.Collections;

public class Playercode : MonoBehaviour {

	public float raydistance = 0;
	public GameObject pickedupring;

	//area 1 code
	public bool holdingring = false;
	public bool ringalive;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
		if(Application.loadedLevelName == "area1")
		{
			if(Input.GetMouseButton(0) && !holdingring )
			{
				pickupring();
			}

			if(Input.GetMouseButton(0) && holdingring )
			{
				dropring();
			}


		}

	}

	public void dropring()

	{
		pickedupring.transform.parent = null;
		pickedupring.transform.rigidbody.useGravity = true;
		holdingring = false;
		ringalive = false;
	}

	public void pickupring()

	{

		RaycastHit ringhitter;

		if(Physics.Raycast(transform.position,Vector3.forward,out ringhitter,raydistance))
		{
			//print("raycasting right now");

			if(ringhitter.transform.gameObject.transform.tag == "Ring")
			{
				pickedupring = ringhitter.transform.gameObject;
				pickedupring.transform.parent = transform;
				ringalive = true;
			}

		}
		StartCoroutine(waitasec());
	}

	IEnumerator waitasec()
	{
		yield return new WaitForSeconds(1f);
		holdingring = true;
	}

	void OnCollisionEnter(Collision gothit)
	{
		//print("got hit");
		if(gothit.gameObject.tag == "Walls")
		{
			area1manager.deathrestart1 = true;
		}

	}
}
