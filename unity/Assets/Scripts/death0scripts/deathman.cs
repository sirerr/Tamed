using UnityEngine;
using System.Collections;

public class deathman : MonoBehaviour {

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}
	

	public void restartarea1()
	{
		Application.LoadLevel("area1");
	}

	public void gotolevel0()
	{
		Application.LoadLevel("area0");
	}
}
