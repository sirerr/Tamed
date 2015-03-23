using UnityEngine;
using System.Collections;

public class area1manager : MonoBehaviour {

	public static bool deathrestart1 = false;
	public static bool level1done = false;
	public AudioClip doc1;

	//starting the game
	public bool startringgen = false;
	public bool firsttimegen = true;

	//total
	public int totalringsneeded = 0;

	//code for counter
	public int ringcouter = 0;

	// Use this for initialization
	void Start () {
		startringgen = false;
		ringcouter = 0;
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

		if(level1done)
		{
			level1done = false;
			Application.LoadLevel("area1");
		}

	}
}
