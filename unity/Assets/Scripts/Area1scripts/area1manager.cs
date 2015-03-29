using UnityEngine;
using System.Collections;

public class area1manager : MonoBehaviour {

	public static bool deathrestart1 = false;
	public static bool level1done = false;
	public AudioClip doc1;

	//starting the game
	public bool startringgen = false;
	public bool firsttimegen = true;

	//total rings needed to finish part 1
	public int totalringsneeded = 0;

	//bool for task 1
	public bool task1start = false;

	//

	//code for counter
	public int ringcouter = 0;

	//time to wait for starting walls moving
	public float startwallsmoving = 0;

	// Use this for initialization
	void Start () {
		startringgen = false;
		ringcouter = 0;
		Screen.lockCursor = true;

		StartCoroutine(wallstartingtomove());
	}
	
	// Update is called once per frame
	void Update () {
	
		if(deathrestart1)
		{
			deathrestart1 = false;
			Application.LoadLevel("area1");
		}

		if(Input.GetKeyDown(KeyCode.Space))
		{
			startringgen = true;
	//		print("start rings");

		}

		if(ringcouter == totalringsneeded)
		{
			level1done = true;;
			//Application.LoadLevel("area1");
			print ("first part complete");
			//stop the walls and rings from doing stuff
			transform.GetComponent<Wallmove>().startwalls = false;
			task1start = true;
			ringcouter = 0;

		}

		if(task1start)
		{
			task1start = false;
		}	

	}




	IEnumerator wallstartingtomove()
	{
		yield return new WaitForSeconds(startwallsmoving);
		transform.GetComponent<Wallmove>().startwalls = true;
		startringgen = true;

	}
}
