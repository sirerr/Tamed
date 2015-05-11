using UnityEngine;
using System.Collections;

public class area1manager : MonoBehaviour {

	public static bool deathrestart1 = false;
	public static bool level1done = false;
	public AudioClip task1sound;
	public AudioClip task2sound;
	public AudioClip task3sound;

	//starting the game
	public bool startringgen = false;

	//total rings needed to finish part 1
	public int totalringsneeded = 0;

	//bool for task 1
	public bool task1start = false;

	//allow input from the player
	public bool allowinput = false;

	//code for counter
	public int ringcouter = 0;

	//time to wait for starting walls moving
	public float startwallsmoving = 0;

	//time to wait for starting the ring rain
	public float starttherain = 0;

	//rain maker gameobject
	public GameObject rainmanager;

	//rain script reference
	public part2 rainscriptref;

	//end level timeamount
	public float endtime = 0;

	//part 3 bool
	public bool part3startingbool = false;

	//part 3 before start time
	public float part3beforetime = 0;

	//part 3 play time
	public float part3playtime = 0;

	//per wall speed positive
	public float personalwallspeed = 0;

	//ui instruction labels
	public UILabel instruct1;
	public UILabel instruct2;
	public UILabel instruct3;
	public float instructtime = 0;



	// Use this for initialization
	void Start () {
		startringgen = false;
		ringcouter = 0;
	//	Screen.lockCursor = true;

		StartCoroutine(wallstartingtomove());
	}

	IEnumerator exitgame()
	{
		yield return new WaitForSeconds(3f);
		if(Input.GetMouseButtonDown(1))
		{
			OVRPluginEvent.Issue(RenderEventType.PlatformUI);
		}
	}

	// Update is called once per frame
	void Update () {
	
		if(Input.GetMouseButtonDown(1))
		{
			StartCoroutine(exitgame());
		}

		if(deathrestart1)
		{
			deathrestart1 = false;
			Application.LoadLevel("death0");
		}

//		if(Input.GetKeyDown(KeyCode.Space))
//		{
//			startringgen = true;
//	//		print("start rings");
//
//		}

		if(transform.GetComponent<Wallmove>().wallspeed < 0.0)
		{
			rainscriptref.startringshower = false;
			transform.GetComponent<Wallmove>().wallspeed = 0;

			StartCoroutine(part3starting());
		}

		if(ringcouter == totalringsneeded)
		{
			ringcouter = 0;
			level1done = true;;
			//Application.LoadLevel("area1");
			print ("first part complete");
			//stop the walls and rings from doing stuff
			transform.GetComponent<Wallmove>().startwalls = false;
			task1start = true;
			allowinput = false;
			GameObject extraring = GameObject.FindGameObjectWithTag("Ring");
			if(extraring != null){
			extraring.gameObject.rigidbody.useGravity = true;
			}

			//start playing sound from doc
			StartCoroutine(timeforrain());

		}

	

	}

	IEnumerator timeforrain()
	{
		audio.PlayOneShot(task2sound);
		instruct2.gameObject.SetActive(true);
		yield return new WaitForSeconds (starttherain);
		rainscriptref.startringshower = true;
		rainmanager.gameObject.SetActive(true);
		transform.GetComponent<Wallmove>().startwalls = true;
		yield return new WaitForSeconds(instructtime);
		instruct2.gameObject.SetActive(false);

	}

	IEnumerator wallstartingtomove()
	{
		audio.PlayOneShot(task1sound);
		instruct1.gameObject.SetActive(true);
		yield return new WaitForSeconds(startwallsmoving);

		allowinput = true;
		transform.GetComponent<Wallmove>().startwalls = true;
		startringgen = true;
		yield return new WaitForSeconds(instructtime);
		instruct1.gameObject.SetActive(false);
	}

	IEnumerator part3starting()
	{

		audio.PlayOneShot(task3sound);
		instruct3.gameObject.SetActive(true);
		yield return new WaitForSeconds(part3beforetime);

		part3startingbool = true;
		//make walls go faster
		for(int i =0; i<transform.GetComponent<Wallmove>().walls.Length;i++)
		{
			transform.GetComponent<Wallmove>().walls[i].transform.GetComponent<wallbehavoir>().perwallspeed = personalwallspeed;
		}

		yield return new WaitForSeconds(part3playtime);
		part3startingbool = false;
		for(int i =0; i<transform.GetComponent<Wallmove>().walls.Length;i++)
		{
			transform.GetComponent<Wallmove>().walls[i].transform.GetComponent<wallbehavoir>().perwallspeed = 0;
		}
		StartCoroutine(endlevel());
	}

	IEnumerator endlevel()
	{
		yield return new WaitForSeconds(endtime);
		Application.LoadLevel("thanks0");

	}
}
