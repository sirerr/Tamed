using UnityEngine;
using System.Collections;

public class Playercode : MonoBehaviour {

	public float raydistance = 0;
	public GameObject pickedupring;
	public int holdingring =0;


	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {

		//testcode
		if(Input.GetMouseButtonDown(0))
		{
			switch (holdingring)
			{
			case 0:
				pickupring();
				break;
			case 1:
				dropring();
				break;
			}
		}

		//testcode


	}

	public void dropring()

	{
		pickedupring.transform.parent = null;
		pickedupring.transform.rigidbody.useGravity = true;
		StartCoroutine(maketwo());

	}

	public void pickupring()

	{

		RaycastHit ringhitter;

		if(Physics.Raycast(transform.position,transform.forward,out ringhitter,raydistance))
		{
			//print("raycasting right now");

			if(ringhitter.transform.gameObject.transform.tag == "Ring")
			{
				pickedupring = ringhitter.transform.gameObject;
				pickedupring.transform.parent = transform;
				holdingring = 1;
			}
		
		//	StartCoroutine(waitasec());
		}
	
	}


	IEnumerator maketwo()
	{
		yield return new WaitForSeconds(.3f);
		holdingring = 0;
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