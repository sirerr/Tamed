using UnityEngine;
using System.Collections;

public class area2manager : MonoBehaviour {
	//reference to riseup scrpt
	public riseup risescriptref;

	public AudioClip area3start;

	public float audiocliptime = 0;
	// amount in sky
	public int boxfloatingint = 0;
	//required amount in sky
	public int requiredboxfloatingint = 0;


	// Use this for initialization
	void Start () {
		audiocliptime = risescriptref.startrisefloat;

	}
	
	// Update is called once per frame
	void Update () {
	
	}
}
