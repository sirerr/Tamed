using UnityEngine;
using System.Collections;

public class Playercode : MonoBehaviour {

	public float raydistance = 0;
	public GameObject pickedupring;
	public int holdingring =0;
	public area1manager area1;

	//reference to part2
	public part2 rainstarted;
	public GameObject rainstarterobj;
	public GameObject smileyfaceps;
	public float rightringspeed = 0;
	public float wrongringspeed = 0;
	public Wallmove wallmoveref;

	//part 3 vars
	//check if first time looking at walls
	public bool firstwalllook = true;

	//last wall looked at
	public GameObject lastwall;

	//negative spee
	public float negativespeed = 0;

	//audio sounds
	public AudioClip ringpickupsound;

	// Use this for initialization
	void Start () {
	
	}

	public void pushback()
	{
		RaycastHit lookatwall;

		if(Physics.Raycast(transform.position,transform.forward,out lookatwall,raydistance))
		{
			if(lookatwall.transform.gameObject.tag == "Walls")
			{
				if(firstwalllook)
				{
					firstwalllook = false;
					lastwall = lookatwall.transform.gameObject;
					lastwall.transform.GetComponent<wallbehavoir>().perwallspeed = area1.personalwallspeed * negativespeed;
					//print to console
					print (lastwall);
				}
				else
				{
					if(lastwall.name!=lookatwall.transform.gameObject.name)
					{
						lastwall.transform.GetComponent<wallbehavoir>().perwallspeed = area1.personalwallspeed;
						lastwall = lookatwall.transform.gameObject;
						lastwall.transform.GetComponent<wallbehavoir>().perwallspeed = area1.personalwallspeed * negativespeed;
						//print to console
						print (lastwall);
					}
					else
					{
						lastwall.transform.GetComponent<wallbehavoir>().perwallspeed = area1.personalwallspeed * negativespeed;

						//print to console
						print (lastwall);
					}
				}

			}
			else
			{
				if(lastwall!=null)
				{
					lastwall.transform.GetComponent<wallbehavoir>().perwallspeed = area1.personalwallspeed;
				}
			}

		}
		else
		{
			if(lastwall!=null)
			{
				lastwall.transform.GetComponent<wallbehavoir>().perwallspeed = area1.personalwallspeed;
			}
		}
	}


	// Update is called once per frame
	void Update () {

	if(area1.part3startingbool)
		{
			pushback();
		}

	 if(area1.allowinput && !area1.task1start){
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
	}
	 
	if(rainstarterobj.activeSelf)
		{
		if(rainstarted.startringshower)
			{
				if(Input.GetMouseButtonDown(0))
				{
					ringshowertime();
				}
			}
		}
	}

	public void dropring()

	{
		pickedupring.transform.parent = null;
		pickedupring.transform.rigidbody.useGravity = true;
		StartCoroutine(maketwo());

	}

	public void ringshowertime()
	{
		RaycastHit ringhit2;

		if(Physics.Raycast(transform.position,transform.forward,out ringhit2,raydistance))
		{
			print (ringhit2.transform.name);
			if(ringhit2.transform.gameObject.transform.name != "greenring(Clone)" && ringhit2.transform.gameObject.transform.tag !="Walls")
			{
				audio.PlayOneShot(ringpickupsound);
				Instantiate(smileyfaceps,ringhit2.transform.position,ringhit2.transform.rotation);
				Destroy(ringhit2.transform.gameObject);
				wallmoveref.wallspeed = wallmoveref.wallspeed - rightringspeed;
			}

			if(ringhit2.transform.gameObject.transform.name == "greenring(Clone)")
			{
				Destroy(ringhit2.transform.gameObject);
				wallmoveref.wallspeed = wallmoveref.wallspeed + rightringspeed;
			}
		}


	}



	public void pickupring()

	{

		RaycastHit ringhitter;

		if(Physics.Raycast(transform.position,transform.forward,out ringhitter,raydistance))
		{
			//print("raycasting right now");

			if(ringhitter.transform.gameObject.transform.tag == "Ring")
			{
				audio.PlayOneShot(ringpickupsound);
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
		print("got hit");
		if(gothit.gameObject.transform.tag == "Walls")
		{
			area1manager.deathrestart1 = true;
		}

	}
}