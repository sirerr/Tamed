using UnityEngine;
using System.Collections;

public class area1manager : MonoBehaviour {

	public static bool deathrestart1 = false;
	public static bool level1done = false;
	public AudioClip doc1;
	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
		if(deathrestart1)
		{
			deathrestart1 = false;
			Application.LoadLevel("area1");
		}

		if(level1done)
		{
			level1done = false;
			Application.LoadLevel("area1");
		}

	}
}
