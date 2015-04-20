using UnityEngine;
using System.Collections;

public class riseup : MonoBehaviour {
	//floating up speed
	public float floatspeed = 0;
	//going faster
	public float speedinc = 1f;
	//starts the floating
	public bool startgoingup = false;
	//ref to center eyebobj
	public GameObject centereye;
	//ref to last obj looked at
	public GameObject lastbox;
	// check to see if it is the first box looked at
	private bool firsttime = true;
	//time for the raising of the player
	public float startrisefloat = 0;

	void Start()
	{
		StartCoroutine(timetorise());
		StartCoroutine(increasespeed());

	}

	IEnumerator timetorise()
	{
		yield return new WaitForSeconds(startrisefloat);
		startgoingup = true;
	}

	IEnumerator increasespeed()
	{
		yield return new WaitForSeconds(60f);
		if(floatspeed!=15)
		{
			floatspeed = speedinc +floatspeed;
		}
	}

	// Update is called once per frame
	void Update () {

		if (startgoingup) 
		{
			transform.Translate(0,floatspeed * Time.deltaTime,0,Space.World);
			transform.rigidbody.useGravity = false;
		}
		else
		{
			transform.rigidbody.useGravity = true;
		}

		if (Input.GetKeyDown (KeyCode.F)) 
		{
			startgoingup = true;
		}

		lookatbox();
	}

	public void lookatbox()
	{
		RaycastHit hitout;
		
		if(Physics.Raycast(centereye.transform.position,centereye.transform.TransformDirection(Vector3.forward), out hitout, Mathf.Infinity,1<<LayerMask.NameToLayer("cubes")))
		{
			if(hitout.transform.gameObject.transform.tag == "cangrab")
			{
				if(firsttime)
				{
					firsttime = false;
					lastbox = hitout.transform.gameObject;
					lastbox.transform.SendMessage("onlookenter");
					startgoingup = false;
				}
				else
				{
					if(lastbox.name!=hitout.transform.gameObject.name)
					{
						lastbox.SendMessage("onlookexit");
						//send command to the lastbox looked at

						// do what is needed for new box
						lastbox = hitout.transform.gameObject;
						lastbox.transform.SendMessage("onlookenter");
						startgoingup = false;
					}
						else
					{
						lastbox.transform.SendMessage("onlookenter");
						startgoingup = false;
					}
				}
			}
			else
			{

				startgoingup = true;
			}
		}
		else
		{
			if(lastbox!=null)
			{
				lastbox.SendMessage("onlookexit");
				startgoingup = true;
			}

		}
	}

	void OnTriggerEnter(Collider skyceiling)
	{
		if (skyceiling.gameObject.name == "gameceiling") 
		{
			Application.LoadLevel("area2");
		}
	}
}
