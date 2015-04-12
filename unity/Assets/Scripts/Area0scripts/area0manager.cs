using UnityEngine;
using System.Collections;

public class area0manager : MonoBehaviour {

	public float timeuntilstart = 0;

	// Use this for initialization
	void Start () {
		StartCoroutine(talkthenstart());
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	IEnumerator talkthenstart()
	{
		yield return new WaitForSeconds(timeuntilstart);
		Application.LoadLevel("area1");

	}
}
